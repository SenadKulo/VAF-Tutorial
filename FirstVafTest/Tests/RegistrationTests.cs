using FirstVafTest.PageObjects;
using NUnit.Framework;
using VisionAutomationFramework;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Tests
{
    public class RegistrationTests
    {
        [Test]
        public void ValidRegistrationIsShownBack()
        {
            var browser = Testing.On<Chrome>();

            try
            {
                // The page context: every section is found from here
                var app = browser.LetsNavigateTo("https://www.visionautomationframework.com/practice/forms")
                    .Should().DisplayPage<AppPage>().That;

                // Fill in the form and send it
                app.Should().HaveSection<FormsPage.Registration>()
                    .That.Should().HaveElement<FormsPage.Registration.FullName>()
                        .That.AsTextInputField().LetsInsert("Ada Lovelace")
                    .AndAlso().Should().HaveElement<FormsPage.Registration.Email>()
                        .That.AsTextInputField().LetsInsert("ada@example.com")
                    .AndAlso().Should().HaveElement<FormsPage.Registration.Password>()
                        .That.AsTextInputField().LetsInsert("analytical")
                    .AndAlso().Should().HaveElement<FormsPage.Registration.Country>()
                        .That.AsSelectBox().LetsSelect("Croatia")
                    .AndAlso().Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                        .That.AsCheckBox().LetsClick()
                    .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
                        .That.AsButton().LetsClick();

                // Check what the server received
                app.Should().HaveSection<FormsPage.Result>()
                    .That.Should().HaveElement<FormsPage.Result.Title>()
                        .That.AsLabelText().Should().HaveValue("Registration received")
                    .AndAlso().Should().HaveElement<FormsPage.Result.FullName>()
                        .That.AsLabelText().Should().HaveValue("Ada Lovelace")
                    .AndAlso().Should().HaveElement<FormsPage.Result.Email>()
                        .That.AsLabelText().Should().HaveValue("ada@example.com")
                    .AndAlso().Should().HaveElement<FormsPage.Result.Country>()
                        .That.AsLabelText().Should().HaveValue("Croatia");
            }
            finally
            {
                browser.Scope.Driver.Quit();
            }
        }
    }
}
