using InventorySystem.Interfaces;

namespace InventorySystem.ConsoleUI;

public sealed class ConsoleInventoryContext : IInventoryContext
{
    public int HealApplied { get; set; }
    public string? LastEquippedSlot { get; set; }

    public void Reset()
    {
        HealApplied = 0;
        LastEquippedSlot = null;
    }
}