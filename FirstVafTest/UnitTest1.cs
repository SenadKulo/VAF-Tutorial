using NUnit.Framework;
using VisionAutomationFramework;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest
{
    public class Tests
    {
        [Test]
        public void OpensThePracticeForm()
        {
            var browser = Testing.On<Chrome>();

            try
            {
                browser.LetsNavigateTo("https://www.visionautomationframework.com/practice/forms")
                    .Should().HaveTitle("Practice: forms — Vision Automation Framework");
            }
            finally
            {
                browser.Scope.Driver.Quit();
            }
        }
    }
}
