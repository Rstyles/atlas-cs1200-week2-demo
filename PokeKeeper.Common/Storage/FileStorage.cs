using System;
using PokeKeeper.Common.Models;

namespace PokeKeeper.Common.Storage;

public abstract class FileStorage
{
    public string FilePath { get; set; }
    public Pokemon[] PokemonTeam { get; set; }

    public FileStorage(string filePath)
    {
        FilePath = filePath;
        PokemonTeam = LoadPokemonTeamFromFile();
    }

    public abstract Pokemon[] LoadPokemonTeamFromFile();
    public abstract void AddPokemon(Pokemon pokemon);
    public abstract void RemovePokemon(Pokemon pokemon);

    public void DisplayTeamFromFile() 
    {
        if (PokemonTeam != null)
        {
            foreach (var pokemon in PokemonTeam)
            {
                if (pokemon != null)
                {
                    Console.WriteLine($"Name: {pokemon.Name}");
                    Console.WriteLine($"Type: {pokemon.Type}");
                    Console.WriteLine($"HP: {pokemon.HP}");
                    Console.WriteLine($"Attack: {pokemon.Attack}");
                    Console.WriteLine($"Defense: {pokemon.Defense}");
                    Console.WriteLine($"Special Attack: {pokemon.SpecialAttack}");
                    Console.WriteLine($"Special Defense: {pokemon.SpecialDefense}");
                    Console.WriteLine($"Speed: {pokemon.Speed}");
                    Console.WriteLine();
                }
            }
        }
    }
}
