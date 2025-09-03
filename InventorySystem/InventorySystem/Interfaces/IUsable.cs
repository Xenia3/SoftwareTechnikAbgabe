namespace InventorySystem.Interfaces;

public interface IUsable
{
    void Use(IInventoryContext context);
}

public interface IInventoryContext { } // placeholder
