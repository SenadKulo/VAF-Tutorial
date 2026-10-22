using FirstVafTest.Common;
using FirstVafTest.PageObjects;
using NUnit.Framework;
using VisionAutomationFramework;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Tests
{
    // No sleeps in these tests: VAF waits for elements and for the loader by itself
    public class WaitingTests : TestBase
    {
        [SetUp]
        public void Open() => SharedContext.LetsOpen("/practice/loading");

        [Test]
        public void ResultsAreReadAfterTheSpinnerIsGone()
        {
            // From now on, VAF waits for the spinner to disappear before every element it looks for
            SharedContext.Browser.LetsUseLoader<LoadingPage.Spinner>();

            SharedContext.App.Should().HaveSection<LoadingPage.SpinnerDemo>()
                .That.Should().HaveElement<LoadingPage.SpinnerDemo.Load>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<LoadingPage.SpinnerDemo.LoadCount>()
                    .That.AsCounterField().Should().HaveValue("1")
                .AndAlso().Should().HaveElement<LoadingPage.SpinnerDemo.FirstResult>()
                    .That.AsLabelText().Should().HaveValue("Alpha (load 1)");
        }

        // The same check without the loader comes too early: the counter still shows "0"
        [Test]
        public void WithoutTheLoaderTheCheckIsTooEarly()
        {
            SharedContext.App.Should().HaveSection<LoadingPage.SpinnerDemo>()
                .That.Should().HaveElement<LoadingPage.SpinnerDemo.Load>()
                    .That.AsButton().LetsClick();

            Assert.Throws<VafAssertionException>(() =>
                SharedContext.App.Should().HaveSection<LoadingPage.SpinnerDemo>()
                    .That.Should().HaveElement<LoadingPage.SpinnerDemo.LoadCount>()
                        .That.AsCounterField().Should().HaveValue("1"));
        }

        [Test]
        public void LateMessageIsWaitedFor()
        {
            // The message appears two seconds after the click; HaveElement waits for it
            SharedContext.App.Should().HaveSection<LoadingPage.LateDemo>()
                .That.Should().HaveElement<LoadingPage.LateDemo.Show>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<LoadingPage.LateDemo.Message>()
                    .That.AsLabelText().Should().HaveValue("Here I am, two seconds later.");
        }
    }
}
