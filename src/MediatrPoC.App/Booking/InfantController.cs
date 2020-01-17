using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatrPoC.App.Booking
{

	[Route("api/[controller]")]
	[ApiController]
	public class InfantController : Controller
	{

		public async Task<ActionResult> AddInfantDetailsToBooking()
		{
			return NoContent();
		}

		public async Task<ActionResult> GetInfantDetailsFromBooking()
		{
			return NoContent();
		}
	}
}