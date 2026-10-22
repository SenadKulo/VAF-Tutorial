using FirstVafTest.PageObjects;
using VisionAutomationFramework;
using VisionAutomationFramework.Actions;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Common
{
    // What every test and every step needs: the browser and the page context of the application.
    // TestBase starts and closes the browser; a test or a step opens its page with LetsOpen, and
    // every chain starts from App. The properties are static, so the tests run one after another.
    public static class SharedContext
    {
        public const string Site = "https://www.visionautomationframework.com";

        public static BrowserActions Browser { get; private set; } = null!;
        public static PageActions<AppPage> App { get; private set; } = null!;

        public static void LetsStartTheBrowser() => Browser = Testing.On<Chrome>();

        // Goes to a page of the site, e.g. "/practice/forms", and fills App
        public static void LetsOpen(string path)
        {
            App = Browser.LetsNavigateTo(Site + path)
                .Should().DisplayPage<AppPage>().That;
        }

        public static void LetsCloseTheBrowser()
        {
            Browser?.Scope.Driver.Quit();
            Browser = null!;
            App = null!;
        }
    }
}
