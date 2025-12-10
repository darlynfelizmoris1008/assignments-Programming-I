namespace manuahorros.D
{
    public enum AccountType
    {
        Savings = 1,
        Contributions = 2
    }

    public class Account : FinancialProduct
    {
        public string AccountNumber { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }

        public DateTime OpenedAt { get; set; }
        public bool IsActive { get; set; }

        public Account()
        {
            OpenedAt = DateTime.Now;
            IsActive = true;
        }

        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction.IsIncomeForAccount())
                AdjustBalance(transaction.Amount);
            else if (transaction.IsOutcomeForAccount())
                AdjustBalance(-transaction.Amount, allowNegative: false);
        }
    }
}
