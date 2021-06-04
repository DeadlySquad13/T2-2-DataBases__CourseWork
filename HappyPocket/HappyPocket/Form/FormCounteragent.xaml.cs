using System.Windows;
using Microsoft.EntityFrameworkCore;
using HappyPocket.DataModel;


using HappyPocket.Authorization;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for FormCounteragent.xaml
    /// </summary>
    public partial class FormCounteragent : FormWindow
    {
        public FormCounteragent() : base()
        {
            InitializeComponent();

            dbContext.Counteragents.Load();
            var counteragents = dbContext.Counteragents.Local.ToBindingList();
            FormCounteragent__DataGrid.ItemsSource = counteragents; // Setting up a binding to cache.

            if (GlobalData.currentUser.roles[0] == Authorization.Role.Child ||
                GlobalData.currentUser.roles[0] == Authorization.Role.FinancialConsultant)
            {
                FormCounteragent__DataGrid.IsReadOnly = true;
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
            Form.DeleteRowFromDataGrid<Counteragent>(sender, e, FormCounteragent__DataGrid);
        }

        protected override void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<Counteragent>(sender, e, FormCounteragent__DataGrid);
        }
    }
}
