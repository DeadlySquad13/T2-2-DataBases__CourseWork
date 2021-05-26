using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using HappyPocket.Form;
using HappyPocket.DataModel;

namespace HappyPocket.UtilityWindows
{
    /// <summary>
    /// Interaction logic for DialogSave.xaml
    /// </summary>
    public partial class DialogSave : Window
    {
        public HappyPocketWindow WindowOwner { get; set; }
        private HappyPocketContext DbContext;

        public DialogSave(HappyPocketWindow WindowOwner)
        {
            InitializeComponent();
            this.WindowOwner = WindowOwner;
            DbContext = this.WindowOwner.dbContext;
            this.Closing += DialogSave_Closing;
        }

        private void DialogSave_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: show dialog window.
            DbContext.Dispose();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            this.WindowOwner.dbContext.SaveChanges();
            this.Close();
        }
                 
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.WindowOwner.dbContext.Dispose();
            this.Close();
        }
    }
}
