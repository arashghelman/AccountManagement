namespace AccountManagement.Application.Contracts.Results
{
    public record GetLatestTransactionsResult(Guid TransactionID, string Type, decimal Amount, DateTime Timestamp);
}
