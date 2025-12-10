using manuahorros.D;

namespace manuahorros.D
{
    public enum LoanStatus
    {
        Active = 1,
        Paid = 2,
        Overdue = 3
    }

    public class Loan : FinancialProduct
    {
        public decimal OriginalAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public int TermInMonths { get; set; }

        public DateTime ApprovedAt { get; set; }
        public LoanStatus Status { get; set; }

        public Loan()
        {
            ApprovedAt = DateTime.Now;
            Status = LoanStatus.Active;
        }

        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Type == TransactionType.LoanPayment)
            {
                AdjustBalance(-transaction.Amount);

                if (Balance <= 0)
                {
                    Balance = 0;
                    Status = LoanStatus.Paid;
                }
            }
            else if (transaction.Type == TransactionType.LoanDisbursement)
            {
                AdjustBalance(transaction.Amount);
            }
        }

        public decimal CalculateApproxMonthlyInstallment()
        {
            if (TermInMonths <= 0)
                throw new InvalidOperationException("Term must be greater than zero.");

            decimal monthlyRate = (AnnualInterestRate / 100m) / 12m;

            if (monthlyRate == 0)
            {
                return OriginalAmount / TermInMonths;
            }

            double r = (double)monthlyRate;
            double n = TermInMonths;

            double payment =
                (double)OriginalAmount *
                (r * Math.Pow(1 + r, n)) /
                (Math.Pow(1 + r, n) - 1);

            return (decimal)payment;
        }

        public override string ToString()
        {
            return $"Loan #{Id} - Amount: {OriginalAmount:C} - Balance: {Balance:C} - Status: {Status}";
        }
    }
}
