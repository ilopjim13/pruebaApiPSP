namespace pruebaApiPSP.model;

public class Player
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    public float[]? Position { get; set; }
    public Inventory[]? Inventory { get; set; }
}