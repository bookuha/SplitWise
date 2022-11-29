using SplitVeryWise.Application.Contracts.DTOs.ExpenseLine;
using SplitVeryWise.Application.Contracts.DTOs.Group;
using SplitVeryWise.Application.Contracts.DTOs.User;

namespace SplitVeryWise.Application.Contracts.DTOs.Expense;

public record ExpenseResponse(
    int Id,
    string Description,
    DateTime Created,
    UserResponse Creator,
    IEnumerable<ExpenseLineResponse> ExpenseLines);