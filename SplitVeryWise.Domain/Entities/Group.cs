namespace SplitVeryWise.Domain.Entities;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<User> Users { get; set; } = new HashSet<User>();
    public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    public ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
}