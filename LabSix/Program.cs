
bool runProgram = true;
while (runProgram)
{

    //Dictionary of available items and prices
    Dictionary<string, decimal> menu = new Dictionary<string, decimal>()
    {
        ["Bird of Paradise"] = 29.50M,
        ["Bamboo Palm"] = 27.50M,
        ["Chinese Evergreen"] = 49.50M,
        ["Dracaena"] = 19.50M,
        ["Foxtail Fern"] = 45.00M,
        ["Money Tree"] = 35.00M,
        ["Monstera Deliciosa"] = 29.50M,
        ["String of Pearls"] = 29.50M,
    };

    //Shopping List & Price List
    List<string> shoppingList = new List<string>();
    List<decimal> shoppingListPrices = new List<decimal>();//do not need this if you call out from dictionary

    //displaying the Dictionary
    foreach (KeyValuePair<string, decimal> item in menu)
    {
        Console.WriteLine(String.Format("{0,-25} {1,25} {2,-25}", item.Key, "$", item.Value));
    }
    Console.WriteLine();


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
                decimal cartTotal = shoppingListPrices.Sum();
                Console.WriteLine(String.Format("{0,-25} {1,22} {2,-15}", "Your order total is", "$", cartTotal));
                decimal avgPriceofCart = shoppingListPrices.Average();
                decimal mostExpensive = shoppingListPrices.Max();
                decimal leastExpensive = shoppingListPrices.Min();
                Console.WriteLine($"The Average price per item in your order was: \t${avgPriceofCart}");
                Console.WriteLine($"The least expensive item in your cart is:\t${leastExpensive}");
                Console.WriteLine($"The most expensive item in your cart is: \t${mostExpensive}");

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

