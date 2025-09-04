using InventorySystem.Interfaces;

namespace InventorySystem.Models;

public sealed class EquipmentItem : Item, IUsable
{
    public string Slot { get; }

    public EquipmentItem(string name, string description, string slot)
        : base(name, description) => Slot = slot;

    public void Use(IInventoryContext context)
    {
        // Mark last equipped slot (observable effect)
        context.LastEquippedSlot = Slot;
    }
}