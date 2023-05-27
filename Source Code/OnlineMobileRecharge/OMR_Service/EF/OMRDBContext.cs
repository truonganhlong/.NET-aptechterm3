using Microsoft.EntityFrameworkCore;
using OMR_Service.Configuration;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.EF
{
    public class OMRDBContext: DbContext
    {
        public OMRDBContext(DbContextOptions<OMRDBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-FEV4I7LE;Database=OnlineMobileRecharge;User ID=sa;Password=long70261209;Trusted_Connection=False;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceContractConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TuneConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionConfiguration());
            modelBuilder.ApplyConfiguration(new UserFunctionConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionGroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUserConfiguration());
        }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceProvider> ServiceProvider { get; set; }
        public DbSet<ServiceContract> ServiceContract { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Tune> Tune { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Function> Function { get; set; }
        public DbSet<FunctionGroup> FunctionGroup { get; set; }
        public DbSet<UserFunction> UserFunction { get; set; }
        public DbSet<GroupUser> GroupUser { get; set; }
    }
}