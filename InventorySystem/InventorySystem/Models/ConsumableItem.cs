using InventorySystem.Interfaces;

namespace InventorySystem.Models;

public sealed class ConsumableItem : Item, IUsable
{
    public int HealAmount { get; }

    public ConsumableItem(string name, string description, int healAmount)
        : base(name, description) => HealAmount = healAmount;

    public void Use(IInventoryContext context)
    {
        // heal effect observable by tests
        context.HealApplied += HealAmount;
    }
}