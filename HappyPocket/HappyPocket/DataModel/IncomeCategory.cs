using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using HappyPocket.Form.Validation;


namespace HappyPocket.DataModel
{
    public class IncomeCategory : PropertyChangedNotification
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
        // Custom collection that stores instances of Income assigned to this IncomeCategory.
        public virtual ICollection<Income> Incomes { get; set; }
        public IncomeCategory()
        {
            Name = "Категория доходов";
            Incomes = new List<Income>();
        }
    }
}
