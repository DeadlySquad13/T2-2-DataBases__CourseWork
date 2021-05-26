using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPocket.DataModel
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Custom collection that stores instances of Income assigned to this PaymentType.
        public ICollection<Income> Incomes { get; set; }
        // Custom collection that stores instances of Expense assigned to this PaymentType.
        public ICollection<Expense> Expenses { get; set; }
        public PaymentType()
        {
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
        }
    }
}
