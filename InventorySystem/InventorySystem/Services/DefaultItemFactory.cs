using InventorySystem.Interfaces;
using InventorySystem.Models;

namespace InventorySystem.Services;

public class DefaultItemFactory : IItemFactory
{
    public Item Create(string type, string name) =>
        type.ToLower() switch
        {
            "potion" => new ConsumableItem(name, "healing potion", 25),
            "sword"  => new EquipmentItem(name, "basic sword", "hand"),
            _        => new ConsumableItem(name, "mystery snack", 5)
        };
}