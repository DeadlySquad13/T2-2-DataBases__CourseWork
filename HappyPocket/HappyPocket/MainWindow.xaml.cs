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

using HappyPocket.Form;

namespace HappyPocket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HappyPocketWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Open_Form_Role_Click(object sender, RoutedEventArgs e)
        {
            Form_Role SubWindow = new Form_Role();
            SubWindow.WindowParent = this;
            this.Hide();
            SubWindow.Show();
        }

        private void Button_Open_Form_FamilyMember_Click(object sender, RoutedEventArgs e)
        {
            Form_FamilyMember SubWindow = new Form_FamilyMember();
            SubWindow.Show();
        }
    }
}
