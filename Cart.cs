using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_InternShip
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        public void Add(Product product, int quantity)
        {
            if (quantity > product.Quantity)
            {
                throw new Exception("Quantity not available in  stock.");
            }
            items.Add(new CartItem { Product = product, Quantity = quantity });
            product.Quantity -= quantity;
        }
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (var CartItems in items)
            {
                totalPrice += CartItems.Product.Price * CartItems.Quantity;
            }
            return totalPrice;
        }
        public List<CartItem> GetShippableItems()
        {
            return items.FindAll(item => item.Product.IsShippable);
        }

        public bool IsEmpty() => items.Count == 0;
    }
}
