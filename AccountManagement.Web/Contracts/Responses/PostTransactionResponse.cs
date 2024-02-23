namespace AccountManagement.Web.Contracts.Responses
{
    public record PostTransactionResponse(Guid TransactionID, DateTime Timestamp, decimal NewBalance);
}
