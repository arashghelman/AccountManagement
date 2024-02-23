namespace AccountManagement.Application.Contracts.Requests
{
    public record CreateTransactionRequest(Guid UserID, string TransactionType, decimal Value);
}
