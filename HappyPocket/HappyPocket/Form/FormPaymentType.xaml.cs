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
using HappyPocket.Authorization;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for FormPaymentType.xaml
    /// </summary>
    public partial class FormPaymentType : FormWindow
    {
        public FormPaymentType() : base()
        {
            InitializeComponent();

            dbContext.PaymentTypes.Load();
            var paymentTypes = dbContext.PaymentTypes.Local.ToBindingList();
            FormPaymentType__DataGrid.ItemsSource = paymentTypes; // Setting up a binding to cache.

            if (GlobalData.currentUser.roles[0] == Authorization.Role.FinancialConsultant)
            {
                FormPaymentType__DataGrid.IsReadOnly = true;
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
            Form.DeleteRowFromDataGrid<PaymentType>(sender, e, FormPaymentType__DataGrid);
        }

        protected override void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Form.AddNewRowToDataGrid<PaymentType>(sender, e, FormPaymentType__DataGrid);
        }
    }
}
