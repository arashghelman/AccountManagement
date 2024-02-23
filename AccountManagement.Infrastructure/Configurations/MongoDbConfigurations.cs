namespace AccountManagement.Infrastructure.Configurations
{
    public class MongoDbConfigurations
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string UserAccountsCollectionName { get; set; }
    }
}
