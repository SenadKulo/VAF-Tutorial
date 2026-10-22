using FirstVafTest.Common;
using FirstVafTest.SharedSteps;
using NUnit.Framework;

namespace FirstVafTest.Tests
{
    // The test of lesson 2, written with shared steps: it reads as what the user does
    public class RegistrationTests : TestBase
    {
        // TestBase has started the browser; this opens the form and fills SharedContext.App
        [SetUp]
        public void Open() => FormsSteps.LetsOpenTheForm();

        [TestCase("Free")]
        [TestCase("Team")]
        [TestCase("Enterprise")]
        public void ValidRegistrationIsShownBack(string plan)
        {
            FormsSteps.LetsRegister("Ada Lovelace", "ada@example.com", "analytical", "Croatia", plan);
            FormsSteps.LetsCheckTheResult("Ada Lovelace", "ada@example.com", "Croatia", plan);
        }

        [TestCase("ada.example.com", "This does not look like an email address.")]
        [TestCase("", "Please enter your email address.")]
        public void WrongEmailIsReported(string email, string error)
        {
            FormsSteps.LetsRegister("Ada Lovelace", email, "analytical", "Croatia");

            Assert.That(FormsSteps.LetsReadTheEmailError(), Is.EqualTo(error));
        }
    }
}
