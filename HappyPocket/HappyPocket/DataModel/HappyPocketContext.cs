namespace HappyPocket.DataModel
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class HappyPocketContext : DbContext
    {
        public HappyPocketContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = DS13; Database = HappyPocket; Trusted_Connection = True;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HappyPocket;Trusted_Connection=True;");
        }

        // Tables.
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Counteragent> Counteragents { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}