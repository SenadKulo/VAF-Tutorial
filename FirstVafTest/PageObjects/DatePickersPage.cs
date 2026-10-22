using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace FirstVafTest.PageObjects
{
    // https://www.visionautomationframework.com/practice/date-pickers
    public static class DatePickersPage
    {
        public class Single : ISectionContext
        {
            public By SectionFindMechanism { get; set; } = By.Id("single-demo");

            // Not the input: VAF works with the wrapper flatpickr puts around it
            public class Birthday : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.CssSelector("#birthday-field .flatpickr-wrapper");
            }

            public class Selected : IElementContext
            {
                public By ElementFindMechanism { get; set; } = By.Id("birthday-value");
            }
        }
    }
}
