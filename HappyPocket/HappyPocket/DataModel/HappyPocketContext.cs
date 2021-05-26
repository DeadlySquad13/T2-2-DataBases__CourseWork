namespace HappyPocket.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HappyPocketContext : DbContext
    {
        public HappyPocketContext()
            : base("name=HappyPocketContext")
        {
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