using System;
namespace ReceptWebApi.Models.DTO
{
	public class PersonResponseDto
	{
        // En transportklass som är det format som
        // web api: et skickar tillbaka data i

        public int PersonId { get; set; }
		public string Email { get; set; }
	}
}

