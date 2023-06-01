using System;
using System.ComponentModel.DataAnnotations;

namespace ReceptWebApi.Models.DTO
{
    // En transportklass som är det format som
    // web api: et skickar tillbaka data i 
	public class ReceptResponseDto
	{
        [Key]
        public int ReceptId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public int Rating { get; set; }
    }
}

