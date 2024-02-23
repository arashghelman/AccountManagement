using AccountManagement.Application.Contracts.Requests;
using AccountManagement.Application.Contracts.Results;

namespace AccountManagement.Application.Contracts.Interfaces
{
    public interface IUserAccountService
    {
        public Task<GetBalanceResult> GetBalance(GetBalanceRequest request, CancellationToken cancellationToken);

        public Task<CreateTransactionResult> CreateTransaction(CreateTransactionRequest request, CancellationToken cancellationToken);

        public Task<List<GetLatestTransactionsResult>> GetLatestTransactions(GetLatestTransactionsRequest request, CancellationToken cancellationToken);
    }
}
