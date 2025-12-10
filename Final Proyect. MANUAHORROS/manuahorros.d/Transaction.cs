using manuahorros.D;
using System.Security.Principal;

namespace manuahorros.D
{
    public enum TransactionType
    {
        Deposit = 1,
        Withdrawal = 2,
        LoanDisbursement = 3,
        LoanPayment = 4,
        Interest = 5
    }

    public class Transaction : BaseEntity
    {
        public int? AccountId { get; set; }
        public Account? Account { get; set; }

        public int? LoanId { get; set; }
        public Loan? Loan { get; set; }

        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;

        public Transaction()
        {
            Date = DateTime.Now;
        }

        public bool IsIncomeForAccount()
        {
            return Type == TransactionType.Deposit ||
                   Type == TransactionType.Interest;
        }

        public bool IsOutcomeForAccount()
        {
            return Type == TransactionType.Withdrawal;
        }
    }
}
