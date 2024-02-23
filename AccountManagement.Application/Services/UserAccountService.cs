using AccountManagement.Application.Contracts.Interfaces;
using AccountManagement.Application.Contracts.Requests;
using AccountManagement.Application.Contracts.Results;
using AccountManagement.Domain.Models.UserAccount;

namespace AccountManagement.Application.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _accountRepository;

        public UserAccountService(IUserAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<CreateTransactionResult> CreateTransaction(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var userAccount = await _accountRepository.GetUserAccount(request.UserID, cancellationToken);

            var transactionType = Enum.Parse<TransactionType>(request.TransactionType);
            var newTransaction = transactionType switch
            {
                TransactionType.Charge => userAccount.ChargeBalance(request.Value),
                _ => throw new InvalidOperationException()
            };

            await _accountRepository.UpdateUserAccount(userAccount);

            var result = new CreateTransactionResult(
                newTransaction.TransactionID, 
                newTransaction.Timestamp, 
                userAccount.Balance);

            return result;
        }

        public async Task<GetBalanceResult> GetBalance(GetBalanceRequest request, CancellationToken cancellationToken)
        {
            var userAccount = await _accountRepository.GetUserAccount(request.UserID, cancellationToken);
            var userBalance = userAccount.Balance;

            var result = new GetBalanceResult(userBalance);

            return result;
        }

        public async Task<List<GetLatestTransactionsResult>> GetLatestTransactions(GetLatestTransactionsRequest request, CancellationToken cancellationToken)
        {
            var userAccount = await _accountRepository.GetUserAccount(request.UserID, cancellationToken);

            var result = userAccount.Transactions
                .OrderByDescending(x => x.Timestamp)
                .Take(request.Limit)
                .Select(x => new GetLatestTransactionsResult(
                    x.TransactionID, 
                    x.Type.ToString(), 
                    x.Amount, 
                    x.Timestamp))
                .ToList();

            return result;
        }
    }
}
