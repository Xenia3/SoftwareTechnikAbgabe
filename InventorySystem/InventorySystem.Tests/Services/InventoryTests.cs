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
    
    [Theory]
    [InlineData("potion", typeof(ConsumableItem))]
    [InlineData("sword",  typeof(EquipmentItem))]
    public void Create_ShouldReturnExpectedSubtype(string type, Type expected)
    {
        var item = ItemFactory.Create(type, "Test");
        Assert.IsType(expected, item);
    }
    
    [Fact]
    public void Use_ShouldApplyHeal_OnConsumable()
    {
        var inv = new Inventory();
        var potion = new ConsumableItem("Potion", "heal", 10);
        inv.Add(potion);

        var ctx = new FakeInventoryContext();
        var ok = inv.Use(potion.Id, ctx);

        Assert.True(ok);
        Assert.Equal(10, ctx.HealApplied);
    }

    [Fact]
    public void Use_ShouldEquip_OnEquipment()
    {
        var inv = new Inventory();
        var sword = new EquipmentItem("Sword", "rusty", "hand");
        inv.Add(sword);

        var ctx = new FakeInventoryContext();
        var ok = inv.Use(sword.Id, ctx);

        Assert.True(ok);
        Assert.Equal("hand", ctx.LastEquippedSlot);
    }

    [Fact]
    public void Use_ShouldReturnFalse_WhenUnknownId()
    {
        var inv = new Inventory();
        var ctx = new FakeInventoryContext();

        var ok = inv.Use(Guid.NewGuid(), ctx);

        Assert.False(ok);
        Assert.Equal(0, ctx.HealApplied);
        Assert.Null(ctx.LastEquippedSlot);
    }
}