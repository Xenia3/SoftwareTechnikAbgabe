namespace InventorySystem.Tests;

public sealed class FakeInventoryContext : InventorySystem.Interfaces.IInventoryContext
{
    public int HealApplied { get; set; }
    public string? LastEquippedSlot { get; set; }
}