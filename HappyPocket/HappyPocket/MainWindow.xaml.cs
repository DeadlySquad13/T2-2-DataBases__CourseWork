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
            //string connectionString = ConfigurationManager.ConnectionStrings["HappyPocketContext"].ConnectionString;
            InitializeComponent();
        }

        private void Button_Open_FormRole_Click(object sender, RoutedEventArgs e)
        {
            FormRole SubWindow = new FormRole();
            SubWindow.Owner = this;
            this.Hide();
            SubWindow.Show();
        }

        private void Button_Open_FormFamilyMember_Click(object sender, RoutedEventArgs e)
        {
            FormFamilyMember SubWindow = new FormFamilyMember();
            SubWindow.Show();
        }
    }
}
