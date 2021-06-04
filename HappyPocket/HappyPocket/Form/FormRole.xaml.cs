using System.Windows;
using Microsoft.EntityFrameworkCore;
//using HappyPocket.UtilityWindows;


namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for Form_Role.xaml
    /// </summary>
    public partial class FormRole : FormWindow
    {
        public FormRole() : base()
        {
            InitializeComponent();

            dbContext.Roles.Load(); // Loading the table.
            FormRole__DataGrid.ItemsSource = dbContext.Roles.Local.ToBindingList(); // Setting up a binding to cache.
        }

        protected override void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            this.Update();
        }

        protected override void Button_Back_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
