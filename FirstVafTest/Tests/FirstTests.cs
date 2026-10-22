using NUnit.Framework;
using VisionAutomationFramework;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Tests
{
    public class FirstTests
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
