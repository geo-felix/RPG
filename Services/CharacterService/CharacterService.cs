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

        public List<Character> GetAllCharacters(){
            return characters;
        }

        public Character GetcharacterByid(int id){

           return characters.FirstOrDefault(c=> c.Id == id);
        }
        
        public List<Character> AddCharacter(Character newCharacter){
            characters.Add(newCharacter);
            return characters;
        }
    }
}