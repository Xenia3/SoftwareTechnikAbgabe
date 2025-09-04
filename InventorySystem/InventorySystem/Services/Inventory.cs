using InventorySystem.Models;
using InventorySystem.Interfaces;

namespace InventorySystem.Services;

public class Inventory
{
    private readonly List<Item> _items = new();

    public int Capacity { get; }
    public int Count => _items.Count;

    public Inventory(int capacity = int.MaxValue)
    {
        Capacity = capacity;
    }

    public IReadOnlyCollection<Item> ListAll() => _items.AsReadOnly();

    public bool Add(Item item)
    {
        if (Count >= Capacity) return false;
        _items.Add(item);
        return true;
    }

    public bool Remove(Guid id)
    {
        var i = _items.FindIndex(x => x.Id == id);
        if (i < 0) return false;
        _items.RemoveAt(i);
        return true;
    }

    public Item? Find(Guid id) => _items.FirstOrDefault(i => i.Id == id);

    // Use flow
    public bool Use(Guid id, IInventoryContext context)
    {
        var item = Find(id);
        if (item is null) return false;

        if (item is IUsable usable)
        {
            usable.Use(context);
            return true;
        }
        return false;
    }
}