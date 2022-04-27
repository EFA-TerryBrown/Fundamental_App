using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly CustomerRepository _cRepo = new CustomerRepository();

    public void Run()
    {
        Seed();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            System.Console.WriteLine("Welcome to The Program\n" +
            "1. Add Customer To Database\n" +
            "2. Get Customer\n" +
            "3. Get All Customers\n" +
            "4. Close Application\n");

            try
            {
                var userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {

                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        GetCustomer();
                        break;
                    case 3:
                        GetCustomers();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                System.Console.WriteLine($"This failed: {ex}");
                System.Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

            Console.Clear();
        }
    }

    private void GetCustomers()
    {
        Console.Clear();
        var customers = _cRepo.GetCustomers();

        foreach (var customer in customers)
        {
            System.Console.WriteLine($"CustomerID: {customer.ID}\n" +
            $"{customer.Name}\n");
        }

        Console.ReadKey();
    }

    private void DisplayCustomerData(Customer customer, int orderIndex) //doing this b/c NO orderRepository exists
    {
        try
        {
            System.Console.WriteLine($"ID: {customer.ID}\nName: {customer.Name}\n" + "--------- Orders ------------\n");

            System.Console.WriteLine($"OrderID: {customer.Orders[orderIndex].ID}\n" +
            $"------------ Ordered Items ------------------\n");

            foreach (var item in customer.Orders[orderIndex].StoreItems)
            {
                System.Console.WriteLine($"ItemID: {item.ID}\n" +
                $"ItemName: {item.Name}\n" +
                $"ItemPrice: {item.Price}");
            }

            System.Console.WriteLine("------------- Total Cost ----------------");
            System.Console.WriteLine(customer.Orders[orderIndex].TotalCost);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Sorry it doesn't work because: {ex}");
        }
    }

    private void GetCustomer()
    {
        Console.Clear();
        System.Console.WriteLine("Please input a valid CustomerID:");
        int customerID = int.Parse(Console.ReadLine());

        var customer = _cRepo.GetCustomer(customerID);
        if (customer != null)
        {
            Console.Clear();
            System.Console.WriteLine("Please enter the order index:");
            var orderIndex = int.Parse(Console.ReadLine());
            DisplayCustomerData(customer, orderIndex);
        }
        else
        {
            System.Console.WriteLine("Sorry customer doesn't exist!");
        }

        System.Console.WriteLine("Press any Key to Continue.");
        Console.ReadKey();
    }

    private void AddCustomer()
    {
        Console.Clear();
        var customer = new Customer();
        System.Console.WriteLine("Please input The Customers Name:");
        customer.Name = Console.ReadLine();

        System.Console.WriteLine("Do you want to make an order? y/n");
        var userInput = Console.ReadLine();

        if (userInput == "Y".ToLower())
        {
            //make this order and then assign it
            // to the customer.Orders.Add(order)
            var order = new Order();
            bool hasAddedAllItems = false;
            while (!hasAddedAllItems)
            {
                var storeItem = new StoreItem();
                System.Console.WriteLine("What is the Item Name?");
                storeItem.Name = Console.ReadLine();

                System.Console.WriteLine("What is the Item Price?");
                storeItem.Price = Convert.ToDecimal(Console.ReadLine());

                //adding the storeItem to the order obj
                order.StoreItems.Add(storeItem);

                System.Console.WriteLine("Do you want to add another Item? y/n");
                userInput = Console.ReadLine();
                if (userInput == "Y".ToLower())
                {

                    continue;
                }
                else
                {
                    hasAddedAllItems = true;
                }
            }
            customer.Orders.Add(order);

            var success = _cRepo.AddToDatabase(customer);
            if (success)
                System.Console.WriteLine("SUCCESS");
            else
                System.Console.WriteLine("FAIL");
        }
        else
        {
            System.Console.WriteLine("Customer Created w/o any Orders!!!");
        }

        Console.ReadKey();
    }

    private void Seed()
    {
        Customer customerA = new Customer("Jack",
        new List<Order>
        {
           new Order(new List<StoreItem>  //index 0
           {
               new StoreItem("Tooth Paste",3.00M),
               new StoreItem("Bread",2.50M),
               new StoreItem("PS5",500.50M)
           }),
            new Order(new List<StoreItem> //index 1
           {
               new StoreItem("Dortios",5.80M),
               new StoreItem("Bread",2.50M),
               new StoreItem("PSOne",100.50M),
           })
        });

        Customer customerB = new Customer("Dexter",
        new List<Order>
        {
           new Order(new List<StoreItem>
           {
               new StoreItem("Dortios",5.80M),
               new StoreItem("Bread",2.50M),
               new StoreItem("XBox360",100.50M),
           })

        });

        _cRepo.AddToDatabase(customerA);
        _cRepo.AddToDatabase(customerB);

    }
}
