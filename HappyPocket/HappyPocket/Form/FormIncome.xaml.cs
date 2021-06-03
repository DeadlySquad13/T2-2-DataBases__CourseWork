using System.Windows;
using Microsoft.EntityFrameworkCore;
using HappyPocket.DataModel;
using System.Linq;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for FormIncome.xaml
    /// </summary>
    public partial class FormIncome : FormWindow
    {
        public System.ComponentModel.BindingList<PaymentType>PaymentTypes {get; set; }

        public FormIncome() : base()
        {
            InitializeComponent();

            // Loading the tables.
            dbContext.Roles.Load();
            dbContext.FamilyMembers.Load();
            dbContext.Counteragents.Load();
            dbContext.ExpenseCategories.Load();
            dbContext.PaymentTypes.Load();
            dbContext.Expenses.Load();


            var expenses = dbContext.Expenses.Local.ToBindingList();
            FormIncome__DataGrid.ItemsSource = expenses; // Setting up a binding to cache.
            this.dataGrid = FormIncome__DataGrid;


            var incomeCategories = dbContext.IncomeCategories.Local.ToBindingList();
            FormIncome__ComboBox_IncomeCategory.ItemsSource = incomeCategories;

            var familyMembers = dbContext.FamilyMembers.Local.ToBindingList();
            FormIncome__ComboBox_FamilyMember.ItemsSource = familyMembers;

            var counteragents = dbContext.Counteragents.Local.ToBindingList();
            FormIncome__ComboBox_Counteragent.ItemsSource = counteragents;

            var paymentTypes = dbContext.PaymentTypes.Local.ToBindingList();
            FormIncome__ComboBox_PaymentType.ItemsSource = paymentTypes;
        }

        protected override void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            this.Update();
        }

        protected override void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void DataGrid__Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Form.DeleteRowFromDataGrid<Expense>(sender, e, this.dataGrid);
        }

        protected override void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<Expense>(sender, e, this.dataGrid);
        }
    }
}
