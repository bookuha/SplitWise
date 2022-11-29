using SplitVeryWise.Application.Contracts.DTOs.Expense;
using SplitVeryWise.Application.Contracts.DTOs.User;

namespace SplitVeryWise.Application.Contracts.DTOs.ExpenseLine;

public record ExpenseLineResponse(
    int Id,
    UserResponse TargetedUser,
    int ExpenseId);