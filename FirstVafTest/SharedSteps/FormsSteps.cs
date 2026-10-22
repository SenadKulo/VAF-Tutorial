using System;
using FirstVafTest.Common;
using FirstVafTest.PageObjects;
using VisionAutomationFramework.Core;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.SharedSteps
{
    // What a user does on /practice/forms, one step per action. Tests call these steps and do not
    // know how the form is filled in: when the form changes, only this file changes.
    public static class FormsSteps
    {
        public static void LetsOpenTheForm() => SharedContext.LetsOpen("/practice/forms");

        // plan is Free, Team or Enterprise
        public static void LetsRegister(string fullName, string email, string password, string country, string plan = "Free")
        {
            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.FullName>()
                    .That.AsTextInputField().LetsInsert(fullName)
                .AndAlso().Should().HaveElement<FormsPage.Registration.Email>()
                    .That.AsTextInputField().LetsInsert(email)
                .AndAlso().Should().HaveElement<FormsPage.Registration.Password>()
                    .That.AsTextInputField().LetsInsert(password)
                .AndAlso().Should().HaveElement<FormsPage.Registration.Country>()
                    .That.AsSelectBox().LetsSelect(country);

            // Each plan is its own radio button; the test only names the plan
            switch (plan)
            {
                case "Free": LetsChooseThePlan<FormsPage.Registration.PlanFree>(); break;
                case "Team": LetsChooseThePlan<FormsPage.Registration.PlanTeam>(); break;
                case "Enterprise": LetsChooseThePlan<FormsPage.Registration.PlanEnterprise>(); break;
                default: throw new ArgumentException("No such plan: " + plan, nameof(plan));
            }

            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().LetsClick();
        }

        public static void LetsCheckTheResult(string fullName, string email, string country, string plan)
        {
            SharedContext.App.Should().HaveSection<FormsPage.Result>()
                .That.Should().HaveElement<FormsPage.Result.Title>()
                    .That.AsLabelText().Should().HaveValue("Registration received")
                .AndAlso().Should().HaveElement<FormsPage.Result.FullName>()
                    .That.AsLabelText().Should().HaveValue(fullName)
                .AndAlso().Should().HaveElement<FormsPage.Result.Email>()
                    .That.AsLabelText().Should().HaveValue(email)
                .AndAlso().Should().HaveElement<FormsPage.Result.Country>()
                    .That.AsLabelText().Should().HaveValue(country)
                .AndAlso().Should().HaveElement<FormsPage.Result.Plan>()
                    .That.AsLabelText().Should().HaveValue(plan);
        }

        // A step can also give something back, for the test to check
        public static string LetsReadTheEmailError()
        {
            return SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.EmailError>()
                    .That.AsLabelText().LetsGetValue();
        }

        private static void LetsChooseThePlan<TPlan>() where TPlan : IElementContext, new()
        {
            SharedContext.App.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<TPlan>()
                    .That.AsRadioButton().LetsClick();
        }
    }
}
