using AccountManagement.Application.Contracts.Interfaces;
using AccountManagement.Domain.Models.UserAccount;
using AccountManagement.Infrastructure.Data;
using MongoDB.Driver;

namespace AccountManagement.Infrastructure.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly IMongoDbContext _dbContext;

        public UserAccountRepository(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAccount> GetUserAccount(Guid userID, CancellationToken cancellationToken)
        {
            var userAccount = await _dbContext.UserAccounts
                .Find(x => x.UserID == userID)
                .SingleOrDefaultAsync(cancellationToken);

            return userAccount;
        }

        public async Task UpdateUserAccount(UserAccount account)
        {
            await _dbContext.UserAccounts.ReplaceOneAsync(x => x.UserID == account.UserID, account);
        }
    }
}
