using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFramework
{
    public class AirplaneDbContex : DbContext
    {
        public AirplaneDbContex()
        {
            //this.Database.EnsureDeleted();  
            //this.Database.EnsureCreated();  
        }
        /////////////Collections
        //Clients
        //Flights
        //Airplanes
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
                                            

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;
                                        Initial Catalog = AirplaneDb;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initialization
            modelBuilder.Entity<Airplane>().HasData(
               new Airplane[]
               {
                    new Airplane()
                    {
                        Id = 1,
                        Name = "Boeing 747", 
                        MaxPassengers = 1200
                    },
                    new Airplane()
                    {
                        Id = 2,
                        Name = "Boeing 765",
                        MaxPassengers = 500
                    }
               });
            modelBuilder.Entity<Flight>().HasData(
                new Flight[]
                {
                    new Flight()
                    {
                         Number = 1,
                         DepartureTime = new DateTime(2024,08,24),
                         ArrivalTime  = new DateTime(2024,08,24),
                         DepartureCity = "Rivne",
                         ArrivalCity = "Lviv",
                          AirplaneId = 1

                    },
                     new Flight()
                    {
                         Number = 2,
                         DepartureTime = new DateTime(2024,09,24),
                         ArrivalTime  = new DateTime(2024,09,24),
                         DepartureCity = "Odessa",
                         ArrivalCity = "Lviv",
                          AirplaneId = 2
                    },
                      new Flight()
                    {
                         Number = 3,
                         DepartureTime = new DateTime(2024,12,24),
                         ArrivalTime  = new DateTime(2024,12,24),
                         DepartureCity = "Kyiv",
                         ArrivalCity = "Lviv",
                          AirplaneId = 1

                    }
                });
        }


    }
    //Entities
    [Table("Passangers")]
    public class Client
    {
        //Primary Key naming: Id/id/ID/EntityName+ Id
        public int Id { get; set; }
        [Required, MaxLength(100)]//not null, nvarchar(100)   
        [Column("FirstName")]//set column name
        public string Name { get; set; }
        [Required, MaxLength(100)]//not null, nvarchar(100)   
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }//not null ---> null
        //Relationship type : Many to Many (*...*)
        public ICollection<Flight> Flights { get; set; }
    }
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
        //Relationship type : One to Many (1...*)
        public Airplane Airplane { get; set; }
        //Foreign key naming : RelatedEntityName+ RelatedEntityPrimaryKey
        public int AirplaneId { get; set; }
        //Relationship type : Many to Many (*...*)
        public ICollection<Client> Clients { get; set; }
    }
    public class Airplane
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]//not null, nvarchar(100)   
        public string Name { get; set; }
        public int MaxPassengers { get; set; }
        //Relationship type : One to Many (1...*)
        public ICollection<Flight> Flights { get; set; }
    }
}
