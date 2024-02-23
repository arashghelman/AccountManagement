namespace AccountManagement.Application.Contracts.Requests
{
    public record GetLatestTransactionsRequest(Guid UserID, int Limit);
}
