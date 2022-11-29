using SplitVeryWise.Application.Contracts.DTOs.Expense;
using SplitVeryWise.Application.Contracts.DTOs.Payment;
using SplitVeryWise.Application.Contracts.DTOs.User;

namespace SplitVeryWise.Application.Contracts.DTOs.Group;

public record GroupResponse(
    int Id,
    string Name,
    IEnumerable<UserResponse> Participants,
    IEnumerable<ExpenseResponse> Expenses,
    IEnumerable<PaymentResponse> Payments);