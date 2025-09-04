using System;
using Xunit;
using InventorySystem.ConsoleUI;

namespace InventorySystem.Tests;

public class CommandParserTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    public void Parse_BlankOrWhitespace_ReturnsEmpty(string input)
    {
        var (cmd, args) = CommandParser.Parse(input);
        Assert.Equal("", cmd);
        Assert.Empty(args);
    }

    [Fact]
    public void Parse_Help_NoArgs()
    {
        var (cmd, args) = CommandParser.Parse("help");
        Assert.Equal("help", cmd);
        Assert.Empty(args);
    }

    [Fact]
    public void Parse_Add_WithTypeAndMultiWordName()
    {
        var (cmd, args) = CommandParser.Parse("add potion Small Potion");
        Assert.Equal("add", cmd);
        Assert.Equal(new[] { "potion", "Small", "Potion" }, args);
    }

    [Fact]
    public void Parse_ExtraSpaces_Ignored()
    {
        var (cmd, args) = CommandParser.Parse("  add   sword   Rusty  Sword  ");
        Assert.Equal("add", cmd);
        Assert.Equal(new[] { "sword", "Rusty", "Sword" }, args);
    }

    [Fact]
    public void Parse_MixedCaseCommand_IsLowercased_ArgsPreserved()
    {
        var (cmd, args) = CommandParser.Parse("HeLp");
        Assert.Equal("help", cmd);
        Assert.Empty(args);

        (cmd, args) = CommandParser.Parse("AdD potion SmAll Potion");
        Assert.Equal("add", cmd);
        Assert.Equal(new[] { "potion", "SmAll", "Potion" }, args);
    }

    [Fact]
    public void Parse_Use_WithGuid_AsSingleArg()
    {
        var guid = "6f9619ff-8b86-d011-b42d-00cf4fc964ff";
        var (cmd, args) = CommandParser.Parse($"use {guid}");
        Assert.Equal("use", cmd);
        Assert.Single(args);
        Assert.Equal(guid, args[0]);
    }

    [Fact]
    public void Parse_Remove_WithGuid_AsSingleArg()
    {
        var guid = "6f9619ff-8b86-d011-b42d-00cf4fc964ff";
        var (cmd, args) = CommandParser.Parse($"remove {guid}");
        Assert.Equal("remove", cmd);
        Assert.Single(args);
        Assert.Equal(guid, args[0]);
    }
}
