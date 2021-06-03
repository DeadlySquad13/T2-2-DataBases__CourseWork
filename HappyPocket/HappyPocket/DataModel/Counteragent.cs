using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using HappyPocket.Form.Validation;

namespace HappyPocket.DataModel
{
    public class Counteragent : PropertyChangedNotification
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

        // Custom collection that stores instances of Income assigned to this Counteragent.
        public virtual ICollection<Income> Incomes { get; set; }
        // Custom collection that stores instances of Expense assigned to this Counteragent.
        public virtual ICollection<Expense> Expenses { get; set; }
        public Counteragent()
        {
            Name = "Контрагент";
            Incomes = new ObservableCollection<Income>();
            Expenses = new ObservableCollection<Expense>();
        }
    }
}
