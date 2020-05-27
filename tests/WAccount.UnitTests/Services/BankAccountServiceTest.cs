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
        public void UpdateBalanceDaily_Sucess_35days ()
        {
            /// Arrange
            var days = 35;
            var initialBalance = 200;
      
            var userAccount = new UserAccount { 
                Balance = initialBalance, 
                MonthlyIncome = 30,
                UpdatedAt = DateTime.Now.AddDays(-days) 
            };

            var expectedUserAccount = new UserAccount {
                Balance = calculateBalance(initialBalance, days),
                MonthlyIncome = calculateIncome(initialBalance, days),
            };

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
            expectedUserAccount.MonthlyIncome.Should().Be(userAccount.MonthlyIncome);
            UserAccountRepositoryMock.Verify(x => x.Update(It.IsAny<UserAccount>()), Times.Once);
        }


        [Fact]
        public void UpdateBalanceDaily_Sucess_oneDay()
        {
            /// Arrange
            var days = 1;
            var initialBalance1 = 200;
            var initialBalance2 = 300;
            var initialIncome1 = 30;
            var initialIncome2 = 50;

            var userAccount1 = new UserAccount
            {
                Balance = initialBalance1,
                MonthlyIncome = initialIncome1,
                UpdatedAt = DateTime.Now.AddDays(-days)
            };

            var userAccount2 = new UserAccount
            {
                Balance = initialBalance2,
                MonthlyIncome = initialIncome2,
                UpdatedAt = DateTime.Now.AddDays(-days)
            };

            var expectedUserAccount1 = new UserAccount
            {
                Balance = calculateBalance(initialBalance1, days),
                MonthlyIncome = calculateIncome(initialBalance1, days, initialIncome1),
            };

            var expectedUserAccount2 = new UserAccount
            {
                Balance = calculateBalance(initialBalance2, days),
                MonthlyIncome = calculateIncome(initialBalance2, days, initialIncome2),
            };

            UserAccountRepositoryMock.Setup(x => x.GetWhere(It.IsAny<Expression<Func<UserAccount, bool>>>()))
                .Returns(
                    new UserAccount[] { userAccount1, userAccount2 });

            var bankAccountService =
                new BankAccountService(UserAccountRepositoryMock.Object);

            /// Act
            var result = bankAccountService.UpdateBalanceDaily();

            /// Assert
            result.Should().BeTrue();
            
            expectedUserAccount1.Balance.Should().Be(userAccount1.Balance);
            expectedUserAccount1.MonthlyIncome.Should().Be(userAccount1.MonthlyIncome);
            expectedUserAccount2.Balance.Should().Be(userAccount2.Balance);
            expectedUserAccount2.MonthlyIncome.Should().Be(userAccount2.MonthlyIncome);
            
            UserAccountRepositoryMock.Verify(x => x.Update(It.IsAny<UserAccount>()), Times.Exactly(2));
        }

        [Fact]
        public void UpdateBalanceDaily_NothingToDo()
        {
            /// Arrange
            UserAccountRepositoryMock.Setup(x => x.GetWhere(It.IsAny<Expression<Func<UserAccount, bool>>>()))
                .Returns(
                    new UserAccount[] { });

            var bankAccountService =
                new BankAccountService(UserAccountRepositoryMock.Object);

            /// Act
            var result = bankAccountService.UpdateBalanceDaily();

            /// Assert
            result.Should().BeFalse();
            UserAccountRepositoryMock.Verify(x => x.Update(It.IsAny<UserAccount>()), Times.Never);
        }


        #region Private Helpers
        private decimal calculateBalance(decimal initialBalance, int days)
        {
            return Decimal.Round(
                (initialBalance * (decimal)Math.Pow(1 + BankAccountService.DAILY_RETURN_RATE, days)), 2);
        }

        private decimal calculateIncome(decimal initialBalance, int days, decimal initialIncome = 0)
        {
            var daysFromLastMounth = days - DateTime.Now.Day;

            if (daysFromLastMounth > 0)
            {
                return Decimal.Round(
                    (initialBalance * (decimal)Math.Pow(1 + BankAccountService.DAILY_RETURN_RATE, days) -
                    initialBalance * (decimal)Math.Pow(1 + BankAccountService.DAILY_RETURN_RATE, daysFromLastMounth)), 2);
            }
            else
            {
                return Decimal.Round(initialIncome +
                    (initialBalance * (decimal)Math.Pow(1 + BankAccountService.DAILY_RETURN_RATE, days) - initialBalance), 2);
            }

        }
        #endregion


    }
}
