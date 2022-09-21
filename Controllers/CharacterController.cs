using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG.Services.CharacterService;
using RPG.Dtos.Character;

namespace RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController:ControllerBase
    {
      private readonly ICharacterService _characterService;

      public CharacterController(ICharacterService characterService)
      {
        _characterService = characterService;
      }

      [HttpGet("GetAll")]
      public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){

         return Ok(await _characterService.GetAllCharacters());
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<ServiceResponse<GetCharacterDto>>>GetSingleCharacter( int id){
         return Ok(await _characterService.GetcharacterByid(id));
      }

      [HttpPost]
      public  async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>>AddCharacter(AddCharacterDto newCharacter){
            
         return Ok(await _characterService.AddCharacter(newCharacter));

      }
      [HttpPut]
      public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter){
         var serviceResponse = (await _characterService.UpdateCharacter(updatedCharacter));
         if (serviceResponse.Data == null){
            return NotFound(serviceResponse);
         }
         return Ok(serviceResponse);
      }
        
    }
}