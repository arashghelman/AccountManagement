using AccountManagement.Domain.Models.UserAccount;
using MongoDB.Driver;

namespace AccountManagement.Infrastructure.Data
{
    public interface IMongoDbContext
	{
		public IMongoCollection<UserAccount> UserAccounts { get; set; }

		public void RegisterMappings();
	}
}

