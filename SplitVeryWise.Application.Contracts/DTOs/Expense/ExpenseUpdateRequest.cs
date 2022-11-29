namespace SplitVeryWise.Application.Contracts.DTOs.Expense;

public record ExpenseUpdateRequest
    (string Description); // User can't change the group or himself as the author, it just doesn't make any sense.