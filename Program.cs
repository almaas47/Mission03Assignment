// Matthew Diamond
// Section 003
// This program shows a menu to add, print, and delete food items, and allows user to exit

// foodItem1 = [Name, Category, Quantity, Expiration Date]

using Mission03Assignment;

// Prompt Menu to User
class Program
{
    // Make invenetory visible for all methods
    static List<FoodItem> inventory = new List<FoodItem>();

    static void Main(string[] args)
    {   // Loop through to show menu
        while (true)
        {
            Console.WriteLine("Food Bank Inventory");
            Console.WriteLine("1 - Add Food Item");
            Console.WriteLine("2 - Print Food Item List");
            Console.WriteLine("3 - Delete Food Item");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter your choice (number only): ");

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                Exit();
            }
            else if (choice == "1")
            {
                AddFoodItem();
            }
            else if (choice == "2")
            {
                PrintInventory();
            }
            else if (choice == "3")
            {
                DeleteInventory();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    // Create Add Food Items method
    static void AddFoodItem()
    {
        Console.Write("Enter food item name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the category: ");
        string category = Console.ReadLine();

        Console.Write("Enter the quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            return;
        }

        Console.Write("Enter the expiration date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
        {
            Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            return;
        }

        FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
        inventory.Add(newItem);

        Console.WriteLine("Food item added successfully!");
    }

// Print List of Current Food Items
    static void PrintInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("The inventory is empty.");
            return;
        }

        Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine(item); // Calls FoodItem.ToString()
        }

        Console.WriteLine(); // Blank line for better readability
    }

    // Create Delete Food Items method
    static void DeleteInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("The inventory is empty. Nothing to delete.");
            return;
        }

        Console.Write("Enter the name of the food item to delete: ");
        string nameToDelete = Console.ReadLine();

        var item = inventory.FirstOrDefault(i => i.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            inventory.Remove(item);
            Console.WriteLine($"Food item '{nameToDelete}' has been removed.");
        }
        else
        {
            Console.WriteLine($"Food item '{nameToDelete}' not found in the inventory.");
        }
    }
    
    // Exit the Program Method
    static void Exit()
    {
        Console.WriteLine("Exiting program. Goodbye!");
        Environment.Exit(0);
    }

}