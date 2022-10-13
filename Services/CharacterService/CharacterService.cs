using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Services;
using RPG.Dtos.Character;
using AutoMapper;
using System Data;
using System.Data.SqlClient;
using System.Configuration;



namespace RPG.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);
        List<Character> characters = new List<Character>();

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

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
             return new ServiceResponse<List<GetCharacterDto>>{
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
                };

            // ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            // serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            // return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetcharacterByid(int id)
        {
           var serviceResponse = new ServiceResponse<GetCharacterDto>();
           var character = characters.FirstOrDefault(c=> c.Id == id);
           serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
           return serviceResponse;
        
            // ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            //     serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            //     return serviceResponse;
        }
        
        // public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        // {
        //     var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        //     Character character = _mapper.Map<Character>(newCharacter);
        //     character.Id = characters.Max(c=> c.Id) + 1 ;
        //     characters.Add(character);
        //     serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        //     return serviceResponse;
        // //    ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        // //     Character character = _mapper.Map<Character>(newCharacter);
        // //     character.Id = characters.Max(c=> c.Id) + 1 ;
        // //     characters.Add(character);
        // //     serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
        // //     return serviceResponse;
        // }
        // public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        // {
        //     var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        //     Character character = _mapper.Map<Character>(newCharacter);
        //     character.Id = characters.Max(c=> c.Id) + 1 ;
        //     characters.Add(character);
        //     serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        //     return serviceResponse;

    
        // }

        //A post by the stored procedure

        public async Task<List<Character>> AddCharacter(Character character)
        {
            // public string msg = "";
            
            try
            {
                SqlCommand command = new SqlCommand("Addcharacter",con);
                command.CommandType = CommandType.StoredProcedure;
                

                command.Parameters.AddWithValue("@Name", character.Name);
                command.Parameters.AddWithValue("@HitPoints", character.HitPoints);
                command.Parameters.AddWithValue("@Strength", character.Strength);
                command.Parameters.AddWithValue("@Defense", character.Defense);
                command.Parameters.AddWithValue("@Intelligence", character.Intelligence);
                command.Parameters.AddWithValue("@Rpgtype", character.Rpgtype);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();

                // if(i > 0){
                //     msg "Data has been added successfully"
                // }else
                //     msg "Error"
                // }
            }
            catch (Exception ex)
            {
                
                // return msg;
            }
                // SqlCommand command = new SqlCommand("Addcharacter",con);
                // command.CommandType = CommandType.StoredProcedure;
                

                // command.Parameters.AddWithValue("@Name", character.Name);
                // command.Parameters.AddWithValue("@HitPoints", character.HitPoints);
                // command.Parameters.AddWithValue("@Strength", character.Strength);
                // command.Parameters.AddWithValue("@Defense", character.Defense);
                // command.Parameters.AddWithValue("@Intelligence", character.Intelligence);
                // command.Parameters.AddWithValue("@Rpgtype", character.Rpgtype);

                // con.Open();
                // int i = command.ExecuteNonQuery();
                // con.Close();

                // if(i > 0){
                //     msg "Data has been added successfully"
                // }else
                //     msg "Error"
                // }
            
            // return msg;
            // var serviceResponse = new ServiceResponse<List<Character>>();
            // Character character = _mapper.Map<Character>(newCharacter);
            // character.Id = characters.Max(c=> c.Id) + 1 ;
            // characters.Add(character);
            // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            // return serviceResponse;

    
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(c =>c.Id == updatedCharacter.Id);
                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strength = updatedCharacter.Strength;
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == id);
                characters.Remove(character);
                serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}