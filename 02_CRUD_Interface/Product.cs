using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CRUD_Interface
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Producer { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $" {Name,-15}  {CostPrice,-15}  {Producer,-15}";
        }
    }
}
