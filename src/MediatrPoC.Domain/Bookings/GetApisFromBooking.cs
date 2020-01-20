using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using MediatrPoC.Utils;

namespace MediatrPoC.Domain.Bookings
{
	public class GetApisFromBooking
	{
		public class Query : IRequest<Apis>
		{
			public Query(
				string bookingReference)
			{
				BookingReference = bookingReference;
			}

			public string BookingReference { get; }
		}

		public class Validator : AbstractValidator<Query>
		{
			public Validator()
			{
				RuleFor(x => x.BookingReference)
					.NotNull()
					.NotEmpty();
			}
		}

		public class Handler : IRequestHandler<Query, Apis>
		{
			private readonly IBookingRepository _bookingRepository;

			public Handler(IBookingRepository bookingRepository)
			{
				_bookingRepository = bookingRepository;
			}

			public async Task<Apis> Handle(Query request, CancellationToken cancellationToken)
			{
				Guard.Null(request, nameof(GetApisFromBooking) + nameof(Query));
				var booking = await _bookingRepository.GetBooking(request.BookingReference);
				return booking.Apis;
			}
		}
	}
}
