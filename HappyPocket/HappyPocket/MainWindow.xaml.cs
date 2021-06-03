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

//using System.Configuration;
using HappyPocket.Form;

namespace HappyPocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Open_FormRole_Click(object sender, RoutedEventArgs e)
        {
            FormRole SubWindow = new FormRole();
            Open_FormWindow(SubWindow);
        }

        private void Button_Open_FormFamilyMember_Click(object sender, RoutedEventArgs e)
        {
            FormFamilyMember SubWindow = new FormFamilyMember();
            Open_FormWindow(SubWindow);
        }

        private void Button_Open_FormPaymentType_Click(object sender, RoutedEventArgs e)
        {
            FormPaymentType SubWindow = new FormPaymentType();
            Open_FormWindow(SubWindow);
        }

        private void Open_FormWindow(FormWindow formWindow)
        {
            formWindow.Owner = this;
            this.Hide();
            formWindow.Show();
        }

        private void Button_Open_FormCounteragent_Click(object sender, RoutedEventArgs e)
        {
            FormCounteragent SubWindow = new FormCounteragent();
            Open_FormWindow(SubWindow);
        }

        private void Button_Open_FormExpenseCategory_Click(object sender, RoutedEventArgs e)
        {
            FormExpenseCategory SubWindow = new FormExpenseCategory();
            Open_FormWindow(SubWindow);
        }

        private void Button_Open_FormIncomeCategory_Click(object sender, RoutedEventArgs e)
        {
            FormIncomeCategory SubWindow = new FormIncomeCategory();
            Open_FormWindow(SubWindow);
        }

        private void Button_Open_FormExpense_Click(object sender, RoutedEventArgs e)
        {
            FormExpense SubWindow = new FormExpense();
            Open_FormWindow(SubWindow);
        }

        private void Button_Open_FormIncome_Click(object sender, RoutedEventArgs e)
        {
            FormIncome SubWindow = new FormIncome();
            Open_FormWindow(SubWindow);
        }
    }
}
