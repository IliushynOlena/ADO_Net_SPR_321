using _03_EntityFramework.Entities;
using _03_EntityFramework.Helpers;
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
            //Fluent API
            //  [Required, MaxLength(100)]//not null, nvarchar(100)   
            modelBuilder.Entity<Airplane>()
                .Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>().Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("FirstName");

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Flight>().HasKey(f => f.Number);
            modelBuilder.Entity<Flight>()
                .Property(f => f.DepartureCity)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Flight>()
               .Property(f => f.ArrivalCity)
               .HasMaxLength(100)
               .IsRequired();

            //Relationship Configuration
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(c => c.Flights);

            modelBuilder.Entity<Flight>()
                .HasOne(f=> f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f=> f.AirplaneId);



            //Initialization - Seeder
            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlight();
          
          
        }


    }
}
