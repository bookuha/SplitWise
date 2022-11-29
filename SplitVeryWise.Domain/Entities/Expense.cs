namespace SplitVeryWise.Domain.Entities;

public class Expense
{
    public int Id { get; set; }

    public string Description { get; set; }
    public DateTime Date { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }
     
    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<ExpenseLine> Lines { get; set; } = new HashSet<ExpenseLine>();
}