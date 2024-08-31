using _03_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _03_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContex contex = new AirplaneDbContex();
            contex.Clients.Add(new Client()
            {
                 Name = "Ivan",
                 Birthdate = new DateTime(2005,5,12),
                 Email = "ivan@gmail.com"
            });
            //contex.SaveChanges();
            foreach (var client in contex.Clients)
            {
                Console.WriteLine($"Client : {client.Name}  " +
                    $"{client.Email} . {client.Birthdate}");
            }

            //Linq 
            //data loading : Include(relation data)
            var filteredArr = contex.Flights
                .Include(f=> f.Airplane)//Join table Airplane
                .Include(f=>f.Clients)//join table Clints
                .Where(f => f.ArrivalCity == "Lviv")
                .OrderBy(f => f.DepartureTime);
            foreach (var f in filteredArr) 
            {
                Console.WriteLine($" {f.DepartureCity} - {f.ArrivalCity}. {f.DepartureTime}\n" +
                    $"Airplane : {f.AirplaneId} . Airpalne model : {f.Airplane?.Name}" +
                    $"\tNumber clients : {f.Clients?.Count}  ");
            }


            //int a = null;
            //int? b = null; 

            //Eplicit data loading : Context.Entry(entity).Collection/Reference.Load();
            
            var client1 = contex.Clients.Find(1);
            contex.Entry(client1).Collection(c => c.Flights).Load();

            Console.WriteLine($"Client : {client1.Name}  " +
                   $"{client1.Email} . {client1.Birthdate} " +
                   $". Client has {client1.Flights.Count} flights");

            foreach (var f in client1.Flights)
            {
                Console.WriteLine($"Arrival city : {f.ArrivalCity} . " +
                    $"Departuew city : {f.DepartureCity} " +
                    $"Depature time {f.DepartureTime}");
            }
            //if (client1 != null)
            //{
            //    contex.Clients.Remove(client1);
            //    contex.SaveChanges();   
            //}


            //foreach (var client in contex.Clients)
            //{
            //    Console.WriteLine($"Client : {client.Name}  " +
            //        $"{client.Email} . {client.Birthdate}");
            //}
        }
    }
}
