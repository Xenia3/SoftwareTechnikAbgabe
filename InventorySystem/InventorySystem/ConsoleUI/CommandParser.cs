namespace InventorySystem.ConsoleUI;

public static class CommandParser
{
    public static (string Command, string[] Args) Parse(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return ("", Array.Empty<string>());

        var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var cmd = parts[0].ToLowerInvariant();
        var args = parts.Skip(1).ToArray();
        return (cmd, args);
    }
}