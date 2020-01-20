using System.Threading.Tasks;
using MediatR;
using MediatrPoC.Domain.Bookings;
using MediatrPoC.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPoC.App.Booking
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApisController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ApisController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[Route("{bookingReference}")]
		public async Task<ActionResult> AddApisToBooking(
			[FromRoute]string bookingReference,
			[FromBody] AddApisToBookingRequestModel request)
		{
			Guard.Null(request, nameof(AddApisToBookingRequestModel));
			var command = new AddApisToBooking.Command(request.FirstName, request.LastName, request.DocumentNumber, bookingReference);
			await _mediator.Send(command);
			return NoContent();
		}

		// public async Task<ActionResult> GetBookingApis()
		// {
		// return NoContent();
		// }

		// public async Task<ActionResult> RemoveApisFromBooking()
		// {
		// return NoContent();
		// }
	}
}