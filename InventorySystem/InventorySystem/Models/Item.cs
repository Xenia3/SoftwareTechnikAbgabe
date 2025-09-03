namespace InventorySystem.Models;

public abstract class Item
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public string Description { get; }

    protected Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}