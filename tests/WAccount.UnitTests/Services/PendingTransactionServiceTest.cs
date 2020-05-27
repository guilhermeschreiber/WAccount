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
            var transactions = new Transaction[] {
                        new Transaction { Type = TransactionType.Debit, Amount = 200 },
                        new Transaction { Type = TransactionType.Credit, Amount = 200 },
                        new Transaction { Type = TransactionType.Debit, Amount = 100 },
                    };

            TransactionRepositoryMock.Setup(x => x.GetWhere(It.IsAny<Expression<Func<Transaction, bool>>>()))
                .Returns(transactions);

            UserAccountRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(userAccount);
            
            var pendingTransactionService = 
                new PendingTransactionsService(TransactionRepositoryMock.Object, UserAccountRepositoryMock.Object);

            /// Act
            var result = pendingTransactionService.ResolvePendingTransactions();

            /// Assert
            result.Should().BeTrue();
            expectedUserAccount.Should().BeEquivalentTo(userAccount);
            UserAccountRepositoryMock.Verify(x => x.Update(It.IsAny<UserAccount>()), Times.Exactly(3));
            TransactionRepositoryMock.Verify(x => x.Update(It.IsAny<Transaction>()), Times.Exactly(3));

            transactions[0].Result.Should().Be(TransactionResult.Error);
            transactions[1].Result.Should().Be(TransactionResult.Done);
            transactions[2].Result.Should().Be(TransactionResult.Done);

        }

        [Fact]
        public void ResolvePendingTransactions_Fail()
        {
            /// Arrange
            TransactionRepositoryMock.Setup(x => x.GetWhere(It.IsAny<Expression<Func<Transaction, bool>>>()))
                .Returns(new Transaction[] { });

            UserAccountRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new UserAccount { });

            var pendingTransactionService =
                new PendingTransactionsService(TransactionRepositoryMock.Object, UserAccountRepositoryMock.Object);

            /// Act
            var result = pendingTransactionService.ResolvePendingTransactions();

            /// Assert
            result.Should().BeFalse();
            UserAccountRepositoryMock.Verify(x => x.Update(It.IsAny<UserAccount>()), Times.Never);
            TransactionRepositoryMock.Verify(x => x.Update(It.IsAny<Transaction>()), Times.Never);
        }
    }
}
