using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using Microsoft.EntityFrameworkCore;

using HappyPocket.DataModel;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.Windows.Controls.ValidationResult;
using HappyPocket.Form.Validation;

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

        private void DataGrid__Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Form.DeleteRowFromDataGrid<FamilyMember>(sender, e, FormFamilyMember__DataGrid);
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<FamilyMember>(sender, e, FormFamilyMember__DataGrid);
        }
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

        //    public void ValidateAnnotations(object value)
        //    {
        //        ValidationContext validationContext = new ValidationContext(value);
        //        var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
        //        bool valid = Validator.TryValidateObject(value, validationContext, validationResults, true);
        //        if (!valid)
        //        {
        //            foreach (var validationResult in validationResults)
        //            {
        //                Console.WriteLine("{0}", validationResult.ErrorMessage);
        //            }
        //        }

        //    }
        }
    }
