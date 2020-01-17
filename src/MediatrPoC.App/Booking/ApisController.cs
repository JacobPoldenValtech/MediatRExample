using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatrPoC.App.Booking
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApisController : ControllerBase
	{
		public async Task<ActionResult> AddApisToBooking()
		{
			return NoContent();
		}

		public async Task<ActionResult> GetBookingApis()
		{
			return NoContent();
		}

		public async Task<ActionResult> RemoveApisFromBooking()
		{
			return NoContent();
		}
	}
}