using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPocket.DataModel
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Custom collection that stores instances of Expense assigned to this ExpenseCategory.
        public ICollection<Expense> Expenses { get; set; }
        public ExpenseCategory()
        {
            Expenses = new List<Expense>();
        }
    }
}
