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
    public class BankAccountServiceTest
    {
        public BankAccountServiceTest()
        {
            UserAccountRepositoryMock = new Mock<IUserAccountRepository>();
        }

        public Mock<IUserAccountRepository> UserAccountRepositoryMock { get; set; }

        [Fact]
        public void UpdateBalanceDaily_Sucess ()
        {
            /// Arrange
            int days = 2;
            decimal income = (days * BankAccountService.DAILY_RETURN_RATE) + 1;

            var userAccount = new UserAccount { Balance = 100,  UpdatedAt = DateTime.Now.AddDays(-days) };
            var expectedUserAccount = new UserAccount { Balance = Decimal.Round(100 * income, 2) };

            UserAccountRepositoryMock.Setup(x => x.GetWhere(It.IsAny<Expression<Func<UserAccount, bool>>>()))
                .Returns(
                    new UserAccount [] { userAccount });

            var bankAccountService = 
                new BankAccountService(UserAccountRepositoryMock.Object);

            /// Act
            var result = bankAccountService.UpdateBalanceDaily();

            /// Assert
            result.Should().BeTrue();
            expectedUserAccount.Balance.Should().Be(userAccount.Balance);
            UserAccountRepositoryMock.Verify(x => x.Update(It.IsAny<UserAccount>()), Times.Once);
        }
    }
}
