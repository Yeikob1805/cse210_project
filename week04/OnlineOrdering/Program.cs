using System;

List<Product> products1 = new List<Product>
{
    new Product("Laptop", "P100", 850, 1),
    new Product("Wireless Mouse", "P101", 25, 2),
    new Product("Keyboard", "P102", 45, 1)
};

Customer customer1 = new Customer(
    "Jose Smith",
    new Address("123 Main St", "Dallas", "Texas", "USA")
);

Order order1 = new Order(customer1, products1);

List<Product> products2 = new List<Product>
{
    new Product("Monitor", "P200", 300, 2),
    new Product("Headphones", "P201", 80, 1)
};

Customer customer2 = new Customer(
    "Maria Lopez",
    new Address("Ave Dominicos", "Lima", "Lima", "Peru")
);

Order order2 = new Order(customer2, products2);

List<Order> orders = new List<Order> { order1, order2 };

foreach (Order order in orders)
{
    Console.WriteLine("PACKING LABEL");
    Console.WriteLine(order.GetPackingLabel());

    Console.WriteLine();
    Console.WriteLine("SHIPPING LABEL");
    Console.WriteLine(order.GetShippingLabel());

    Console.WriteLine();
    Console.WriteLine($"Total Price: ${order.GetTotalCost()}");
    Console.WriteLine("----------------------------------------");
}