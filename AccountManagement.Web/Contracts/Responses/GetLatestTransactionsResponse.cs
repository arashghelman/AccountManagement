namespace AccountManagement.Web.Contracts.Responses
{
    public record GetLatestTransactionsResponse(Guid TransactionID, string Type, decimal Amount, DateTime Timestamp);
}
