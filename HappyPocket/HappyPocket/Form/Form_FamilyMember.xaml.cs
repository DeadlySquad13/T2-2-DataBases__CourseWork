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
using System.Data.Entity;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for Form_FamilyMember.xaml
    /// </summary>
    public partial class Form_FamilyMember : Window
    {
        HappyPocketContext dbContext;
        public Form_FamilyMember()
        {
            InitializeComponent();
            dbContext = new HappyPocketContext();
            dbContext.FamilyMembers.Load(); // Loading the table.
            Form_FamilyMember__DataGrid.ItemsSource = dbContext.FamilyMembers.Local.ToBindingList(); // Setting up a binding to cache.

            this.Closing += Form_FamilyMember_Closing;
        }

        private void Form_FamilyMember_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dbContext.Dispose();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }
    }
}
