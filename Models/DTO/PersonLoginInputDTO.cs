﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ReceptWebApi.Models.DTO
{
	public class PersonLoginInputDTO
	{
        // En transportklass som är det format som
        // web api: et skickar tillbaka data i

        [Required]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
    }
}

