using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Dtos.Character;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();

        Task<ServiceResponse<GetCharacterDto>> GetcharacterByid(int id);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        
        // add character by stored procedure
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);

        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}