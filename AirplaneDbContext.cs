

using _06_02_EntityFramework.Entities;
using _06_02_EntityFramework.Helpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace _06_02_EntityFramework
{
    public class AirplaneDbContext : DbContext
    {
        //Collection
        //Clients
        //Aiplanes
        //Fligths
        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
           this.Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<AirplaneTypes> AirplaneTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-H42B83O\SQLEXPRESS;
                                          Initial Catalog = AirplaneDataBase;
                                          Integrated Security=True;
                                          Connect Timeout=30;
                                          Encrypt=False;
                                          TrustServerCertificate=False;
                                          ApplicationIntent=ReadWrite;
                                          MultiSubnetFailover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //initialization
            modelBuilder.SeedAirplaneTypes();
            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedAirplane();          
            modelBuilder.SeedFlights();
            modelBuilder.SeedClients();
            modelBuilder.SeedAccounts();
            
            



            // Fluent configuration 
            modelBuilder.Entity<Airplane>().Property(a => a.Model).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Client>().ToTable("Passengers");
            modelBuilder.Entity<Client>().Property(c => c.Name).IsRequired().HasMaxLength(150).HasColumnName("FirstName");
            modelBuilder.Entity<Client>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Flight>().HasKey(f => f.Number);
            modelBuilder.Entity<Flight>().Property(f => f.ArrivelCity).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Flight>().Property(f => f.DepartureCity).IsRequired().HasMaxLength(100);
            //Relationship configuration
            modelBuilder.Entity<Client>().HasMany(c => c.Flights).WithMany(f=>f.Clients);
            modelBuilder.Entity<Airplane>().HasMany(a => a.Flights).WithOne(f => f.Airplane).HasForeignKey(f=>f.AirplaneId);

            modelBuilder.Entity<Accounts>().Property(a => a.Password).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Accounts>().Property(a => a.Nickname).HasMaxLength(100).IsRequired();

           // modelBuilder.Entity<Accounts>().HasOne<Client>(a => a.Client).WithOne(c => c.Accounts).HasForeignKey<Client>(c => c.AccountsId);




            modelBuilder.Entity<Countries>().HasMany(c => c.Cities).WithOne(ci => ci.Countries).HasForeignKey(ci => ci.CountriesId);
            modelBuilder.Entity<Cities>().Property(c => c.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cities>().HasMany(c => c.Flight).WithOne(f => f.Cities).HasForeignKey(f => f.CitiesId);

            modelBuilder.Entity<Countries>().Property(c => c.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<AirplaneTypes>().HasMany(at => at.Airplane).WithOne(a => a.AirplaneTypes).HasForeignKey(a => a.AirplaneTypesId);
            modelBuilder.Entity<AirplaneTypes>().Property(at => at.Name).HasMaxLength(50).IsRequired();


        }
    }
}
