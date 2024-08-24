using _03_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
            //Initialization - Seeder
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
}
