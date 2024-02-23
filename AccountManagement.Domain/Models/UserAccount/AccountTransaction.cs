namespace AccountManagement.Domain.Models.UserAccount
{
    public class AccountTransaction
    {
        public AccountTransaction(TransactionType type, decimal amount)
        {
            TransactionID = Guid.NewGuid();
            Type = type;
            Amount = amount;
            Timestamp = DateTime.UtcNow;
        }

        public Guid TransactionID { get; private set; }

        public TransactionType Type { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime Timestamp { get; private set; }

    }
}
