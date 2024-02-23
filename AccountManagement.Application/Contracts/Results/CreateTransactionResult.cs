namespace AccountManagement.Application.Contracts.Results
{
    public record CreateTransactionResult(Guid TransactionID, DateTime Timestamp, decimal NewBalance);
}
