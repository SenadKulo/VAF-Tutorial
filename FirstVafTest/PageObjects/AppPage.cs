using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace FirstVafTest.PageObjects
{
    // The whole application: the root every section is found in. One is enough for the whole site,
    // because VAF looks for a section in whatever page the browser shows at that moment.
    public class AppPage : IPageContext
    {
        public By PageFindMechanism { get; set; } = By.TagName("body");
    }
}
