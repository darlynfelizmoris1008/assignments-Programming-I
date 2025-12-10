using manuahorros.D;

namespace manuahorros.D
{
    public abstract class FinancialProduct : BaseEntity
    {
        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public decimal Balance { get; protected set; }

        protected FinancialProduct()
        {
            Balance = 0m;
        }

        public abstract void ApplyTransaction(Transaction transaction);

        public void AdjustBalance(decimal amount)
        {
            Balance += amount;
        }

        public void AdjustBalance(decimal amount, bool allowNegative)
        {
            if (!allowNegative && Balance + amount < 0)
                throw new InvalidOperationException("Insufficient balance.");

            Balance += amount;
        }
    }
}
