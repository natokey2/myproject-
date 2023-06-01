using System;
namespace ReceptWebApi.Models.Domain
{
	//	En domain klass mappar databasen

	public class Person
	{
		public int PersonId { get; set; }
		public string PersonName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsAvailable { get; set; }
	}
}

