using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;
using HappyPocket.DataModel;
using HappyPocket.Form;
using System.Collections;
using System.Reflection;


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
