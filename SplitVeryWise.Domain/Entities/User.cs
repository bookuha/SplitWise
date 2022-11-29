namespace SplitVeryWise.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Password { get; set; }

    public ICollection<Group> Groups { get; set; } = new HashSet<Group>();

    public ICollection<Payment> PaymentsAsSender { get; set; } = new HashSet<Payment>();
    public ICollection<Payment> PaymentsAsRecipient { get; set; } = new HashSet<Payment>();


    public ICollection<ExpenseLine> ExpenseLines { get; set; } = new HashSet<ExpenseLine>(); // Participant?
    public ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>(); // Author?
}