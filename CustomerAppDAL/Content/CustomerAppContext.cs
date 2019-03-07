using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Content
{
    //DbContent is a way to manage database which can be founded in entinty framework
    //DbContext is the superclass, while InMemoryContext is the subclass
    public class CustomerAppContext : DbContext
    {
        //code to connect our code with in memory database
        static DbContextOptions<CustomerAppContext> options =
            new DbContextOptionsBuilder<CustomerAppContext>()
                .UseInMemoryDatabase("TheDB")
                .Options;


        //using a function inside the superclass - COMMENT THIS FUNCTION WHEN YOU CONNECT WITH DATABASE
        public CustomerAppContext() : base(options)
        { }

        /*THIS IS FOR DATABASE CONNECTION - UNCOMMENT WHEN CONNECTING WITH A DATABASE
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"");     //User your connection string code
            }     
        }*/


        //here we will write all database modeling
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create the primary key for our CustomerAddress table by combining AddressId and CustomerId
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new { ca.AddressId, ca.CustomerId });

            //CustomerAddress to the Address
            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customer)
                .HasForeignKey(ca => ca.AddressId);

            //CustomerAddress to the Customer
            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(a => a.Addresses)
                .HasForeignKey(ca => ca.CustomerId);


            base.OnModelCreating(modelBuilder);
        }

        //used to create tables in our memory database
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
