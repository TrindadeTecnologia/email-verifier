using NUnit.Framework;
using Trindade.EmailVerifier.Rules;

namespace Trindade.EmailVerifier.Tests
{
    public class EmailVerifierTests
    {

        [TestFixture]
        public class WhenCreateAnEmailVerifier
        {
            public EmailVerifier _sut;

            [SetUp]
            public void Init()
            {
                _sut = new EmailVerifier();
            }

            [Test]
            [TestCase("paulofoliveira@outlook.com")]
            public void MustThrowRuleNotFoundExceptionTheExecuteWithoutRules(string email)
            {
                // Arrange:

                // Act:

                var ex = Assert.Throws<RuleNotFoundException>(() => _sut.IsValid(email));

                // Assert:

                Assert.IsInstanceOf<RuleNotFoundException>(ex);
                Assert.AreEqual("Rules not found.", ex.Message);
            }

            [Test]
            [TestCase("a@b.com")]
            [TestCase("test@xpto.com.br")]
            [TestCase("paulofoliveira@outlook.com")]
            public void MustValidEmailsOnlyWithRegexRule(string email)
            {
                // Arrange:

                _sut.AddRule(new SintaxRule());

                // Act:

                var valid = _sut.IsValid(email);

                // Assert:

                Assert.AreEqual(true, valid);
            }

            [TestCase("a@uol.com.br")]
            [TestCase("b@gmail.com")]
            [TestCase("paulofoliveira@outlook.com")]
            [TestCase("test@terra.com.br")]
            [TestCase("xpto@ig.com.br")]
            public void MustValidEmailsOnlyWithMxRule(string email)
            {
                // Arrange:

                _sut.AddRule(new MxRule());

                // Act:

                var valid = _sut.IsValid(email);

                // Assert:

                Assert.AreEqual(true, valid);
            }
        }

    }
}
