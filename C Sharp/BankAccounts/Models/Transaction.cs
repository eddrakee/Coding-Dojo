using System;
namespace BankAccounts.Models
{
    public class Transaction : BaseEntity
    {
        public int TransactionsId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime Date { get; set; }
        public int Users_UserId { get; set; }
        public User User { get; set; }

    }
}
