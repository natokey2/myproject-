using System;
namespace ReceptWebApi.Models.DTO
{
	public class PersonInsertResponseDTO
	{
        // En transportklass som är det format som
        // web api: et skickar tillbaka data i

        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
    }
}

