using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPocket.DataModel
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Connection 1-M with FamilyMembers.
        public int? FamilyMemberId { get; set; }
        public FamilyMember FamilyMember { get; set; }

        // Connection 1-M with Counteragents.
        public int? CounteragentId { get; set; }
        public Counteragent Counteragent { get; set; }

        // Connection 1-M with ExpenseCategories.
        public int? ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        // Connection M-M with PaymentTypes.
        // Custom collection that stores instances of PaymentType assigned to this Expense.
        public ICollection<PaymentType> PaymentTypes { get; set; }
        public Expense()
        {
            PaymentTypes = new List<PaymentType>();
        }
    }
}
