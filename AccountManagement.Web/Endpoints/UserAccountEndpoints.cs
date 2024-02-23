using AccountManagement.Application.Contracts.Interfaces;
using AccountManagement.Application.Contracts.Requests;
using AccountManagement.Web.Contracts.Requests;
using AccountManagement.Web.Contracts.Responses;

namespace AccountManagement.Web.Endpoints
{
    public static class UserAccountEndpoints
    {
        public static void RegisterUserAccountEndpoints(this IEndpointRouteBuilder routeBuilder)
        {
            var routeGroup = routeBuilder.MapGroup("api/users");

            routeGroup.MapGet("{userID}/balance", async (
                Guid userID,
                CancellationToken cancellationToken,
                IUserAccountService service) =>
            {
                var request = new GetBalanceRequest(userID);
                var result = await service.GetBalance(request, cancellationToken);

                var response = new GetBalanceResponse(result.Balance);
                
                return response;
            });

            routeGroup.MapPost("{userID}/transactions", async (
                Guid userID, 
                PostTransactionRequest request,
                CancellationToken cancellationToken,
                IUserAccountService service) =>
            {
                var createRequest = new CreateTransactionRequest(userID, request.TransactionType, request.Value);
                var result = await service.CreateTransaction(createRequest, cancellationToken);

                var response = new PostTransactionResponse(result.TransactionID, result.Timestamp, result.NewBalance);

                return response;
            });

            routeGroup.MapGet("{userID}/transactions", async (
                Guid userID, 
                int limit, 
                CancellationToken cancellationToken,
                IUserAccountService service) =>
            {
                var request = new GetLatestTransactionsRequest(userID, limit);
                var result = await service.GetLatestTransactions(request, cancellationToken);

                var response = result.Select(x => 
                    new GetLatestTransactionsResponse(
                        x.TransactionID, 
                        x.Type, 
                        x.Amount, 
                        x.Timestamp)).ToList();

                return response;
            });
        }
    }
}
