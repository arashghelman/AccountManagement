namespace AccountManagement.Domain.Models.UserAccount
{
    public class UserAccount
    {
        public Guid UserID { get; }

        public Guid AccountID { get; }

        public decimal Balance { get; private set; }

        public List<AccountTransaction> Transactions { get; private set; }

        public AccountTransaction ChargeBalance(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Value is negative.");
            }

            Balance += value;
            var transaction = new AccountTransaction(TransactionType.Charge, Balance);
            Transactions.Add(transaction);

            return transaction;
        }
    }
}
