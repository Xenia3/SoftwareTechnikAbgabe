# SoftwareTechnikAbgabe
About: Modular console inventory with add, list, use, remove in C#

Topic: Inventory Management

Scope:
- Add, list, use, remove items
- Visualised in console

Commit Message Guidelines:
  - type: one of: feat, fix, refactor, test, docs, style, ci and others
  - subject: imperative, less than 50 characters
  - body: what &/or why, about 100 characters, bullet points allowed

Naming Conventions:

  - PascalCase: Namespaces, Classes, Interfaces, Enums, Methods, Properties, Constants
  - camelCase with _: Variables (local), Fields (private)

Formatting:
- Indentation: 4 spaces (no tabs)
- Braces: always on a new line (Allman style, C# default)
- Blank lines: 1 blank line between methods
- No unnecessary blank lines inside a method
- Usings: System namespaces first, then others 
- File = Class: one class per file, filename = class name
- Comments: // for inline or short omments

Folder Structure:
InventorySystem/                      
   InventorySystem/                   
         ConsoleUI/
         CommandParser.cs
         ConsoleInventoryContext.cs
         Menu.cs
      Interfaces/
         IInventoryContext.cs
         IItemFactory.cs
         IUsable.cs
      Models/
         ConsumableItem.cs
         EquipmentItem.cs
         Item.cs
      Services/
         DefaultItemFactory.cs
         Inventory.cs
         ItemFactory.cs
      Program.cs
  InventorySystem.Tests/             
      Console/
         CommandParserTests.cs
      Services/
         InventoryTests.cs
      TestDoubles/
         FakeInventoryContext.cs
