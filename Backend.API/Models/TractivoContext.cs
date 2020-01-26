using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API.Models
{
    public class TractivoContext : DbContext
    {
        public TractivoContext(DbContextOptions<TractivoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // DATA SEEDING ############### 2 CUSTOMERS 1 CONTRACT AND 1 INVOICE ###############

            modelBuilder.Entity<Customer>()
                .HasData(new Customer()
                {
                    Id = 1,
                    FirstName = "Mark",
                    LastName = "Peel",
                    Email = "mpeel@localhost.com",
                    Address = "35 Carlberg Avenue",
                    City = "Oxford",
                    Country = "UK",
                    Phone = "05555555555"
                }, new Customer()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Cursy",
                    Email = "jcursy@localhost.com",
                    Address = "25 Kebel Road",
                    City = "Oxford",
                    Country = "UK",
                    Phone = "05555555555"
                });

            modelBuilder.Entity<Contract>()
                .HasData(new {
                    ContractId = 1,
                    Name = "Short Time Tenancy Contract",
                    CustomerId = 1,
                    PaymentRangeType = Enums.PaymentRangeTypes.Monthly,
                    Price = 750d,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(4)
                });

            modelBuilder.Entity<Invoice>()
                .HasData(new {
                    InvoiceId = 1,
                    CustomerId = 1,
                    StartDate = DateTime.Now,
                    MaturityDate = DateTime.Now.AddDays(15),
                    InvoiceNumber = "AAA000",
                    Price = 350d,
                });
        }


        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
    }
}

