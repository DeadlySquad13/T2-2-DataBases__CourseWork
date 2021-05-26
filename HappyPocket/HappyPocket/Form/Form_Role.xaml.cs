﻿using System;
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

using System.Data.Entity;

using HappyPocket.DataModel;
using HappyPocket.UtilityWindows;


namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for Form_Role.xaml
    /// </summary>
    public partial class Form_Role : HappyPocketWindow
    {
        public Form_Role()
        {
            InitializeComponent();
            dbContext = new HappyPocketContext();
            dbContext.Roles.Load(); // Loading the table.
            Form_Role__DataGrid.ItemsSource = dbContext.Roles.Local.ToBindingList(); // Setting up a binding to cache.

            this.Closing += Form_Role_Closing;
        }

        private void Form_Role_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: show dialog window.
            dbContext.Dispose();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            //UtilityWindow_SaveDialog = new UtilityWindow_SaveDialog();

            DialogSave DialogSave = new DialogSave(this);
            DialogSave.ShowDialog();

            this.Close();
            this.WindowParent.Show();
        }
    }
}