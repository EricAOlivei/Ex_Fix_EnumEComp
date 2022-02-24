using System;
using System.Globalization;
using System.Collections.Generic;
using Ex_Fix_EnumEComp.Entities;
using Ex_Fix_EnumEComp.Entities.Enum;

namespace Ex_Fix_EnumEComp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");

            Console.Write("Name: ");
            string cName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime bDate = DateTime.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Enter order data: ");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(cName, email, bDate);

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Console.Clear();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");

                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.Additem(orderItem);

                Console.WriteLine("---------------------------------");
                Console.WriteLine();
            }

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}