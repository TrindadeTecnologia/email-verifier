//using NUnit.Framework;
using System.Threading.Tasks;
using Trindade.EmailVerifier.Rules;
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
            [InlineData("123@paulofoliveiraoutlook.com")]
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
        }
    }
}
