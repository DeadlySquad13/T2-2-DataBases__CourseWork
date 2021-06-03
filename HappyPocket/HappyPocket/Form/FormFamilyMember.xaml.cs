using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using Microsoft.EntityFrameworkCore;

using HappyPocket.DataModel;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.Windows.Controls.ValidationResult;
using Validation = System.Windows.Controls.Validation;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

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
            this.dataGrid = FormFamilyMember__DataGrid;

            var roles = dbContext.Roles.Local.ToBindingList();
            FormFamilyMember__ComboBox.ItemsSource = roles;
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
            Form.DeleteRowFromDataGrid<FamilyMember>(sender, e, FormFamilyMember__DataGrid);
        }

        protected override void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<FamilyMember>(sender, e, FormFamilyMember__DataGrid);
        }
    }
}
