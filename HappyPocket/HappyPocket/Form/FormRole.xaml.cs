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



using HappyPocket.DataModel;
using Microsoft.EntityFrameworkCore;
//using HappyPocket.UtilityWindows;


namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for Form_Role.xaml
    /// </summary>
    public partial class FormRole : FormWindow
    {
        public FormRole() : base()
        {
            InitializeComponent();

            dbContext.Roles.Load(); // Loading the table.
            FormRole__DataGrid.ItemsSource = dbContext.Roles.Local.ToBindingList(); // Setting up a binding to cache.
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
