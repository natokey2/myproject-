using System;
namespace ReceptWebApi.Models.DTO
{
	public class ReceptStatusResponseDto
	{
        // En transportklass som är det format som
        // web api: et skickar tillbaka data i

        public int ReceptId { get; set; }
        public string Title { get; set; }
    }
}

