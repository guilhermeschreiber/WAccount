using FluentAssertions;
using Moq;
using System;
using System.Linq.Expressions;
using WAccount.Domain.Models;
using WAccount.Domain.Models.Enumerators;
using WAccount.Domain.Services;
using WAccount.Repositories.Infrastructure.Interfaces;
using Xunit;

namespace WAccount.UnitTests.Services
{
    public class PendingTransactionServiceTest
    {
        public PendingTransactionServiceTest()
        {
            TransactionRepositoryMock = new Mock<ITransactionRepository>();
            UserAccountRepositoryMock = new Mock<IUserAccountRepository>();
        }

        public Mock<ITransactionRepository> TransactionRepositoryMock { get; set; }
        public Mock<IUserAccountRepository> UserAccountRepositoryMock { get; set; }

        [Fact]
        public void ResolvePendingTransactions_Success ()
        {
            /// Arrange
            var userAccount = new UserAccount { Balance = 100 };
            var expectedUserAccount = new UserAccount { Balance = 200 };

            TransactionRepositoryMock.Setup(x => x.GetWhere(It.IsAny<Expression<Func<Transaction, bool>>>()))
                .Returns(
                    new Transaction [] { new Transaction { Type = TransactionType.Credit, Amount = 100, UserId = 1 }});

            UserAccountRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(userAccount);
            
            var pendingTransactionService = 
                new PendingTransactionsService(TransactionRepositoryMock.Object, UserAccountRepositoryMock.Object);

            /// Act
            var result = pendingTransactionService.ResolvePendingTransactions();

            /// Assert
            result.Should().BeTrue();
            expectedUserAccount.Should().BeEquivalentTo(userAccount);
            UserAccountRepositoryMock.Verify(x => x.Update(It.IsAny<UserAccount>()), Times.Once);
            TransactionRepositoryMock.Verify(x => x.Update(It.IsAny<Transaction>()), Times.Once);
        }
    }
}
