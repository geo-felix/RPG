using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController:ControllerBase
    {
        private static List<Character> characters = new List<Character>(){
            new Character{Id=0, Name = "Frodo"},
            new Character{Id=1, Name = "Felix"},
            new Character{Id=2, Name = "David"},
            new Character{Id=3, Name = "Solomon"},
            new Character{Id=4, Name = "John"}

        };


        [HttpGet("GetAll")]
         public ActionResult<List<Character>> Get(){
            return Ok(characters);
         }

         [HttpGet("{id}")]
         public ActionResult<Character> GetSingleCharacter( int id){
            return Ok(characters.FirstOrDefault(c=> c.Id == id));
         }
    }
}