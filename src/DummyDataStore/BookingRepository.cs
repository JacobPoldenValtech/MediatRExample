using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatrPoC.Domain.Bookings;

namespace DummyDataStore
{
	public class BookingRepository : IBookingRepository
	{
		private static readonly List<Booking> Bookings = new List<Booking>();

		public Task<Booking> GetBooking(string bookingReference)
		{
			var booking = Bookings.Find(b => b.BookingReference == bookingReference);

			if (booking == default)
			{
				booking = new Booking(bookingReference);
				Bookings.Add(booking);
			}

			return Task.FromResult(booking);
		}

		public Task SaveBooking(Booking booking)
		{
			var bookingToUpdate = Bookings.Find(b => b.BookingReference == booking.BookingReference);
			if (bookingToUpdate == default)
			{
				throw new InvalidOperationException("Can't find booking");
			}

			Bookings.Remove(bookingToUpdate);
			Bookings.Add(booking);

			return Task.CompletedTask;
		}
	}
}
