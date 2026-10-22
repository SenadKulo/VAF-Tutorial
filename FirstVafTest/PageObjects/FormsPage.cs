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

            public class AcceptTerms : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("accept-terms");
            }

            public class Submit : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("submit-button");
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
        }
    }
}
