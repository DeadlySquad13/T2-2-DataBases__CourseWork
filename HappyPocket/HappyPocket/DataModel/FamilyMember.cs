using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPocket.DataModel
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
#nullable enable
        public string? Patronymic { get; set; }
#nullable disable
        public int? RoleId { get; set; }
        public Role Role { get; set; }

        // Custom collection that stores instances of Income assigned to this FamilyMember.
        public ICollection<Income> Incomes { get; set; }
        // Custom collection that stores instances of Expense assigned to this Counteragent.
        public ICollection<Expense> Expenses { get; set; }
        public FamilyMember()
        {
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
        }
    }
}
