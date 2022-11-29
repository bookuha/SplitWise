namespace SplitVeryWise.Application.Contracts.DTOs.ExpenseLine;

public record ExpenseLineCreateRequest(int ExpenseId, int UserId, decimal Amount);
// + Author id so only expense author can create expense lines in his expenses
// The victim must be in the group that expense belongs to