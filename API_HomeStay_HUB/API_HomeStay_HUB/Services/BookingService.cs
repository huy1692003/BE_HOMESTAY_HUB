using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Interfaces;
using API_HomeStay_HUB.Services.Interface;

namespace API_HomeStay_HUB.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<bool> createBooking(Booking booking)
        {
            return await _bookingRepository.createBooking(booking);
        }
        public async Task<bool> confirmBooking(int idBooking)
        {
            return await _bookingRepository.confirmBooking(idBooking);  
        }
        public async Task<bool> cancelBooking(int idBooking, string reasonCancel)
        {
            return await _bookingRepository.cancelBooking(idBooking, reasonCancel);
        }
        public async Task<IEnumerable<dynamic>> getBookingDates(int idHomeStay)
        {
            return await _bookingRepository.getBookingDates(idHomeStay);
        }
    }
}
