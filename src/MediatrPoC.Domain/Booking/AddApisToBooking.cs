using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MediatrPoC.Domain.Booking
{
	public class AddApisToBooking
	{
		public class Command : IRequest<Apis>
		{

		}
	}
}
