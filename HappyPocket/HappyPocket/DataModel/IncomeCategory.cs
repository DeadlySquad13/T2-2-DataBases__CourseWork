using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPocket.DataModel
{
    public class IncomeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Custom collection that stores instances of Income assigned to this IncomeCategory.
        public ICollection<Income> Incomes { get; set; }
        public IncomeCategory()
        {
            Incomes = new List<Income>();
        }
    }
}
