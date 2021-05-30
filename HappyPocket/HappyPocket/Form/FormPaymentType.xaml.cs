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
    public partial class FormPaymentType : FormWindow
    {
        public FormPaymentType() : base()
        {
            InitializeComponent();
            
            dbContext.PaymentTypes.Load();
            var paymentTypes = dbContext.PaymentTypes.Local.ToBindingList(); 
            FormPaymentType__DataGrid.ItemsSource = paymentTypes; // Setting up a binding to cache.
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
