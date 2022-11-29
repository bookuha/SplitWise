namespace SplitVeryWise.Domain.Entities;

public class ExpenseLine
{
    public int Id { get; set; }

    public decimal Amount { get; set; }
    public int ExpenseId { get; set; }
    public Expense Expense { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}