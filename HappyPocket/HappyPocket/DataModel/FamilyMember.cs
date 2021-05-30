using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HappyPocket.DataModel
{
    public class FamilyMember
    {
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
        [MaxLength(40)]
        [Required]
        public string Surname { get; set; }
#nullable enable
        [MaxLength(40)]
        public string? Patronymic { get; set; }
#nullable disable
        [Required]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        // Custom collection that stores instances of Income assigned to this FamilyMember.
        public virtual ICollection<Income> Incomes { get; set; }
        // Custom collection that stores instances of Expense assigned to this Counteragent.
        public virtual ICollection<Expense> Expenses { get; set; }
        public FamilyMember()
        {
            Incomes = new ObservableCollection<Income>();
            Expenses = new ObservableCollection<Expense>();
        }
    }
}
