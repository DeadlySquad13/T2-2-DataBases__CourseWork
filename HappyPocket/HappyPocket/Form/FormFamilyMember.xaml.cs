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


namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for Form_FamilyMember.xaml
    /// </summary>
    public partial class FormFamilyMember : FormWindow
    {
        public FormFamilyMember()
        {
            InitializeComponent();
            
            dbContext.FamilyMembers.Load(); // Loading the table.
            /* It seems that it works fine without converting FamilyMembers Table to Local and without using ToBindingList(). Hope it won't be a big problem in the future, it's better to investigate how it works. */
            var familyMembers = dbContext.FamilyMembers.Include(x => x.Role).ToList(); 
            FormFamilyMember__DataGrid.ItemsSource = familyMembers; // Setting up a binding to cache.
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
