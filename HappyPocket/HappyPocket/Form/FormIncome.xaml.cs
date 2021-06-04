using System.Windows;
using Microsoft.EntityFrameworkCore;
using HappyPocket.DataModel;
using System.Linq;
using HappyPocket.Authorization;

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
            dbContext.IncomeCategories.Load();
            dbContext.PaymentTypes.Load();
            dbContext.Expenses.Load();


            var incomes = dbContext.Incomes.Local.ToBindingList();
            FormIncome__DataGrid.ItemsSource = incomes; // Setting up a binding to cache.
            this.dataGrid = FormIncome__DataGrid;


            var incomeCategories = dbContext.IncomeCategories.Local.ToBindingList();
            FormIncome__ComboBox_IncomeCategory.ItemsSource = incomeCategories;

            var familyMembers = dbContext.FamilyMembers.Local.ToBindingList();
            FormIncome__ComboBox_FamilyMember.ItemsSource = familyMembers;

            var counteragents = dbContext.Counteragents.Local.ToBindingList();
            FormIncome__ComboBox_Counteragent.ItemsSource = counteragents;

            var paymentTypes = dbContext.PaymentTypes.Local.ToBindingList();
            FormIncome__ComboBox_PaymentType.ItemsSource = paymentTypes;

            if (GlobalData.currentUser.roles[0] == Authorization.Role.FinancialConsultant)
            {
                FormIncome__DataGrid.IsReadOnly = true;
                UIElement[] elementsToHide = { Button_Add, Button_Update };
                this.HideElements(elementsToHide);
                DataGrid__Column_Delete.Visibility = Visibility.Collapsed;
            }
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
            Form.DeleteRowFromDataGrid<Income>(sender, e, this.dataGrid);
        }

        protected override void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<Income>(sender, e, this.dataGrid);
        }
    }
}
