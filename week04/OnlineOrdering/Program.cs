using System;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Dallas", "TX", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A1", 900, 1));
        order1.AddProduct(new Product("Mouse", "B2", 25, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order1.GetTotalPrice()}");
        Console.WriteLine();

        Address address2 = new Address("45 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Maria Lopez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "C3", 600, 1));
        order2.AddProduct(new Product("Case", "D4", 30, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order2.GetTotalPrice()}");
    }
}
