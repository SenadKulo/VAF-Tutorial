using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace FirstVafTest.PageObjects
{
    // https://www.visionautomationframework.com/practice/forms
    // A static class per screen only groups the sections of that screen.
    public static class FormsPage
    {
        // The sign-up form
        public class Registration : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("registration");

            public class FullName : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("full-name");
            }

            public class Email : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("email");
            }

            public class Password : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("password");
            }

            public class Country : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("country");
            }

            // Each plan is a radio button of its own
            public class PlanFree : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("plan-free");
            }

            public class PlanTeam : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("plan-team");
            }

            public class PlanEnterprise : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("plan-enterprise");
            }

            public class AcceptTerms : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("accept-terms");
            }

            public class Submit : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("submit-button");
            }

            // Shown by the server after a form with errors is sent
            public class ErrorCount : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("error-count");
            }

            public class FullNameError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("full-name-error");
            }

            public class EmailError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("email-error");
            }

            public class PasswordError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("password-error");
            }

            public class CountryError : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("country-error");
            }
        }

        // What the server received, shown after a valid form is sent
        public class Result : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("result");

            public class Title : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-title");
            }

            public class FullName : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-full-name");
            }

            public class Email : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-email");
            }

            public class Country : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-country");
            }

            public class Plan : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-plan");
            }
        }
    }
}
