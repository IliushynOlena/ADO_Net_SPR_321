using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _03_EntityFramework.Entities
{
    //Entities
    [Table("Passangers")]
    public class Client
    {
        //Primary Key naming: Id/id/ID/EntityName+ Id
        public int Id { get; set; }
        [Required, MaxLength(100)]//not null, nvarchar(100)   
        [Column("FirstName")]//set column name
        public string Name { get; set; }
        [Required, MaxLength(150)]//not null, nvarchar(100)   
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }//not null ---> null


        //Navigation properties
        //Relationship type : Many to Many (*...*)
        public ICollection<Flight> Flights { get; set; }
    }
}
