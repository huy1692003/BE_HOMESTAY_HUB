using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services.Interface
{
    public interface IBookingService
    {
        Task<bool> createBooking(Booking booking);
        Task<bool> confirmBooking(int idBooking);
        Task<bool> cancelBooking(int idBooking, string reasonCancel);

        Task<IEnumerable<dynamic>> getBookingDates(int idHomeStay);
    }
}
