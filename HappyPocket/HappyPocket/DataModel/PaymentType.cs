using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using HappyPocket.Form.Validation;

namespace HappyPocket.DataModel
{
    public class PaymentType : PropertyChangedNotification
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

        // Custom collection that stores instances of Income assigned to this PaymentType.
        public virtual ICollection<Income> Incomes { get; set; }
        // Custom collection that stores instances of Expense assigned to this PaymentType.
        public virtual ICollection<Expense> Expenses { get; set; }
        public PaymentType()
        {
            Name = "Тип оплаты";
            Incomes = new ObservableCollection<Income>();
            Expenses = new ObservableCollection<Expense>();
        }
    }
}
