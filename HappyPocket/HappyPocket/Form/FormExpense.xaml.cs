using System.Windows;
using Microsoft.EntityFrameworkCore;
using HappyPocket.DataModel;
using System.Linq;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for FormExpense.xaml
    /// </summary>
    public partial class FormExpense : FormWindow
    {
        public System.ComponentModel.BindingList<PaymentType>PaymentTypes {get; set; }

        public FormExpense() : base()
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
            FormExpense__DataGrid.ItemsSource = expenses; // Setting up a binding to cache.
            this.dataGrid = FormExpense__DataGrid;


            var expenseCategories = dbContext.ExpenseCategories.Local.ToBindingList();
            FormExpense__ComboBox_ExpenseCategory.ItemsSource = expenseCategories;

            var familyMembers = dbContext.FamilyMembers.Local.ToBindingList();
            FormExpense__ComboBox_FamilyMember.ItemsSource = familyMembers;

            var counteragents = dbContext.Counteragents.Local.ToBindingList();
            FormExpense__ComboBox_Counteragent.ItemsSource = counteragents;

            var paymentTypes = dbContext.PaymentTypes.Local.ToBindingList();
            FormExpense__ComboBox_PaymentType.ItemsSource = paymentTypes;
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
