using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using HappyPocket.Form.Validation;
using System.ComponentModel;

namespace HappyPocket.DataModel
{
    public class FamilyMember : PropertyChangedNotification
    {
        public int Id
        {
            get => GetValue(() => Id);
            set => SetValue(() => Id, value);
        }

        [MaxLength(40)]
        [Required]
        public string Name
        {
            get => GetValue(() => Name);
            set => SetValue(() => Name, value);
        }
        [MaxLength(40)]
        [Required]
        public string Surname
        {
            get => GetValue(() => Surname);
            set => SetValue(() => Surname, value);
        }
#nullable enable
        [MaxLength(40)]
        public string? Patronymic
        {
            get => GetValue(() => Patronymic);
            set => SetValue(() => Patronymic, value);
        }
#nullable disable
        [Required]
        public int RoleId
        {
            get => GetValue(() => RoleId);
            set => SetValue(() => RoleId, value);
        }

        public virtual Role Role { get; set; }

        // Custom collection that stores instances of Income assigned to this FamilyMember.
        public virtual ICollection<Income> Incomes { get; set; }
        // Custom collection that stores instances of Expense assigned to this Counteragent.
        public virtual ICollection<Expense> Expenses { get; set; }
        public FamilyMember()
        {
            Surname = "Фамилия";
            Name = "Имя";
            Patronymic = "Отчество";
            RoleId = 1;

            Incomes = new ObservableCollection<Income>();
            Expenses = new ObservableCollection<Expense>();
        }
    }
}
