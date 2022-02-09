
bool runProgram = true;
while (runProgram)
{

    //Dictionary of available items and prices
    Dictionary<string, double> menu = new Dictionary<string, double>()
    {
        ["Bird of Paradise"] = 29.50,
        ["Bamboo Palm"] = 27.50,
        ["Chinese Evergreen"] = 49.50,
        ["Dracaena"] = 19.50,
        ["Foxtail Fern"] = 45.00,
        ["Money Tree"] = 35.00,
        ["Monstera Deliciosa"] = 29.50,
        ["String of Pearls"] = 29.50,
    };

    //displaying the Dictionary
    foreach (KeyValuePair<string, double> item in menu)
    {
        Console.WriteLine(String.Format("{0,-25} {1,25}", item.Key, item.Value));
    }
    Console.WriteLine();

    //Shopping List & Price List
    List<string> shoppingList = new List<string>();
    List<double> shoppingListPrices = new List<double>();

    while (runProgram)
    {
        //asking user for Input

        Console.WriteLine("What plant would you like to buy?");
        string selectedItem = Console.ReadLine();
        Console.WriteLine();
        //take item input & respond if it doesnt exist & add its name + Price to the relevant list if it does
        if (menu.ContainsKey(selectedItem))
        {
            Console.WriteLine($"Adding {selectedItem} to cart at ${menu[selectedItem]}");//why does [selected item] pull the price
            shoppingList.Add(selectedItem);
            shoppingListPrices.Add(menu[selectedItem]);
        }
        else
        {
            Console.WriteLine("That plant is not available. Your options are: ");
            Console.WriteLine();
            break;
        }
        while(true)
        {
            Console.WriteLine("Would you like to add anymore plants to your order? (y/n)");
            string userChoice = Console.ReadLine();
            if (userChoice == "y")
            {
                break;
            }
            else if (userChoice == "n")
            {
                //Display and add up the users entire cart
                Console.WriteLine("Thank you for your order!");
                Console.WriteLine("Here is what your got:");
                for (int i = 0; i < shoppingList.Count; i++)
                {
                    Console.WriteLine(String.Format("{0,-25} {1,25}", shoppingList[i], "$" + shoppingListPrices[i]));
                }
                double cartTotal = shoppingListPrices.Sum();
                Console.WriteLine(String.Format("{0,-25} {1,22} {2,-15}", "Your order total is", "$", cartTotal));
                double mostExpensive = shoppingListPrices.Max();
                double leastExpensive = shoppingListPrices.Min();
                Console.WriteLine($"The least expensive item in your cart is\t${leastExpensive}");
                Console.WriteLine($"The most expensive item in your cart is \t${mostExpensive}");

                runProgram = false;
                break;
            }
            else
            {
                Console.WriteLine("That was not a valid option.");
            }
        }
    }

}

