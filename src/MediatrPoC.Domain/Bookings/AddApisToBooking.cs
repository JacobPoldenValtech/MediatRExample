using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using MediatrPoC.Utils;

namespace MediatrPoC.Domain.Bookings
{
	public class AddApisToBooking
	{
		public class Command : IRequest
		{
			public Command(
				string firstName,
				string lastName,
				string documentNumber,
				string bookingReference)
			{
				BookingReference = bookingReference;
				FirstName = firstName;
				LastName = lastName;
				DocumentNumber = documentNumber;
			}

			public string BookingReference { get; }

			public string FirstName { get; }

			public string LastName { get; }

			public string DocumentNumber { get; }
		}

		public class Validator : AbstractValidator<Command>
		{
			public Validator()
			{
				RuleFor(x => x.BookingReference)
					.NotNull()
					.NotEmpty();
				RuleFor(x => x.FirstName)
					.NotNull()
					.NotEmpty();
				RuleFor(x => x.LastName)
					.NotNull()
					.NotEmpty();
				RuleFor(x => x.DocumentNumber)
					.NotNull()
					.NotEmpty()
					.MaximumLength(30);
			}
		}

		public class Handler : IRequestHandler<Command>
		{
			private readonly IBookingRepository _bookingRepository;

			public Handler(IBookingRepository bookingRepository)
			{
				_bookingRepository = bookingRepository;
			}

			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				Guard.Null(request, nameof(AddApisToBooking) + nameof(Command));
				var booking = await _bookingRepository.GetBooking(request.BookingReference);
				var apis = new Apis(request.FirstName, request.LastName, request.DocumentNumber);
				booking.AddApis(apis);

				await _bookingRepository.SaveBooking(booking);

				return Unit.Value;
			}
		}
	}
}
