using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Quantum_InternShip
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsShippable { get; set; }
        public double Weight { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public bool IsExpired()
        {
            if (ExpirationDate.HasValue) // <----Check if there is an expiration date
            {
                return DateTime.Now > ExpirationDate.Value; // Compare current date with expiration date
            }
            return false; // If no expiration date, it's not expired
        }


    }


}
