namespace SplitVeryWise.Application.Contracts.DTOs.Payment;

public record PaymentCreateRequest(
    string Description,
    decimal Amount,
    int SenderId,
    int RecipientId,
    int GroupId);