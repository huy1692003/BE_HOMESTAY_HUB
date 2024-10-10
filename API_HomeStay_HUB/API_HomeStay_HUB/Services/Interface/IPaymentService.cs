using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services.Interface
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPayments();
        Task<Payment?> GetPaymentById(int paymentID);
        Task<bool> CreatePayment(Payment payment);
    }
}
