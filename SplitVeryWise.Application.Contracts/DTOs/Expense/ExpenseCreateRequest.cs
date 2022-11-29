namespace SplitVeryWise.Application.Contracts.DTOs.Expense;

public record ExpenseCreateRequest(string Description, int GroupId, int UserId);