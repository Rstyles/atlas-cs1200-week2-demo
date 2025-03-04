using System;
using System.Text.Json;
using PokeKeeper.Common.Models;

namespace PokeKeeper.Common.Storage;

public class JsonFileStorage : FileStorage
{
    public JsonFileStorage(string filePath) : base(filePath) { }

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
        return [];
    }

    public override void AddPokemon(Pokemon pokemon)
    {
        if (File.Exists(FilePath))
        {
            if (PokemonTeam != null)
            {
                var team = new Pokemon[PokemonTeam.Length + 1];
                PokemonTeam.CopyTo(team, 0);
                team[team.Length - 1] = pokemon;
                PokemonTeam = team;
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
}
