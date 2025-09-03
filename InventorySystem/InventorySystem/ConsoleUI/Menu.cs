using InventorySystem.Models;
using InventorySystem.Services;

namespace InventorySystem.ConsoleUI;

public class Menu
{
    private readonly Inventory _inventory = new();

    public void Run()
    {
        Console.WriteLine("Inventory CLI: add|list|use|remove|exit");
        while (true)
        {
            Console.Write("> ");
            var line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var cmd = parts[0].ToLower();

            if (cmd == "exit") break;

            switch (cmd)
            {
                case "add":
                    var type = parts.Length > 1 ? parts[1] : "potion";
                    var name = parts.Length > 2 ? string.Join(' ', parts.Skip(2)) : "item";
                    var item = ItemFactory.Create(type, name);
                    _inventory.Add(item);
                    Console.WriteLine($"added {item.Name} ({item.Id})");
                    break;

                case "list":
                    foreach (var it in _inventory.ListAll())
                        Console.WriteLine($"{it.Id}  {it.Name}");
                    break;

                case "remove":
                    if (parts.Length < 2 || !Guid.TryParse(parts[1], out var rid))
                    {
                        Console.WriteLine("usage: remove <guid>");
                        break;
                    }
                    Console.WriteLine(_inventory.Remove(rid) ? "removed" : "not found");
                    break;

                case "use":
                    if (parts.Length < 2 || !Guid.TryParse(parts[1], out var uid))
                    {
                        Console.WriteLine("usage: use <guid>");
                        break;
                    }
                    var target = _inventory.Find(uid);
                    if (target is null) { Console.WriteLine("not found"); break; }
                    Console.WriteLine($"used {target.Name}");
                    // Here you could call IUsable.Use(context)
                    break;

                default:
                    Console.WriteLine("commands: add <type> <name> | list | use <id> | remove <id> | exit");
                    break;
            }
        }
    }
}
