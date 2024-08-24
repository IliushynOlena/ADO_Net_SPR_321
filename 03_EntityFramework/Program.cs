using _03_EntityFramework.Entities;
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
                 Name = "Vova",
                 Birthdate = new DateTime(2000,5,12),
                 Email = "vova@gmail.com"
            });
            //contex.SaveChanges();


            foreach (var client in contex.Clients)
            {
                Console.WriteLine($"Client : {client.Name}  " +
                    $"{client.Email} . {client.Birthdate}");
            }

            //Linq 
            var filteredArr = contex.Flights.Where(f => f.ArrivalCity == "Lviv").OrderBy(f => f.DepartureTime);
            foreach (var f in filteredArr) {
                Console.WriteLine($" {f.DepartureCity} - {f.ArrivalCity}. {f.DepartureTime} ");
                    }


            //int a = null;
            //int? b = null; 

            var client1 = contex.Clients.Find(1);
            if (client1 != null)
            {
                contex.Clients.Remove(client1);
                contex.SaveChanges();   
            }


            foreach (var client in contex.Clients)
            {
                Console.WriteLine($"Client : {client.Name}  " +
                    $"{client.Email} . {client.Birthdate}");
            }
        }
    }
}
