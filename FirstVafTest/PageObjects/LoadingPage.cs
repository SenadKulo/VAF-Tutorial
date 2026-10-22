using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace FirstVafTest.PageObjects
{
    // https://www.visionautomationframework.com/practice/loading
    public static class LoadingPage
    {
        // Shown while the results load. Not in a section: VAF looks for the loader in the whole page.
        public class Spinner : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.Id("loading-spinner");
        }

        // Results that come from the server one and a half seconds after the click
        public class SpinnerDemo : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("spinner-demo");

            public class Load : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("load-results");
            }

            // How many times the results were loaded: "0" until the first load is done
            public class LoadCount : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("load-count");
            }

            public class FirstResult : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("result-1");
            }
        }

        // A message that appears two seconds after the click
        public class LateDemo : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("late-demo");

            public class Show : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("show-later");
            }

            public class Message : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("late-message");
            }
        }
    }
}
