using NUnit.Framework;

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
        public void CloseTheBrowser() => SharedContext.LetsCloseTheBrowser();
    }
}
