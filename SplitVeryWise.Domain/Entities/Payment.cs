namespace SplitVeryWise.Domain.Entities;

public class Payment
{
    public int Id { get; set; }

    public string Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public bool Confirmed { get; set; }

    public int SenderId { get; set; }
    public User Sender { get; set; }

    public int RecipientId { get; set; }
    public User Recipient { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }
}