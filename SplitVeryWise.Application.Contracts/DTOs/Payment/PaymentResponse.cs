using SplitVeryWise.Application.Contracts.DTOs.Group;
using SplitVeryWise.Application.Contracts.DTOs.User;

namespace SplitVeryWise.Application.Contracts.DTOs.Payment;

public record PaymentResponse(
    int Id,
    string Description,
    DateTime Date,
    decimal Amount,
    bool Confirmed,
    UserResponse Sender,
    UserResponse Recipient,
    GroupNameResponse Group);