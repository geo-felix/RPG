using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Services;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>(){
            new Character{Id=0, Name = "Frodo"},
            new Character{Id=1, Name = "Felix"},
            new Character{Id=2, Name = "David"},
            new Character{Id=3, Name = "Solomon"},
            new Character{Id=4, Name = "John"}

        };

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters(){
            
            return new ServiceResponse<List<Character>>{data = characters};
        }

        public async Task<ServiceResponse<Character>> GetcharacterByid(int id){
           var serviceResponse = new ServiceResponse<Character>();
           var character = characters.FirstOrDefault(c=> c.Id == id);
           serviceResponse.data = character;
           return serviceResponse;
        }
        
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter){
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResponse.data = characters;
            return serviceResponse;
        }
    }
}