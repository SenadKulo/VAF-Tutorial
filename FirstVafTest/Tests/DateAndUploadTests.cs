using System;
using System.IO;
using FirstVafTest.PageObjects;
using NUnit.Framework;
using VisionAutomationFramework;
using VisionAutomationFramework.Actions;
using VisionAutomationFramework.Browsers;
using VisionAutomationFramework.Extensions;

namespace FirstVafTest.Tests
{
    public class DateAndUploadTests
    {
        private const string Site = "https://www.visionautomationframework.com";

        private BrowserActions browser = null!;     // set in SetUp, before every test

        [SetUp]
        public void StartTheBrowser() => browser = Testing.On<Chrome>();

        [TearDown]
        public void CloseTheBrowser() => browser.Scope.Driver.Quit();

        [Test]
        public void DateIsChosenInTheCalendar()
        {
            var date = new DateTime(2026, 10, 5);

            var app = browser.LetsNavigateTo(Site + "/practice/date-pickers")
                .Should().DisplayPage<AppPage>().That;

            // VAF opens the calendar, moves to the month and clicks the day
            app.Should().HaveSection<DatePickersPage.Single>()
                .That.Should().HaveElement<DatePickersPage.Single.Birthday>()
                    .That.AsDateTimeFlatpickerV4().LetsSelectDate(date)
                .AndAlso().Should().HaveElement<DatePickersPage.Single.Birthday>()
                    .That.AsDateTimeFlatpickerV4().Should().HaveValue(date, "yyyy-MM-dd")
                .AndAlso().Should().HaveElement<DatePickersPage.Single.Selected>()
                    .That.AsLabelText().Should().HaveValue("2026-10-05");
        }

        [Test]
        public void FileIsUploaded()
        {
            // A small file with a known size, in the test's own folder
            string file = Path.Combine(TestContext.CurrentContext.WorkDirectory, "hello.txt");
            File.WriteAllText(file, "Hello VAF");

            var app = browser.LetsNavigateTo(Site + "/practice/upload")
                .Should().DisplayPage<AppPage>().That;

            app.Should().HaveSection<UploadPage.Form>()
                .That.Should().HaveElement<UploadPage.Form.Single>()
                    .That.AsUploadFileField().LetsUpload(file)
                .AndAlso().Should().HaveElement<UploadPage.Form.Upload>()
                    .That.AsButton().LetsClick();

            app.Should().HaveSection<UploadPage.Result>()
                .That.Should().HaveElement<UploadPage.Result.Count>()
                    .That.AsCounterField().Should().HaveValue("1")
                .AndAlso().Should().HaveElement<UploadPage.Result.First>()
                    .That.AsLabelText().Should().HaveValue("hello.txt — 9 bytes");
        }
    }
}
