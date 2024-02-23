using AccountManagement.Domain.Models.UserAccount;

namespace AccountManagement.Application.Contracts.Interfaces
{
    public interface IUserAccountRepository
    {
        public Task<UserAccount> GetUserAccount(Guid userID, CancellationToken cancellationToken);

        public Task UpdateUserAccount(UserAccount account);
    }
}
