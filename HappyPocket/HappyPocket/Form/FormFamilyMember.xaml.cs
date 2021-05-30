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
    /// Interaction logic for Form_FamilyMember.xaml
    /// </summary>
    public partial class FormFamilyMember : FormWindow
    {
        public FormFamilyMember() : base()
        {
            InitializeComponent();

            // Loading the tables.
            dbContext.FamilyMembers.Load();
            dbContext.Roles.Load();

            var familyMembers = dbContext.FamilyMembers.Local.ToBindingList(); 
            FormFamilyMember__DataGrid.ItemsSource = familyMembers; // Setting up a binding to cache.

            var rolesNames = dbContext.Roles.Local.ToBindingList();
            FormFamilyMember__ComboBox.ItemsSource = rolesNames;
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            //try {
            //    dbContext.SaveChanges();
            //}
            //catch (DbUpdateException e1){

            //}
            dbContext.SaveChanges();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        //{
        //    DataGrid dataGridSender = (DataGrid)sender;

        //    if (dataGridSender.SelectedItem == null)
        //    {
        //        //e.Cancel = true;
        //        (sender as DataGrid).RowEditEnding -= DataGrid_RowEditEnding;
        //        (sender as DataGrid).CommitEdit();
        //        (sender as DataGrid).Items.Refresh();
        //        (sender as DataGrid).RowEditEnding += DataGrid_RowEditEnding;
        //    }
        //    else
        //    {
        //        return;
        //    }

        //}
    }

    public class NameValidator : ValidationRule
    {
        public override ValidationResult Validate
          (object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Value cannot be empty.");
            }
            else
            {
                if (value.ToString().Length > 3)
                    return new ValidationResult
                    (false, "Name cannot be more than 3 characters long.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
