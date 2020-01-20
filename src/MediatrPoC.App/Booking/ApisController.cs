using System.Net;
using System.Threading.Tasks;
using MediatR;
using MediatrPoC.Domain.Bookings;
using MediatrPoC.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPoC.App.Booking
{
	[Route("api/booking")]
	[ApiController]
	public class ApisController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ApisController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[Route("{bookingReference}/apis")]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult> AddApisToBooking(
			[FromRoute]string bookingReference,
			[FromBody] AddApisToBookingRequestModel request)
		{
			Guard.Null(request, nameof(AddApisToBookingRequestModel));
			var command = new AddApisToBooking.Command(request.FirstName, request.LastName, request.DocumentNumber, bookingReference);
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpGet]
		[Route("{bookingReference}/apis")]
		public async Task<ActionResult<Apis>> GetBookingApis([FromRoute]string bookingReference)
		{
			var query = new GetApisFromBooking.Query(bookingReference);
			var apisResult = await _mediator.Send(query);
			return Ok(apisResult);
		}
	}
}