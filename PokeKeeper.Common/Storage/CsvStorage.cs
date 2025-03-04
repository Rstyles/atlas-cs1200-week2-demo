using System;
using PokeKeeper.Common.Enums;
using PokeKeeper.Common.Models;

namespace PokeKeeper.Common.Storage;

public class CsvStorage : FileStorage
{
    public CsvStorage(string filePath) : base(filePath) { }

    public override Pokemon[] LoadPokemonTeamFromFile()
    {
        if (File.Exists(FilePath))
        {
            string[] lines = File.ReadAllLines(FilePath);
            if (lines.Length > 0)
            {
                Pokemon[] pokemonTeam = new Pokemon[6];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    pokemonTeam[i] = new Pokemon()
                    {
                        Name = values[0],
                        Type = (Enums.Type)Enum.Parse(typeof(Enums.Type), values[1]),
                        HP = int.Parse(values[2]),
                        Attack = int.Parse(values[3]),
                        Defense = int.Parse(values[4]),
                        SpecialAttack = int.Parse(values[5]),
                        SpecialDefense = int.Parse(values[6]),
                        Speed = int.Parse(values[7])
                    };
                }
                return pokemonTeam;
            }
            return [];
        }
        return [];
    }

    public override void AddPokemon(Pokemon pokemon)
    {
        if (File.Exists(FilePath))
        {
            string line = convertPokemonToCsv(pokemon);
            File.AppendAllText(FilePath, line);
        }
        else
        {
            string line = convertPokemonToCsv(pokemon);
            File.WriteAllText(FilePath, line);
        }

        PokemonTeam = LoadPokemonTeamFromFile() ?? new Pokemon[6];
    }

    private string convertPokemonToCsv(Pokemon pokemon)
    {
        return $"{pokemon.Name},{pokemon.Type},{pokemon.HP},{pokemon.Attack},{pokemon.Defense},{pokemon.SpecialAttack},{pokemon.SpecialDefense},{pokemon.Speed}\n";
    }


    public override void RemovePokemon(Pokemon pokemon)
    {
        if (File.Exists(FilePath))
        {
            string[] lines = File.ReadAllLines(FilePath);
            if (lines.Length > 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    if (values[0] == pokemon.Name)
                    {
                        lines[i] = "";
                        break;
                    }
                }
                File.WriteAllLines(FilePath, lines);
            }
        }
        PokemonTeam = LoadPokemonTeamFromFile() ?? new Pokemon[6];
    }
}
