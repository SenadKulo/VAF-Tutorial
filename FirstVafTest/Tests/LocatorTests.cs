using FirstVafTest.Common;
using FirstVafTest.PageObjects;
using NUnit.Framework;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Tests
{
    public class LocatorTests : TestBase
    {
        private const string Page = "/practice/mapping";

        // The same test passes before and after the redesign: the ids and data-test did not change.
        [TestCase(Page)]
        [TestCase(Page + "?version=2")]
        public void StableLocatorsSurviveTheRedesign(string path)
        {
            SharedContext.LetsOpen(path);

            SharedContext.App.Should().HaveSection<MappingPage.Order>()
                .That.Should().HaveElement<MappingPage.Order.Total>()
                    .That.AsLabelText().Should().HaveValue("€39.50")
                .AndAlso().Should().HaveElement<MappingPage.Order.Note>()
                    .That.AsTextInputField().LetsInsert("Ring twice")
                .AndAlso().Should().HaveElement<MappingPage.Order.SaveNote>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<MappingPage.Order.Message>()
                    .That.AsLabelText().Should().HaveValue("Note saved: Ring twice")
                .AndAlso().Should().HaveElement<MappingPage.Order.Cancel>()
                    .That.AsButton().LetsClick()
                .AndAlso().Should().HaveElement<MappingPage.Order.Status>()
                    .That.AsLabelText().Should().HaveValue("Cancelled");

            // Version 2 lists the items in another order, so check them without an order
            var items = SharedContext.App.Should().HaveSection<MappingPage.Order>()
                .That.LetsGetTextValuesOfElements<MappingPage.Order.ItemName>();

            Assert.That(items, Is.EquivalentTo(new[] { "Coffee beans, 1 kg", "Ceramic mug", "Paper filters" }));
        }

        [Test]
        public void FragileLocatorsWorkOnVersion1()
        {
            SharedContext.LetsOpen(Page);

            SharedContext.App.Should().HaveElement<MappingPageFragile.Title>()
                .That.AsLabelText().Should().HaveValue("Order #1042");
            SharedContext.App.Should().HaveElement<MappingPageFragile.Status>()
                .That.AsLabelText().Should().HaveValue("Paid");
            SharedContext.App.Should().HaveElement<MappingPageFragile.ThirdItemName>()
                .That.AsLabelText().Should().HaveValue("Paper filters");
            SharedContext.App.Should().HaveElement<MappingPageFragile.Total>()
                .That.AsLabelText().Should().HaveValue("€39.50");
        }

        // The same locators after the redesign. The page still shows all four values.
        [Test]
        public void FragileLocatorsBreakOnVersion2()
        {
            SharedContext.LetsOpen(Page + "?version=2");

            // Three locators find nothing any more. BePresent answers true or false instead of failing.
            Assert.That(SharedContext.App.Should().BePresent<MappingPageFragile.Title>(seconds: 2), Is.False);
            Assert.That(SharedContext.App.Should().BePresent<MappingPageFragile.Status>(seconds: 2), Is.False);
            Assert.That(SharedContext.App.Should().BePresent<MappingPageFragile.Total>(seconds: 2), Is.False);

            // The worst one: the third row is still there, so the locator works and reads another item
            string third = SharedContext.App.Should().HaveElement<MappingPageFragile.ThirdItemName>()
                .That.AsLabelText().LetsGetValue();

            Assert.That(third, Is.EqualTo("Coffee beans, 1 kg"));
        }
    }
}
