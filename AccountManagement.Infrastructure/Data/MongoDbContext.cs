using AccountManagement.Domain.Models.UserAccount;
using AccountManagement.Infrastructure.Configurations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace AccountManagement.Infrastructure.Data
{
    public class MongoDbContext : IMongoDbContext
	{
        public IMongoCollection<UserAccount> UserAccounts { get; set; }

        public MongoDbContext(MongoDbConfigurations settings)
		{
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("CustomConventions", conventionPack, type => true);

            RegisterMappings();

            var mongoClient = new MongoClient(settings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);

            UserAccounts = mongoDatabase.GetCollection<UserAccount>(settings.UserAccountsCollectionName);
        }

        public void RegisterMappings()
        {
            BsonClassMap.RegisterClassMap<UserAccount>(map =>
            {
                map.AutoMap();
                map.MapMember(x => x.UserID).SetElementName("userID");
                map.MapMember(x => x.AccountID).SetElementName("accountID");
                map.MapMember(x => x.Balance).SetElementName("balance");
                map.MapMember(x => x.Transactions).SetElementName("transactions");
            });

            BsonClassMap.RegisterClassMap<AccountTransaction>(map =>
            {
                map.AutoMap();
                map.MapMember(x => x.TransactionID).SetElementName("transactionID");
                map.MapMember(x => x.Type).SetElementName("type");
                map.MapMember(x => x.Timestamp).SetElementName("timestamp");
                map.MapMember(x => x.Amount).SetElementName("amount");
            });
        }
    }
}

