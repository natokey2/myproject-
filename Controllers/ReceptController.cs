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

    public class ReceptController : ControllerBase
    {
        private readonly IReceptRepo _receptRepo;

        //vi injectar automapper för att kunna göra mappingen 

        public ReceptController(IReceptRepo receptRepo)
        {
            _receptRepo = receptRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var recepts = _receptRepo.GetAllRecepts();
            if (recepts == null)
            {
                return NotFound("no recepts are available");
            }
            return Ok(recepts);
        }
        [HttpGet("{receptId}")]
        public IActionResult GetCategory(int receptId)
        {
            var recept = _receptRepo.GetIndividualReceptById(receptId);
            if (recept == null)
            {
                return NotFound("No Recept is available, send the right input");
            }
            return Ok(recept);
        }
        /* [HttpGet("search/{title}")]
         public IActionResult GetIndividualRecept(string title)
         {
             return Ok(_receptRepo.GetReceptByTitle(title));
         }*/
        [HttpGet("serch/{title}")]
        public IActionResult GetIndividualRecept(string title)
        {
            var recept = _receptRepo.GetReceptByTitle(title);
            if (recept == null)
            {
                return NotFound();
            }
            return Ok(recept);
        }
            
        

        
            

        [HttpGet]
        [Route("person/{personId}")]
        public IActionResult GetReceptsByPerson(int personId)
        {
            return Ok(_receptRepo.GetAvailableReceptsByPersonId(personId));
        }
        [HttpPost("{personId}")]
        public IActionResult InsertRecept(int personId, [FromBody] ReceptInputInsertDto receptInputDto)
        {
            return Ok(_receptRepo.InsertReceptByPersonId(receptInputDto, personId));
        }
        [HttpPut("{receptId}")]
        public IActionResult updateRecept([FromQuery] int personId, int receptId, [FromBody] ReceptUpdateDto receptUpadteDto)
        {
            return Ok(_receptRepo.UpdateReceptById(receptUpadteDto, personId, receptId));
        }
        [HttpDelete("{receptId}")]
        public IActionResult DeleteRecept([FromQuery] int personId, int receptId)
        {
            var message = _receptRepo.DeleteReceptById(personId, receptId);
            return Ok(new
            {
                message
            });
        }
        [HttpGet]
        [Route("rating/{receptId}")]
        public IActionResult UpadteRatingValue(int receptId, [FromQuery] int personId, [FromQuery] int ratingValue)
        {
            if (!(ratingValue >= 1 && ratingValue <= 5)) return BadRequest("Rating Value must be between 1 and 5 ");

            var recept = _receptRepo.GetIndividualReceptById(receptId);
            if (recept.PersonId == personId)
            {
                return BadRequest("Person must be a different member");
            }
            var message = _receptRepo.SetRatingValue(personId, receptId, ratingValue);

            return Ok(new
            {
                message
            });
        }
    }
}

