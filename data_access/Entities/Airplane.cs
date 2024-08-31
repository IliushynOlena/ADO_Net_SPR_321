using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_EntityFramework.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxPassengers { get; set; }

        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}
