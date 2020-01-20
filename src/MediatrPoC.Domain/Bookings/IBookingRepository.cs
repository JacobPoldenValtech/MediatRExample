using System.Threading.Tasks;

namespace MediatrPoC.Domain.Bookings
{
	public interface IBookingRepository
	{
		Task<Booking> GetBooking(string bookingReference);

		Task SaveBooking(Booking booking);
	}
}
