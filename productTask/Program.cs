

string[] brands = new string[] { "Apple", "Samsung", "Dell" };
string[] models = new string[] { "iPhone 11", "Galaxy S10", "XPS 15" };
double[] prices = new double[] { 800, 600, 1200 };
int[] quantities = new int[] { 50, 70, 30 };
string[] categories = new string[] { "phone", "phone", "notebook" };

while (true)
{
    Console.Write("1. Show all products \n" +
                  "2. Show products by category \n" +
                  "3. Show total company price \n" +
                  "4. Show total price for category \n" +
                  "5. Add product \n" +
                  "6. Sell product \n" +
                  "7. Exit \n" +
                  "Choose an option: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Clear();
            ShowAllProducts(brands, models, prices, quantities, categories);
            break;

        case 2:
            Console.Clear();
            Console.Write("Enter category (notebook/phone): ");
            string category = Console.ReadLine();
            ShowProductsByCategory(brands, models, prices, quantities, categories, category);
            break;

        case 3:
            Console.Clear();
            ShowTotalCompanyPrice(prices, quantities);
            break;

        case 4:
            Console.Clear();
            Console.Write("Enter category (notebook/phone): ");
            string categoryPrice = Console.ReadLine();
            ShowTotalPriceForCategory(brands, models, prices, quantities, categories, categoryPrice);
            break;

        case 5:
            AddProduct(ref brands, ref models, ref prices, ref quantities, ref categories);
            break;

        case 6:
            Console.Clear();
            SellProduct(ref brands, ref models, ref prices, ref quantities, ref categories);
            break;

        case 7:
            Console.Clear();
            return;

        default:
            Console.Clear();
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}

static void ShowAllProducts(string[] brands, string[] models, double[] prices, int[] quantities, string[] categories)
{
    if (brands.Length == 0)
    {
        Console.WriteLine("No products available.");
    }
    else
    {
        for (int i = 0; i < brands.Length; i++)
        {
            Console.WriteLine($"Brand: {brands[i]} \n" +
                $"Model: {models[i]} \n" +
                $"Price: {prices[i]} \n" +
                $"Quantity: {quantities[i]} \n" +
                $"Category: {categories[i]} \n");
        }
    }
}

static void ShowProductsByCategory(string[] brands, string[] models, double[] prices, int[] quantities, string[] categories, string category)
{
    bool found = false;
    for (int i = 0; i < brands.Length; i++)
    {
        if (categories[i].ToLower() == category.ToLower())
        {
            Console.WriteLine($"Brand: {brands[i]}, " +
                $"Model: {models[i]} \n" +
                $"Price: {prices[i]} \n" +
                $"Quantity: {quantities[i]} \n" +
                $"Category: {categories[i]} \n");
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine($"No products found in {category} category. \n");
    }
}

static void ShowTotalCompanyPrice(double[] prices, int[] quantities)
{
    double total = 0;
    for (int i = 0; i < prices.Length; i++)
    {
        total += prices[i] * quantities[i];
    }
    Console.WriteLine($"Total company price: {total} \n");
}

static void ShowTotalPriceForCategory(string[] brands, string[] models, double[] prices, int[] quantities, string[] categories, string category)
{
    double total = 0;
    for (int i = 0; i < brands.Length; i++)
    {
        if (categories[i].ToLower() == category.ToLower())
        {
            total += prices[i] * quantities[i];
        }
    }
    Console.WriteLine($"Total price for {category}: {total} \n");
}

static void AddProduct(ref string[] brands, ref string[] models, ref double[] prices, ref int[] quantities, ref string[] categories)
{
    Console.Write("Enter brand: ");
    string brand = Console.ReadLine();

    Console.Write("Enter model: ");
    string model = Console.ReadLine();

    Console.Write("Enter price: ");
    double price = double.Parse(Console.ReadLine());

    Console.Write("Enter quantity: ");
    int quantity = int.Parse(Console.ReadLine());

    Console.Write("Enter category (notebooks/phones): ");
    string category = Console.ReadLine();

    Array.Resize(ref brands, brands.Length + 1);
    Array.Resize(ref models, models.Length + 1);
    Array.Resize(ref prices, prices.Length + 1);
    Array.Resize(ref quantities, quantities.Length + 1);
    Array.Resize(ref categories, categories.Length + 1);

    brands[brands.Length - 1] = brand;
    models[models.Length - 1] = model;
    prices[prices.Length - 1] = price;
    quantities[quantities.Length - 1] = quantity;
    categories[categories.Length - 1] = category;

    Console.WriteLine("Product added successfully. \n");
}

static void SellProduct(ref string[] brands, ref string[] models, ref double[] prices, ref int[] quantities, ref string[] categories)
{
    Console.Write("Enter the brand of the product to sell: ");
    string brand = Console.ReadLine();

    Console.Write("Enter the model of the product to sell: ");
    string model = Console.ReadLine();

    for (int i = 0; i < brands.Length; i++)
    {
        if (brands[i].ToLower() == brand.ToLower() && models[i].ToLower() == model.ToLower())
        {
            Console.Write("Enter quantity to sell: ");
            int sellQuantity = int.Parse(Console.ReadLine());

            if (sellQuantity <= quantities[i])
            {
                quantities[i] -= sellQuantity;
                Console.WriteLine("Product sold successfully.");

                if (quantities[i] == 0)
                {
                    RemoveProduct(ref brands, ref models, ref prices, ref quantities, ref categories, i);
                    Console.WriteLine("Product is out of stock and removed from inventory.");
                }
                return;
            }
            else
            {
                Console.WriteLine("Not enough quantity available.");
                return;
            }
        }
    }

    Console.WriteLine("Product not found.");
}

static void RemoveProduct(ref string[] brands, ref string[] models, ref double[] prices, ref int[] quantities, ref string[] categories, int index)
{
    for (int i = index; i < brands.Length - 1; i++)
    {
        brands[i] = brands[i + 1];
        models[i] = models[i + 1];
        prices[i] = prices[i + 1];
        quantities[i] = quantities[i + 1];
        categories[i] = categories[i + 1];
    }
    Array.Resize(ref brands, brands.Length - 1);
    Array.Resize(ref models, models.Length - 1);
    Array.Resize(ref prices, prices.Length - 1);
    Array.Resize(ref quantities, quantities.Length - 1);
    Array.Resize(ref categories, categories.Length - 1);
}
