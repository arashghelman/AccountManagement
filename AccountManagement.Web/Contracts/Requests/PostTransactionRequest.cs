namespace AccountManagement.Web.Contracts.Requests
{
    public record PostTransactionRequest(string TransactionType, decimal Value);
}
