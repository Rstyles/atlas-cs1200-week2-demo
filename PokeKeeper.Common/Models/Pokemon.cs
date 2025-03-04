namespace PokeKeeper.Common.Models;

public class Pokemon
{
    public string? Name { get; set; }
    public Enums.Type? Type { get; set; }
    public int? HP { get; set; }
    public int? Attack { get; set; }
    public int? Defense { get; set; }
    public int? SpecialAttack { get; set; }
    public int? SpecialDefense { get; set; }
    public int? Speed { get; set; }
}
