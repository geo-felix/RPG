using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Services;
using RPG.Dtos.Character;
using AutoMapper;


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


       
       
        //dependecy injection of the automapper
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)

        {
            _mapper = mapper;
            
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(){
            
            return new ServiceResponse<List<GetCharacterDto>>{
                data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
                };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetcharacterByid(int id){
           var serviceResponse = new ServiceResponse<GetCharacterDto>();
           var character = characters.FirstOrDefault(c=> c.Id == id);
           serviceResponse.data = _mapper.Map<GetCharacterDto>(character);
           return serviceResponse;
        }
        
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c=> c.Id) + 1 ;
            characters.Add(character);
            serviceResponse.data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }
    }
}