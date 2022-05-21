using System;
using BagelBusiness;
using BagelModels;
using BagelRepository;
using System.Collections;

namespace P1_BagelShop
{
    public class Program
    {
        static BusinessLogic logic = new BusinessLogic();

        public static void Main(string[] args)
        {
            int storeID = 0; 
            //int customerID = 1;
            int productID = 2;
            int productQuantity = 3;
            BagelCustomers newCustomer = new BagelCustomers();
            BagelCustomers loggedInCustomer;

            Console.WriteLine("Welcome to the Big Boi Bagel Shop!");

            //First we will either log-in or register a new user
            bool moveOn = false;
            while (moveOn == false)
            {
                Console.WriteLine("[ENTER 1] Log-in to your Big Boi account\n[ENTER 2] Register as a new customer");
                string loginOrRegister = Console.ReadLine();
                switch (loginOrRegister)
                {
                    case "1": //Logging in to their account
                        Console.WriteLine("Username:");
                        string customerUsername = Console.ReadLine().Trim(); //.Trim() gets rid of white spaces
                        Console.WriteLine("Password:");
                        string customerPassword = Console.ReadLine().Trim();
                        loggedInCustomer = logic.CustomerLogin(customerUsername, customerPassword);
                        if (loggedInCustomer == null)
                        {
                            Console.WriteLine("That was not a valid Username and Password.");
                        } else{
                            Console.WriteLine($"Welcome back {loggedInCustomer.CustomerFName} {loggedInCustomer.CustomerLName}!");
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
                        loggedInCustomer = logic.CustomerRegister(custFName, custLName, custUsername, custPass);
                        if (loggedInCustomer == null)
                        {
                            Console.WriteLine("That customer already exists in the system.");
                        } else{
                            Console.WriteLine($"Thank you for registering {loggedInCustomer.CustomerFName} {loggedInCustomer.CustomerLName}.");
                            moveOn = true;
                        }
                        break;
                    default:
                        Console.WriteLine("That wasn't a valid option. Please try again.");
                        break;
                }
            }
            
            //Choose to create a new order or view a past order
            Console.WriteLine("Would you like to:\n[ENTER 1] Create a new order\n[Enter 2] View your past orders");

            //If they choose to create a new order, then....
            //Choosing which store they want to shop at
            moveOn = false;
            while (moveOn == false)
            {
                Console.WriteLine("Which store would you like to shop at?");
                GetAllStores();
                string storeSelection = Console.ReadLine().Trim();
                switch (storeSelection)
                {
                    case "1":
                        storeID = 5;
                        moveOn = true;
                        break;
                    case "2":
                        storeID = 10;
                        moveOn = true;
                        break;
                    case "3":
                        storeID = 15;
                        moveOn = true;
                        break;
                    case "4":
                        storeID = 20;
                        moveOn = true;
                        break;
                    default:
                        Console.WriteLine("That wasn't a valid option. Please try again.");
                        break;
                }
            }

            //Viewing the products at that chosen store and selecting a product
            Console.WriteLine("Here are the products at that store. Please select your first item to begin your order:");
            GetProductsByStore(storeID);
                                
            //Add product(s) to order & their quantity
            //Need a loop here so they can purchase more than one product...
            logic.AddProductToOrder(productID, productQuantity);
            //Delete a product one at a time
                //list the products. Ask which product they want to delete
            //Press C to checkout

            //Write that order to the Db and update inventory
            //logic.PlaceOrder(storeID, customerID);

            //Would you like to quit -- quit
            //log out -- log them out and loop them up to login screen
            //or choose another store

        }

        //Retrieve store list
        public static void GetAllStores()
        {
            var myStores = logic.GetAllStores();
            int num = 1;
            foreach(var store in myStores)
            {
                Console.WriteLine($"[ENTER {num}] {store.StoreName}, located at: {store.StoreLocation}");
                num++;
            }
        }

        //Retrieve product list
        public static void GetAllProducts()
        {
            var myProducts = logic.GetAllProducts();
            foreach(var product in myProducts)
            {
                Console.WriteLine($"ID- {product.ProductID}, name- {product.ProductName}, price- ${product.ProductPrice}, description- {product.ProductDescription}" );
            }
        }

        public static void GetProductsByStore(int storeID)
        {
            //Retrieve product list by store
            var myProducts = logic.GetProductsByStore(storeID);
            int num = 1;
            foreach(var product in myProducts)
            {
                Console.WriteLine($"[ENTER {num}] {product.ProductName} at ${product.ProductPrice}");
                num++;
            }
        }
    }
}
