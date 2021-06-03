using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using HappyPocket.Form.Validation;

namespace HappyPocket.DataModel
{
    public class ExpenseCategory : PropertyChangedNotification
    {
        public int Id
        {
            get => GetValue(() => Id);
            set => SetValue(() => Id, value);
        }
        [MaxLength(40)]
        [Required(ErrorMessage = "Поле обязательно.")]
        public string Name
        {
            get => GetValue(() => Name);
            set => SetValue(() => Name, value);
        }

        [Range(0, int.MaxValue, ErrorMessage = "Допустимы только неотрицательные числа.")]
        public int Limit
        {
            get => GetValue(() => Limit);
            set => SetValue(() => Limit, value);
        }
        // Custom collection that stores instances of Expense assigned to this ExpenseCategory.
        public virtual ICollection<Expense> Expenses { get; set; }
        public ExpenseCategory()
        {
            Name = "Категория расходов";
            Expenses = new ObservableCollection<Expense>();
        }
    }
}
