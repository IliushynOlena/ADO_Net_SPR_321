using _03_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFramework.Helpers
{
    public static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder) {
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
        }
        public static void SeedFlight(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Flight>().HasData((
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
                  }));
        }  
    }
}
