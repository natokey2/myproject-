using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReceptWebApi.Models.DTO;
using ReceptWebApi.Repository.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReceptWebApi.Controllers
{
    // dett är ett attribut som styr hur URL:en skall ut
    //för att routas till denna controller

    [Route("api/[controller]")]

    // Detta är  ett attribut som säger att det är ett web api

    [ApiController]

    public class PersonController : ControllerBase
    {
        private readonly IPersonRepo _personRepo;
        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] PersonLoginInputDTO personInput)
        {
            if (personInput == null)
            {
                return BadRequest("Please send the right input");
            }
            return Ok(_personRepo.LoginPerson(personInput));
        }
        [HttpPost("InsertPerson")]
        public IActionResult InsertPerson([FromBody] PersonInsertInputDTO personInsert)
        {

            if (personInsert == null)
            {
                return BadRequest("Please send the right input");
            }
            var successMessage = _personRepo.InsertPerson(personInsert);
            return Ok(new
            {
                successMessage
            });
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePerson([FromBody] PersonInsertInputDTO personUpdate, int id)
        {
            if (id <= 0 || personUpdate == null)
            {
                return BadRequest("please check the supplied credentials");
            }
            var successMessage = _personRepo.UpdatePerson(personUpdate, id);
            return Ok(new
            {
                successMessage
            });
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (id <= 0)
            {
                return BadRequest("please check the supplied credentials");
            }
            var successMessage = _personRepo.DeletePerson(id);
            return NoContent();
        }
    }

}

