using System.Windows;
using System.Windows.Controls;
using HappyPocket.DataModel;

namespace HappyPocket.Form
{
    public class FormWindow : Window
    {
        public HappyPocketContext dbContext;

        protected DataGrid dataGrid { get; set; }

        public FormWindow()
        {
            dbContext = new HappyPocketContext();

            this.Closing += Form_Closing;
        }

        protected virtual void Button_Back_Click(object sender, RoutedEventArgs e)
        {
        }

        protected void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Form.IsValid(this))
            {
                string messageBoxTextReturn = "В полях введена недопустимая информация. Если вы закроете форму, все изменения утратятся. \nВернуться к редактированию, чтобы устранить ошибки?";
                string captionReturn = "Вернуться";

                MessageBoxResult toReturn = System.Windows.MessageBox.Show(
                    messageBoxTextReturn,
                    captionReturn,
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Question);


                if (toReturn == MessageBoxResult.OK) // User agreed to fix errors.
                {
                    e.Cancel = true; // Cancel closing.
                    return;
                }
                else
                {
                    dbContext.Dispose();
                }

                ReturnToOwnerWindow();
                return;
            }

            if (!dbContext.ChangeTracker.HasChanges())
            {
                ReturnToOwnerWindow();
                return;
            }

            string messageBoxTextSave = "Если вы закроете форму, все изменения утратятся. \nСохранить изменения?";
            string captionClose = "Сохранить форму";

            MessageBoxResult toSave = System.Windows.MessageBox.Show(
                messageBoxTextSave,
                captionClose,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);

            if (toSave == MessageBoxResult.Cancel)
            {
                e.Cancel = true; // Cancel closing.
                return;
            }
            else if (toSave == MessageBoxResult.No)
            {
                dbContext.Dispose();
            }
            else
            {
                dbContext.SaveChanges();
            }

            ReturnToOwnerWindow();
        }

        protected void ReturnToOwnerWindow() // Can be in future moved to higher abstraction class like HappyPocketWindow.
        {
            if (this.Owner == null)
            {
                return;
            }
            this.Owner.Show();
        }
        protected void Update()
        {
            if (!Form.IsValid(this))
            {
                string messageBoxTextSaveError = "Сохранение невозможно: в полях введена недопустимая информация. \nВернуться к редактированию, чтобы устранить ошибки.";
                string captionSaveError = "Ошибка при сохранении";

                System.Windows.MessageBox.Show(
                    messageBoxTextSaveError,
                    captionSaveError,
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);

                return;
            }

            dbContext.SaveChanges();
        }

        protected virtual void Button_Update_Click(object sender, RoutedEventArgs e)
        {
        }

        protected virtual void DataGrid__Button_Delete_Click(object sender, RoutedEventArgs e)
        {
        }
        protected virtual void Button_Add_Click(object sender, RoutedEventArgs e)
        {
        }


        protected virtual void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
