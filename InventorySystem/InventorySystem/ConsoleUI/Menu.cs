using InventorySystem.Interfaces;
using InventorySystem.Models;
using InventorySystem.Services;

namespace InventorySystem.ConsoleUI;
public class Menu
{
    private readonly Inventory _inventory = new();
    private readonly IItemFactory _factory;

    public Menu() : this(new DefaultItemFactory()) { }

    public Menu(IItemFactory factory)
    {
        _factory = factory;
    }


    public void Run()
    {
        Console.WriteLine("Inventory CLI: add <type> <name> | list | use <id> | remove <id> | help | exit");
        while (true)
        {
            Console.Write("> ");
            var line = Console.ReadLine();
            var (cmd, args) = CommandParser.Parse(line ?? string.Empty);

            switch (cmd)
            {
                case "exit":
                    return;

                case "help":
                    PrintHelp();
                    break;

                case "add":
                    HandleAdd(args);
                    break;

                case "list":
                    HandleList();
                    break;

                case "remove":
                    HandleRemove(args);
                    break;

                case "use":
                    HandleUse(args);
                    break;

                default:
                    if (!string.IsNullOrWhiteSpace(cmd))
                        Console.WriteLine("unknown command. type 'help' for options.");
                    break;
            }
        }
    }

    private void PrintHelp()
    {
        Console.WriteLine("commands:");
        Console.WriteLine("  add <type> <name>   - add an item (e.g., potion/sword)");
        Console.WriteLine("  list                - list all items with ids");
        Console.WriteLine("  use <id>            - use an item by guid");
        Console.WriteLine("  remove <id>         - remove an item by guid");
        Console.WriteLine("  exit                - quit");
    }

    private void HandleAdd(string[] args)
    {
        var type = args.Length > 0 ? args[0] : "potion";
        var name = args.Length > 1 ? string.Join(' ', args.Skip(1)) : "item";
        var item = _factory.Create(type, name);
        _inventory.Add(item);
        Console.WriteLine($"added {item.Name} ({item.Id})");
    }

    private void HandleList()
    {
        foreach (var it in _inventory.ListAll())
            Console.WriteLine($"{it.Id}  {it.Name}");
    }

    private void HandleRemove(string[] args)
    {
        if (args.Length < 1 || !Guid.TryParse(args[0], out var rid))
        {
            Console.WriteLine("usage: remove <guid>");
            return;
        }
        Console.WriteLine(_inventory.Remove(rid) ? "removed" : "not found");
    }

    private void HandleUse(string[] args)
    {
        if (args.Length < 1 || !Guid.TryParse(args[0], out var uid))
        {
            Console.WriteLine("usage: use <guid>");
            return;
        }

        // Call the domain method and report observed effects from the context
        var ctx = new ConsoleInventoryContext();
        var ok = _inventory.Use(uid, ctx);

        if (!ok)
        {
            Console.WriteLine("not found or not usable");
            return;
        }

        if (ctx.HealApplied > 0)
            Console.WriteLine($"healed +{ctx.HealApplied}");

        if (!string.IsNullOrWhiteSpace(ctx.LastEquippedSlot))
            Console.WriteLine($"equipped to {ctx.LastEquippedSlot}");
    }
}
