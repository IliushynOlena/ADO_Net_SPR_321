using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_EntityFramework.Entities
{
    public class Flight
    {
        [Key]//set primary key
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Required, MaxLength(100)]
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        public int? Rating { get; set; }

        //Navigation properties
        //Relationship type : One to Many (1...*)
        public Airplane Airplane { get; set; }
        //Foreign key naming : RelatedEntityName+ RelatedEntityPrimaryKey
        public int AirplaneId { get; set; }
        //Relationship type : Many to Many (*...*)
        public ICollection<Client> Clients { get; set; }
    }
}
