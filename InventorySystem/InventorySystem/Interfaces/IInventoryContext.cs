namespace InventorySystem.Interfaces;

public interface IInventoryContext
{
    int HealApplied { get; set; }
    string? LastEquippedSlot { get; set; }
}