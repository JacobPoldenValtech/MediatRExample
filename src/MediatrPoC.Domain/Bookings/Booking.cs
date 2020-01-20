using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrPoC.Domain.Bookings
{
	public class Booking
	{
		public Booking(string bookingReference)
		{
			BookingReference = bookingReference;
		}

		public Booking(string bookingReference, Apis apis)
		{
			BookingReference = bookingReference;
			Apis = apis;
		}

		public string BookingReference { get; }

		public Apis Apis { get; private set; }

		public void AddApis(Apis apis)
		{
			Apis = apis;
		}
	}
}
