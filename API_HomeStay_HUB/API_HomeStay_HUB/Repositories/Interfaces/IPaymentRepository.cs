using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment?> GetPaymentById(int paymentID);
        Task<bool> CreatePaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int paymentID);
    }
}
