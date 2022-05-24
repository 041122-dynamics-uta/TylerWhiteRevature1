using System;
using BagelBusiness;
using BagelModels;
using BagelRepository;
using System.Collections;
using System.Collections.Generic;

namespace P1_BagelShop
{
    public class Program
    {
        //make the instances of other classes "private" because only this class needs to use these objects
        private static BusinessLogic _logic = new BusinessLogic();

        public static void Main(string[] args)
        {
            Console.WriteLine("\n\n**************************************");
            Console.WriteLine("* Welcome to the Big Boi Bagel Shop! *");
            Console.WriteLine("**************************************\n");

            //First we will either log-in or register a new user
            bool moveOn = false;
            while (moveOn == false)
            {
                Console.WriteLine("[ENTER 1] Log-in to your Big Boi account\n[ENTER 2] Register as a new customer\n[Enter 3] Quit");
                string loginOrRegister = Console.ReadLine();
                switch (loginOrRegister)
                {
                    case "1": //Logging in to their account
                        Console.WriteLine("Username:");
                        string customerUsername = Console.ReadLine().Trim(); //.Trim() gets rid of white spaces

                        Console.WriteLine("Password:");
                        string customerPassword = Console.ReadLine().Trim();
                        
                        //if statement to check if the customer entered a username/password that is valid or not
                        _logic.CustomerLogin(customerUsername, customerPassword);
                        if (_logic.LoggedInCustomer == null)
                        {
                            Console.WriteLine("That was not a valid Username and Password.");
                        } else{
                            Console.WriteLine($"Welcome back {_logic.LoggedInCustomer.CustomerFName} {_logic.LoggedInCustomer.CustomerLName}!\n");
                            moveOn = true;
                        }
                        break;
                    case "2": //New User registration
                        Console.WriteLine("Please enter your first name:");
                        string custFName = Console.ReadLine().Trim();
                        Console.WriteLine("Please enter your last name:");
                        string custLName = Console.ReadLine().Trim();
                        Console.WriteLine("Please enter a Username:");
                        string custUsername = Console.ReadLine().Trim();
                        Console.WriteLine("Please enter a Password:");
                        string custPass = Console.ReadLine().Trim();
                        _logic.CustomerRegister(custFName, custLName, custUsername, custPass);

                        //if statement to check if the customer already exists or not
                        if (_logic.LoggedInCustomer == null)
                        {
                            Console.WriteLine("That customer already exists in the system.");
                        } else{
                            Console.WriteLine($"Thank you for registering {_logic.LoggedInCustomer.CustomerFName} {_logic.LoggedInCustomer.CustomerLName}.\n");
                            moveOn = true;
                        }
                        break;
                    case "3":
                        Quit();
                        break;
                    default:
                        Console.WriteLine("That wasn't a valid option. Please try again.\n");
                        break;
                }
            }
            
            //Choose to create a new order or view a past order
            moveOn = false;
            while (moveOn == false)
            {
                
                Console.WriteLine("Would you like to:\n[ENTER 1] Create a new order\n[Enter 2] View your past orders");

                string newOrPastOrder = Console.ReadLine().Trim();
                switch (newOrPastOrder)
                {
                    case "1":
                        AskCustomerToPlaceOrder();
                        moveOn = true;
                        break;
                    case "2":
                        GetPastOrders(_logic.LoggedInCustomer);
                        moveOn = true;
                        break;
                    default:
                        Console.WriteLine("That wasn't a valid option. Please try again.\n");
                        break;
                }
            }
        }

        private static void AskCustomerToPlaceOrder()
        {
            //If they choose to create a new order, then....
            //Choosing which store they want to shop at
            BagelStores store = StoreSelection();

            //Retrieve product list by store
            var myProducts = _logic.GetProductsByStore(store.StoreID);
            bool shouldCheckout = AddProductsToOrder(myProducts);
            if (shouldCheckout)
            {
                //Write that order to the Db and update inventory
                _logic.PlaceOrder(store);
                Console.WriteLine("Order Successfully Placed!!");
                Console.WriteLine("Thank you, please visit us again soon.");
            }
        }

        public static BagelStores StoreSelection()
        {
            bool moveOn = false;
            var myStores = _logic.GetAllStores();
            while (moveOn == false)
            {
                Console.WriteLine("Which store would you like to shop at? (Please enter the store number)");
                foreach(var store in myStores)
                {
                    Console.WriteLine($"\nStore #{store.StoreID} -- {store.StoreName}\nLocated at: {store.StoreLocation}");
                }
                string storeSelection = Console.ReadLine().Trim();
                bool isValidStore = int.TryParse(storeSelection, out int storeId);

                foreach(var store in myStores)
                {
                    if (storeId == store.StoreID)
                    {
                        Console.WriteLine($"\n**Thank you for choosing the {store.StoreName}**");
                        return store;
                    }
                }

                Console.WriteLine("That wasn't a valid option. Please try again.\n");
                continue;
            }
            // This should never be hit
            throw new Exception("SERIOUSLY BROKE - WHAT DID WE DO");
        }

        /// <summary>
        /// Selecting a product and add to order
        /// </summary>
        /// <param name="products"></param>
        /// <returns>true to checkout, false to quit</returns>
        private static bool AddProductsToOrder(List<BagelProducts> products)
        {
            string expectedFormat = "'Product Number','Quantity'";
            bool moveOn = true;
            while (moveOn)
            {
                //Viewing the products at that chosen store and selecting a product
                Console.WriteLine("Available products below, select a product and quantity to add it to your cart.");
                Console.WriteLine($"Use the format: {expectedFormat} to add an item to your order.\n");
                foreach(var displayProduct in products)
                {
                    Console.WriteLine($"Product #{displayProduct.ProductID}-- Name: {displayProduct.ProductName} - Cost: ${displayProduct.ProductPrice}");
                    Console.WriteLine($"Description: {displayProduct.ProductDescription}\n");
                }

                //Evaluating input
                string produtOrderInput = Console.ReadLine().Trim();
                var input = produtOrderInput.Split(',');
                if (input.Length != 2)
                {
                    Console.WriteLine($"That wasn't a valid option. Please try again. Expecting format {expectedFormat}\n");
                    continue;
                }
                var isWorkingProduct = int.TryParse(input[0].Trim(), out int productId);
                var isWorkingQuantity = int.TryParse(input[1].Trim(), out int quantity);
                if(isWorkingProduct && isWorkingQuantity)
                {
                    bool foundProduct = false;
                    foreach(var bagelProduct in products)
                    {
                        if (productId == bagelProduct.ProductID)
                        {
                            _logic.AddProductToOrder(bagelProduct, quantity);
                            foundProduct  = true;
                            break;
                        }
                    }
                    if (!foundProduct)
                    {
                        Console.WriteLine("Invalid product input, try again\n");
                        continue;
                    }
                    // Add product(s) to order & their quantity
                    Console.WriteLine($"[ENTER 1] Buy another product?\n[ENTER 2] Checkout\n[ENTER 3] Quit");
                    var userInput = Console.ReadLine().Trim();
                    switch(userInput)
                    {
                        case "1":
                            Console.WriteLine("Go ahead - buy another!");
                            moveOn = true;
                            break;
                        case "2":
                        Console.WriteLine("Checking out...");
                            return true;
                        case "3":
                            Console.WriteLine("Order cancelled, have a nice day.");
                            Quit();
                            return false;
                    }
                }
                else
                {
                    Console.WriteLine($"That wasn't a valid option, please try again. Expecting format {expectedFormat}\n");                    
                }
            }
            return false;
        }

        //Simple method to quit
        public static void Quit(){
            Environment.Exit(0);
        }
        
        //Past orders
        public static void GetPastOrders(BagelCustomers loggedInCustomer)
        {
            List<BagelOrderView> myOrders = _logic.GetPastOrders(loggedInCustomer);
            int num = 1;

            Dictionary<Guid, List<BagelOrderView>> ordersGrouped = new Dictionary<Guid, List<BagelOrderView>>();
            foreach(var order in myOrders)
            {
                if (ordersGrouped.ContainsKey(order.OrderID))
                {
                    ordersGrouped[order.OrderID].Add(order);
                }
                else
                {
                    List<BagelOrderView> newView = new List<BagelOrderView>();
                    newView.Add(order);
                    ordersGrouped.Add(order.OrderID, newView);
                }
            }
            //formatting and displaying a past order
            foreach(var orderId in ordersGrouped.Keys)
            {
                var currentOrder = ordersGrouped[orderId][0];
                num = 1;
                Console.WriteLine();
                Console.WriteLine($"Order: {orderId}");
                Console.WriteLine($"===========================================================");
                Console.WriteLine($"Total order cost: ${currentOrder.TotalOrderSum}");
                Console.WriteLine($"Order date: {currentOrder.DateCreated}");
                Console.WriteLine($"Store: {currentOrder.StoreName}");
                Console.WriteLine($"Store Location: {currentOrder.StoreLocation}");

                foreach(var order in ordersGrouped[orderId])
                {
                    Console.WriteLine($"Product {num} -- {order.ProductName}");
                    Console.WriteLine($"\tPurchased: {order.ProductQuantity} @ {order.ProductPrice}");
                    num++;
                }
                Console.WriteLine($"===========================================================");
                Console.WriteLine();
            }
        }
        //Retrieve product list, not needed
/*         public static void GetAllProducts()
        {
            var myProducts = logic.GetAllProducts();
            foreach(var product in myProducts)
            {
                Console.WriteLine($"ID- {product.ProductID}, name- {product.ProductName}, price- ${product.ProductPrice}, description- {product.ProductDescription}" );
            }
        } */

    }
}
