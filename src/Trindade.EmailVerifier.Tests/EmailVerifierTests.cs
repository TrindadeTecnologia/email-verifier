//using NUnit.Framework;
using System.Threading.Tasks;
using Trindade.EmailVerifier.Rules;
using Trindade.EmailVerifier.Services;
using Xunit;

namespace Trindade.EmailVerifier.Tests
{
    public class EmailVerifierTests
    {
        public class WhenCreateAnEmailVerifier
        {
            public EmailVerifier _sut = new EmailVerifier();

            //[SetUp]
            //public void Init()
            //{
            //    _sut = new EmailVerifier();
            //}

            [Theory]
            [InlineData("paulofoliveira@outlook.com")]
            public void MustThrowRuleNotFoundExceptionTheExecuteWithoutRules(string email)
            {
                // Arrange:

                // Act:

                var ex = Assert.Throws<RuleNotFoundException>(() => _sut.IsValid(email));

                // Assert:

                //Assert.IsInstanceOf<RuleNotFoundException>(ex);
                Assert.Equal("Rules not found.", ex.Message);
            }

            [Theory]
            [InlineData("a@b.com")]
            [InlineData("test@xpto.com.br")]
            [InlineData("paulofoliveira@outlook.com")]
            public void MustValidEmailsOnlyWithRegexRule(string email)
            {
                // Arrange:

                _sut.AddRule(new SintaxRule());

                // Act:

                var valid = _sut.IsValid(email);

                // Assert:

                Assert.True(valid);
            }

            [Theory]
            [InlineData("a@uol.com.br")]
            [InlineData("b@gmail.com")]
            [InlineData("paulofoliveira@outlook.com")]
            [InlineData("test@terra.com.br")]
            [InlineData("xpto@ig.com.br")]
            public void MustValidEmailsOnlyWithMxRule(string email)
            {
                // Arrange:

                _sut.AddRule(new MxRule());

                // Act:

                var valid = _sut.IsValid(email);

                // Assert:

                Assert.Equal(true, valid);
            }

            [Theory]
            [InlineData("paulofoliveira@outlook.com")]
            public async Task MustValidEmailsOnlyWithMailboxLayer(string email)
            {
                // Arrange:

                _sut.AddRule(new MailboxLayerServiceRule("access key here"));

                // Act:

                bool valid = await _sut.IsValidAsync(email);

                // Assert:

                Assert.Equal(true, valid);
            }

            [Theory]
            [InlineData("paulo.silva@trindadetecnologia.com.br")]
            public async Task MustValidEmailsOnlyWithEmailValidator(string email)
            {
                // Arrange:

                _sut.AddRule(new EmailValidatorServiceRule("access key here"));

                // Act:

                bool valid = await _sut.IsValidAsync(email);

                // Assert:

                Assert.Equal(true, valid);
            }
        }
    }
}