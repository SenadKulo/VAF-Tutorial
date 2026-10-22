using OpenQA.Selenium;
using VisionAutomationFramework.Core;

namespace FirstVafTest.PageObjects
{
    // https://www.visionautomationframework.com/practice/mapping, section B: built without testing in mind.
    // DON'T MAP A PAGE LIKE THIS. Every locator below works today and breaks with the redesign
    // (?version=2); each one says why. Section B has no id to start from, so the elements are not
    // nested in a section: they are looked for in the whole page.
    public static class MappingPageFragile
    {
        // By text: version 2 says "Your order 1042". Texts get reworded and translated.
        public class Title : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.XPath("//span[text()='Order #1042']");
        }

        // By a generated class: the styling library makes new ones with every build.
        public class Status : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.CssSelector(".css-1x9f3k");
        }

        // By position: version 2 lists the items in another order, so "the third row" is another item.
        public class ThirdItemName : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.XPath("(//div[contains(@class,'d-flex gap-2 border-bottom')])[3]/div[1]/span");
        }

        // An absolute XPath, as the browser's developer tools copy it: anything that moves above it breaks it.
        public class Total : IElementContext
        {
            public By ElementFindMechanism { get; set; } = By.XPath("/html/body/main/div/div[1]/div[2]/section/div/div/div[4]/div/span[2]");
        }
    }
}
