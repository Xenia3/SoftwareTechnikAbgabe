using InventorySystem.Models;

namespace InventorySystem.Interfaces;

public interface IItemFactory
{
    Item Create(string type, string name);
}