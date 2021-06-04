using System;
using System.Windows;
using System.Windows.Controls;

using HappyPocket.Authorization;

namespace HappyPocket.Form
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class FormAuthorization : FormWindow
    {
        public FormAuthorization()
        {
            InitializeComponent();
            Username.Text = "Введите имя";
            //Password.Text = "Введите пароль";
        }

        public void RemoveText(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "Username":
                    if (Username.Text == "Введите имя")
                    {
                        Username.Text = "";
                    }
                    break;
                case "Password":
                    //Label_Placeholder.Content = "";
                    break;
            }
        }

        public void AddText(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "TextBox_Username":
                    if (string.IsNullOrWhiteSpace(Username.Text))
                        Username.Text = "Введите имя"; // Hardcoded text.
                    break;
            }
        }
          

        public void Button_Login_Click(object sender, EventArgs e)
        {
            if (GlobalData.usersCredentials.ContainsKey(Username.Text))
            {
                if (GlobalData.usersCredentials[Username.Text].password == Password.Password)
                {
                    MainWindow MainWindow = new MainWindow();
                    this.Close();
                    MainWindow.Show();
                }
            }
        }

        protected override void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class PasswordBoxMonitor : DependencyObject
    {
        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(PasswordBoxMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));



        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        public static void SetPasswordLength(DependencyObject obj, int value)
        {
            obj.SetValue(PasswordLengthProperty, value);
        }

        public static readonly DependencyProperty PasswordLengthProperty =
            DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxMonitor), new UIPropertyMetadata(0));

        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pb = d as PasswordBox;
            if (pb == null)
            {
                return;
            }
            if ((bool)e.NewValue)
            {
                pb.PasswordChanged += PasswordChanged;
            }
            else
            {
                pb.PasswordChanged -= PasswordChanged;
            }
        }

        static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pb = sender as PasswordBox;
            if (pb == null)
            {
                return;
            }
            SetPasswordLength(pb, pb.Password.Length);
        }
    }
}
