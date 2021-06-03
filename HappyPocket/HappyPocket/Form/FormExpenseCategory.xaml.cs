using System.Windows;
using Microsoft.EntityFrameworkCore;
using HappyPocket.DataModel;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for FormExpenseCategory.xaml
    /// </summary>
    public partial class FormExpenseCategory : FormWindow
    {
        public FormExpenseCategory() : base()
        {
            InitializeComponent();

            dbContext.ExpenseCategories.Load();
            var expenseCategories = dbContext.ExpenseCategories.Local.ToBindingList();
            FormExpenseCategory__DataGrid.ItemsSource = expenseCategories; // Setting up a binding to cache.
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
            Form.DeleteRowFromDataGrid<ExpenseCategory>(sender, e, FormExpenseCategory__DataGrid);
        }

        protected override void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<ExpenseCategory>(sender, e, FormExpenseCategory__DataGrid);
        }
    }
}
