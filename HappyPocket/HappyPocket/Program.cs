using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using HappyPocket.DataModel;

namespace HappyPocket
{
    class Program
    {
        static void InitializeData(string[] args)
        {
            using HappyPocketContext context = new HappyPocketContext();

            // Initializing Data in Tables.
            PaymentType PaymentTypeT1 = new PaymentType();
            context.PaymentTypes.Add(PaymentTypeT1);

            Role RoleT1 = new Role();
            context.Roles.Add(RoleT1);

            Counteragent CounteragentT1 = new Counteragent();
            context.Counteragents.Add(CounteragentT1);

            IncomeCategory IncomeCategoryT1 = new IncomeCategory();
            context.IncomeCategories.Add(IncomeCategoryT1);

            ExpenseCategory ExpenseCategoryT1 = new ExpenseCategory();
            context.ExpenseCategories.Add(ExpenseCategoryT1);

            FamilyMember FamilyMemberT1 = new FamilyMember();
            context.FamilyMembers.Add(FamilyMemberT1);

            Income IncomeT1 = new Income();
            context.Incomes.Add(IncomeT1);

            Expense ExpenseT1 = new Expense();
            context.Expenses.Add(ExpenseT1);
            context.SaveChanges();
        }
    }
}
