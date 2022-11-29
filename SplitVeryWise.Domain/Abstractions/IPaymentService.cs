using SplitVeryWise.Application.Contracts.DTOs.Payment;

namespace SplitVeryWise.Domain.Abstractions;

public interface IPaymentService
{
    Task<IEnumerable<PaymentResponse>> GetPayments();

    Task<PaymentResponse> GetPaymentById(int id);

    Task<PaymentResponse> CreatePayment(PaymentCreateRequest createRequest);

    Task<PaymentResponse> DeletePayment(int id);

    Task<PaymentResponse> ConfirmPayment(PaymentConfirmationRequest updateRequest);
}