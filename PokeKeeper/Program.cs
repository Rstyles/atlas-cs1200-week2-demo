using PokeKeeper.Common.Models;
using PokeKeeper.Common.Storage;

namespace PokeKeeper;

class Program
{
    static void Main(string[] args)
    {
        var storage = new JsonFileStorage("pokemon.csv");
        SeedData(storage);
        
        storage.DisplayTeamFromFile();
    }

    static void SeedData(FileStorage storage)
    {
        var pikachu = new Pokemon()
        {
            Name = "Raichu",
            Type = Common.Enums.Type.Electric,
            HP = 35,
            Attack = 55,
            Defense = 40,
            SpecialAttack = 50,
            SpecialDefense = 50,
            Speed = 90
        };
        var charmander = new Pokemon()
        {
            Name = "Chariard",
            Type = Common.Enums.Type.Fire,
            HP = 39,
            Attack = 52,
            Defense = 43,
            SpecialAttack = 60,
            SpecialDefense = 50,
            Speed = 65
        };
        var squirtle = new Pokemon()
        {
            Name = "Blastoise",
            Type = Common.Enums.Type.Water,
            HP = 44,
            Attack = 48,
            Defense = 65,
            SpecialAttack = 50,
            SpecialDefense = 64,
            Speed = 43
        };
        var bulbasaur = new Pokemon()
        {
            Name = "Venussaur",
            Type = Common.Enums.Type.Grass,
            HP = 45,
            Attack = 49,
            Defense = 49,
            SpecialAttack = 65,
            SpecialDefense = 65,
            Speed = 45
        };
        var jigglypuff = new Pokemon()
        {
            Name = "Wigglytuff",
            Type = Common.Enums.Type.Normal,
            HP = 115,
            Attack = 45,
            Defense = 20,
            SpecialAttack = 45,
            SpecialDefense = 25,
            Speed = 20
        };
        var meowth = new Pokemon()
        {
            Name = "Persian",
            Type = Common.Enums.Type.Normal,
            HP = 40,
            Attack = 45,
            Defense = 35,
            SpecialAttack = 40,
            SpecialDefense = 40,
            Speed = 90
        };
        storage.AddPokemon(pikachu);
        storage.AddPokemon(charmander);
        storage.AddPokemon(squirtle);
        storage.AddPokemon(bulbasaur);
        storage.AddPokemon(jigglypuff);
        storage.AddPokemon(meowth);
    }
}
