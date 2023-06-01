using System;
using System.ComponentModel.DataAnnotations;

namespace ReceptWebApi.Models.DTO
{
	public class ReceptUpdateDto
	{
        // En transportklass som är det format som
        // web api: et skickar tillbaka data i

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ingredients { get; set; }
    }
}

