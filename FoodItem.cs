namespace Mission03Assignment;

// Program to create variables and store the values
internal class FoodItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    // Create the constructor to initialize food item
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    // return the information of fooditem
    public override string ToString()
    {
        return $"{Name} | {Category} | {Quantity} units | Exp. {ExpirationDate:yyyy-MM-dd}";
    }
}