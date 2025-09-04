using System;
using InventorySystem.Models;
using InventorySystem.Services;
using Xunit;

namespace InventorySystem.Tests;

public class InventoryTests
{
    [Fact]
    public void Add_ShouldStoreItem()
    {
        var inv  = new Inventory();
        var item = new ConsumableItem("Potion", "heal", 10);

        inv.Add(item);

        Assert.Contains(item, inv.ListAll());
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenUnknownId()
    {
        var inv = new Inventory();
        var result = inv.Remove(Guid.NewGuid());

        Assert.False(result);
    }
}