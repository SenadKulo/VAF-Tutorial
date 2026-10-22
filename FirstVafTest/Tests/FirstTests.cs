using FirstVafTest.Common;
using NUnit.Framework;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Tests
{
    public class FirstTests : TestBase
    {
        [Test]
        public void OpensThePracticeForm()
        {
            SharedContext.LetsOpen("/practice/forms");

            SharedContext.Browser.Should().HaveTitle("Practice: forms — Vision Automation Framework");
        }
    }
}
