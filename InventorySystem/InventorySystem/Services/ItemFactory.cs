using InventorySystem.Models;

namespace InventorySystem.Services;

public static class ItemFactory
{
    public static Item Create(string type, string name)
        => type.ToLower() switch
        {
            "potion" => new ConsumableItem(name, "healing potion", 25),
            "sword"  => new EquipmentItem(name, "basic sword", "hand"),
            _        => new ConsumableItem(name, "mystery snack", 5)
        };
}