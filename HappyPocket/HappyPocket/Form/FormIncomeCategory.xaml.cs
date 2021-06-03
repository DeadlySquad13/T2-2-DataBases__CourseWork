using System.Windows;
using Microsoft.EntityFrameworkCore;
using HappyPocket.DataModel;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for FormIncomeCategory.xaml
    /// </summary>
    public partial class FormIncomeCategory : FormWindow
    {
        public FormIncomeCategory() : base()
        {
            InitializeComponent();

            this.dbContext.IncomeCategories.Load();

            FormIncomeCategory__DataGrid.ItemsSource = dbContext.IncomeCategories.Local.ToBindingList(); // Setting up a binding to cache.
            this.dataGrid = FormIncomeCategory__DataGrid;
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
            Form.DeleteRowFromDataGrid<IncomeCategory>(sender, e, this.dataGrid);
        }

        protected override void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<IncomeCategory>(sender, e, this.dataGrid);
        }
    }
}
