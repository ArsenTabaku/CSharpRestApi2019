using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Content
{
    //DbContent is a way to manage database which can be founded in entinty framework
    //DbContext is the superclass, while InMemoryContext is the subclass
    public class InMemoryContext : DbContext
    {
        //code to connect our code with in memory database
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>()
                .UseInMemoryDatabase("TheDB")
                .Options;


        //using a function inside the superclass
        public InMemoryContext() : base(options)
        {

        }

        //used to create tables in database
        public DbSet<Customer> Customers { get; set; }
    }
}
