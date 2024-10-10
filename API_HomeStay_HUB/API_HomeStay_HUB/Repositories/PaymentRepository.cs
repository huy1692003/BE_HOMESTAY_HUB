using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DBContext _dbContext;

        public PaymentRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _dbContext.Payments.ToListAsync();
        }

        public async Task<Payment?> GetPaymentById(int paymentID)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(p => p.PaymentID == paymentID);
        }

        public async Task<bool> CreatePayment(Payment payment)
        {
            var paymentEntity = await _dbContext.Payments.AddAsync(payment);
            if (paymentEntity.Entity.PaymentStatus == 1)
            {
                var bookingProcess = await _dbContext.BookingProcesses.FindAsync(paymentEntity.Entity.BookingID);
                bookingProcess!.PaymentTime=DateTime.Now;
                bookingProcess!.StepOrder = 2;
            }
            return await _dbContext.SaveChangesAsync() > 0;
        }



    }
}
