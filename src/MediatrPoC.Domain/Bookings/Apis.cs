namespace MediatrPoC.Domain.Bookings
{
	public class Apis
	{
		public Apis(
			string firstName,
			string lastName,
			string documentNumber)
		{
			FirstName = firstName;
			LastName = lastName;
			DocumentNumber = documentNumber;
		}

		public string FirstName { get; }

		public string LastName { get; }

		public string DocumentNumber { get; }
	}
}
