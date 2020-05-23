using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using WAccount.Domain.Models;
using WAccount.Domain.Services;
using WAccount.Repositories.Infrastructure.Interfaces;
using Xunit;

namespace WAccount.UnitTests.Services
{
    public class UserLoginServiceTest
    {
        public UserLoginServiceTest()
        {
            UserAccountRepositoryMock = new Mock<IUserAccountRepository>();
        }

        public Mock<IUserAccountRepository> UserAccountRepositoryMock { get; set; }

        [Fact]
        public void Login_Sucess()
        {
            /// Arrange
            var userAccount = new UserAccount { Email = "guilherme@teste.com", Password = "123" };
            UserAccountRepositoryMock.Setup(x => x.GetWhere(It.IsAny<Expression<Func<UserAccount, bool>>>()))
                .Returns(
                    new UserAccount [] { userAccount });

            var userLoginService = 
                new UserLoginService(UserAccountRepositoryMock.Object);

            /// Act
            var result = userLoginService.Login(userAccount.Email, userAccount.Password);

            /// Assert
            result.Should().BeEquivalentTo(userAccount);
        }
    }
}
