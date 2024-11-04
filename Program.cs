using System;

namespace Fawry_Quantum_InternShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product cheese = new Product { Name = "Cheese", Price = 100, Quantity = 10, IsShippable = true, Weight = 0.4 };
            Product biscuits = new Product { Name = "Biscuits", Price = 75, Quantity = 5, IsShippable = true, Weight = 0.7 };
            Product tv = new Product { Name = "TV", Price = 2000, Quantity = 2, IsShippable = true, Weight = 15.0 };
            Product mobileScratchCard = new Product { Name = "Mobile Scratch Card", Price = 50, Quantity = 20, IsShippable = false };

            //Customer customer = new Customer { Name = "Marwan Mohamed", Balance = 500 };
            Customer customer = new Customer { Name = "Marwan Mohamed", Balance = 400000};
            Cart cart = new Cart();

            try
            {
                cart.Add(cheese, 2);
                cart.Add(biscuits, 1);
                cart.Add(tv, 1);

                if (cart.IsEmpty())
                {
                    Console.WriteLine("Cart is empty.");
                    return;
                }

                double productTotalPrice = cart.GetTotalPrice();
                double shippingFees = 50; 
                double totalAmount = productTotalPrice + shippingFees;

                if (customer.Balance < totalAmount)
                {
                    Console.WriteLine("Can not handle the balance.");
                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                    return;
                }

                customer.Balance -= totalAmount;

                Console.WriteLine("** Checkout Receipt **");
                foreach (var item in cart.GetShippableItems())
                {
                    Console.WriteLine($"{item.Quantity}x {item.Product.Name,-20} {item.Product.Price * item.Quantity:C}");
                }
                Console.WriteLine("----------------------");
                Console.WriteLine($"Subtotal         {productTotalPrice:C}");
                Console.WriteLine($"Shipping         {shippingFees:C}");
                Console.WriteLine($"Total Amount     {totalAmount:C}");
                Console.WriteLine($"Remaining Balance {customer.Balance:C}");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }

          
        }

    }
}
