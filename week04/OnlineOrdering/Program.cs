
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ONLINE ORDERING SYSTEM ===\n");
        Console.WriteLine("Creating orders...\n");

        // 1. Create Address objects
        Console.WriteLine("Step 1: Creating Addresses");
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("789 Pine Rd", "Los Angeles", "CA", "USA");

        Console.WriteLine($"- Address 1: {address1.GetFullAddress()}");
        Console.WriteLine($"- Address 2: {address2.GetFullAddress()}");
        Console.WriteLine($"- Address 3: {address3.GetFullAddress()}\n");

        // 2. Create Customer objects
        Console.WriteLine("Step 2: Creating Customers");
        Customer customer1 = new Customer("John Clark", address1);
        Customer customer2 = new Customer("Maria Santos", address2);
        Customer customer3 = new Customer("Robert Patinson", address3);

        Console.WriteLine($"- Customer 1: {customer1.GetCustomerInfo()}");
        Console.WriteLine($"- Customer 2: {customer2.GetCustomerInfo()}");
        Console.WriteLine($"- Customer 3: {customer3.GetCustomerInfo()}\n");

        // 3. Create Product objects
        Console.WriteLine("Step 3: Creating Products");
        Product product1 = new Product("Laptop", "P001", 999.99m, 1);
        Product product2 = new Product("Wireless Mouse", "P002", 29.99m, 2);
        Product product3 = new Product("Keyboard", "P003", 59.99m, 1);
        Product product4 = new Product("Monitor", "P004", 249.99m, 1);
        Product product5 = new Product("USB Cable", "P005", 9.99m, 3);

        Console.WriteLine($"- Product 1: {product1.GetProductInfo()} - ${product1.GetTotalCost():F2}");
        Console.WriteLine($"- Product 2: {product2.GetProductInfo()} - ${product2.GetTotalCost():F2}");
        Console.WriteLine($"- Product 3: {product3.GetProductInfo()} - ${product3.GetTotalCost():F2}");
        Console.WriteLine($"- Product 4: {product4.GetProductInfo()} - ${product4.GetTotalCost():F2}");
        Console.WriteLine($"- Product 5: {product5.GetProductInfo()} - ${product5.GetTotalCost():F2}\n");

        // 4. Create Order objects
        Console.WriteLine("Step 4: Creating Orders\n");

        // Order 1: John Smith (USA customer)
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);  // Laptop
        order1.AddProduct(product2);  // Mouse (2x)
        order1.AddProduct(product3);  // Keyboard

        // Order 2: Maria Garcia (International customer)
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);  // Monitor
        order2.AddProduct(product5);  // USB Cable (3x)

        // Order 3: Robert Johnson (USA customer)
        Order order3 = new Order(customer3);
        order3.AddProduct(product1);  // Laptop
        order3.AddProduct(product4);  // Monitor

        // 5. Display Order Information
        List<Order> orders = new List<Order> { order1, order2, order3 };
        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"ORDER #{orderNumber}");
            Console.WriteLine(new string('=', 50));

            // Display shipping label
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            // Display packing label
            Console.WriteLine(order.GetPackingLabel());

            // Display order summary
            Console.WriteLine(order.GetOrderSummary());

            orderNumber++;
            Console.WriteLine();
        }

        // 6. Display Final Summary
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("FINAL SUMMARY");
        Console.WriteLine(new string('=', 50));

        decimal totalAllOrders = 0;
        int usaOrders = 0;
        int internationalOrders = 0;

        foreach (Order order in orders)
        {
            totalAllOrders += order.CalculateTotalCost();
            if (order.GetOrderSummary().Contains("Shipping to USA: Yes"))
                usaOrders++;
            else
                internationalOrders++;
        }

        Console.WriteLine($"Total Orders: {orders.Count}");
        Console.WriteLine($"USA Orders: {usaOrders}");
        Console.WriteLine($"International Orders: {internationalOrders}");
        Console.WriteLine($"Total Revenue: ${totalAllOrders:F2}");

        Console.WriteLine("\nProgram completed. Press any key to exit...");
        Console.ReadKey();
    }
}