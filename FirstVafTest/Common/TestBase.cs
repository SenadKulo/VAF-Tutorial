using NUnit.Framework;
using NUnit.Framework.Interfaces;
using VisionAutomationFramework;

namespace FirstVafTest.Common
{
    // The base of every test class: the browser starts before each test and closes after it.
    // A test class adds only its own [SetUp], usually one that opens its page; NUnit runs this
    // [SetUp] first, then the one of the test class.
    public abstract class TestBase
    {
        [SetUp]
        public void StartTheBrowser() => SharedContext.LetsStartTheBrowser();

        [TearDown]
        public void ReportAndClose()
        {
            try
            {
                // A failed test leaves a screenshot of the page as it was, attached to the result
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    SharedContext.Browser?.LetsTakeScreenshot();
                }

                // Every test leaves an HTML report of what VAF did, step by step
                Testing.ConvertLogToHtml(TestContext.CurrentContext.WorkDirectory,
                                         TestContext.CurrentContext.Test.Name);
            }
            finally
            {
                // Close the browser even when the report cannot be written
                SharedContext.LetsCloseTheBrowser();
            }
        }
    }
}
