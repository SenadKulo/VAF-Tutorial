using System.Collections.Generic;
using FirstVafTest.PageObjects;
using NUnit.Framework;
using VisionAutomationFramework;
using VisionAutomationFramework.Actions;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Tests
{
    public class FormControlsTests
    {
        private BrowserActions browser = null!;     // set in SetUp, before every test
        private PageActions<AppPage> app = null!;

        // Every test starts on the same page, so open it once here instead of in every test
        [SetUp]
        public void OpenTheForm()
        {
            browser = Testing.On<Chrome>();
            app = browser.LetsNavigateTo("https://www.visionautomationframework.com/practice/forms")
                .Should().DisplayPage<AppPage>().That;
        }

        // Runs after every test, also when it fails
        [TearDown]
        public void CloseTheBrowser() => browser.Scope.Driver.Quit();

        [Test]
        public void CountryListOffersEveryCountry()
        {
            var countries = new List<string>
            {
                "Choose a country", "Bosnia and Herzegovina", "Croatia", "Germany", "Montenegro", "Serbia",
                "United Kingdom", "United States"
            };

            app.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.Country>()
                    .That.AsSelectBox().Should().HaveOptions(countries)
                        .BeSelected("Choose a country")
                .AndAlso().Should().HaveElement<FormsPage.Registration.Country>()
                    .That.AsSelectBox().LetsSelect("Montenegro")
                .AndAlso().Should().HaveElement<FormsPage.Registration.Country>()
                    .That.AsSelectBox().Should().BeSelected("Montenegro");
        }

        [Test]
        public void OnlyOnePlanIsSelected()
        {
            app.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.PlanFree>()
                    .That.AsRadioButton().Should().BeSelected()
                .AndAlso().Should().HaveElement<FormsPage.Registration.PlanTeam>()
                    .That.AsRadioButton().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.PlanTeam>()
                    .That.AsRadioButton().Should().BeSelected()
                .AndAlso().Should().HaveElement<FormsPage.Registration.PlanFree>()
                    .That.AsRadioButton().Should().BeUnSelected();
        }

        [Test]
        public void SubmitIsEnabledOnceTheTermsAreAccepted()
        {
            app.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().Should().BeDisabled()
                .AndAlso().Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().Should().BeUnChecked()
                .AndAlso().Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().Should().BeChecked()
                .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().Should().BeEnabled();
        }

        // A check you have never seen fail may not check anything. This one must fail.
        [Test]
        public void CheckFailsWhenTheButtonIsDisabled()
        {
            Assert.Throws<VafAssertionException>(() =>
                app.Should().HaveSection<FormsPage.Registration>()
                    .That.Should().HaveElement<FormsPage.Registration.Submit>()
                        .That.AsButton().Should().BeEnabled());
        }

        [Test]
        public void EmptyFormShowsAnErrorPerField()
        {
            app.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.AcceptTerms>()
                    .That.AsCheckBox().LetsClick()
                .AndAlso().Should().HaveElement<FormsPage.Registration.Submit>()
                    .That.AsButton().LetsClick();

            app.Should().HaveSection<FormsPage.Registration>()
                .That.Should().HaveElement<FormsPage.Registration.ErrorCount>()
                    .That.AsCounterField().Should().HaveValue("4")
                .AndAlso().Should().HaveElement<FormsPage.Registration.FullNameError>()
                    .That.AsLabelText().Should().HaveValue("Please enter your full name.")
                .AndAlso().Should().HaveElement<FormsPage.Registration.EmailError>()
                    .That.AsLabelText().Should().HaveValue("Please enter your email address.")
                .AndAlso().Should().HaveElement<FormsPage.Registration.PasswordError>()
                    .That.AsLabelText().Should().HaveValue("Please choose a password.")
                .AndAlso().Should().HaveElement<FormsPage.Registration.CountryError>()
                    .That.AsLabelText().Should().HaveValue("Please choose a country.");
        }
    }
}
