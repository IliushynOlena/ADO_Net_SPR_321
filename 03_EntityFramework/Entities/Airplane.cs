using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_EntityFramework.Entities
{
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]//not null, nvarchar(100)   
        public string Name { get; set; }
        public int MaxPassengers { get; set; }

        //Navigation properties
        //Relationship type : One to Many (1...*)
        public ICollection<Flight> Flights { get; set; }
    }
}
