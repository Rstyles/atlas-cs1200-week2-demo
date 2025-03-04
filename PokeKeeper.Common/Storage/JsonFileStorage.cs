using System;
using System.Text.Json;
using PokeKeeper.Common.Models;

namespace PokeKeeper.Common.Storage;

public class JsonFileStorage : FileStorage
{
    public JsonFileStorage(string filePath) : base(filePath) {}

    public override Pokemon[] LoadPokemonTeamFromFile()
    {
        if (File.Exists(FilePath))
        {
            using (StreamReader reader = new(FilePath))
            {
                string json = reader.ReadToEnd();
                Pokemon[] pokemonTeam = JsonSerializer.Deserialize<Pokemon[]>(json) ?? [];
                return pokemonTeam;
            }
        }
        else
        {
            return [];
        }
    }

    public override void AddPokemon(Pokemon pokemon)
    {
        if (File.Exists(FilePath))
        {
            if (PokemonTeam != null)
            {
                for (int i = 0; i < PokemonTeam.Length; i++)
                {
                    if (PokemonTeam[i] == null)
                    {
                        PokemonTeam[i] = pokemon;
                        break;
                    }
                }
                string json = JsonSerializer.Serialize(PokemonTeam);
                File.WriteAllText(FilePath, json);
            }
        }
        else
        {
            PokemonTeam[0] = pokemon;
            string json = JsonSerializer.Serialize(PokemonTeam);
            File.WriteAllText(FilePath, json);
        }
    }

    public override void RemovePokemon(Pokemon pokemon)
    {
        if (File.Exists(FilePath))
        {
            if (PokemonTeam != null)
            {
                for (int i = 0; i < PokemonTeam.Length; i++)
                {
                    if (PokemonTeam[i] == pokemon)
                    {
                        PokemonTeam[i] = new Pokemon()
                        {
                            Name = null,
                            Type = null,
                            HP = null,
                            Attack = null,
                            Defense = null,
                            SpecialAttack = null,
                            SpecialDefense = null,
                            Speed = null
                        };
                        break;
                    }
                }
                string json = JsonSerializer.Serialize(PokemonTeam);
                File.WriteAllText(FilePath, json);
            }
        }
    }
}
