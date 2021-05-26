using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using HappyPocket.DataModel;

namespace HappyPocket.Form
{   
    public class FormWindow : Window
    {
        public HappyPocketContext dbContext;

        public FormWindow()
        {
            dbContext = new HappyPocketContext();

            this.Closing += Form_Closing;
        }

        protected void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!dbContext.ChangeTracker.HasChanges())
            {
                if (this.Owner == null)
                {
                    return;    
                }
                this.Owner.Show();
                return;
            }

            var messageBoxText = "Если вы закроете форму, все изменения утратятся. Сохранить изменения?";
            var caption = "Закрыть форму";

            MessageBoxResult toSave = System.Windows.MessageBox.Show(
                messageBoxText,
                caption,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);

            if (toSave == MessageBoxResult.Cancel)
            {
                e.Cancel = true; // Cancelling closing.
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

            if (this.Owner == null)
            {
                return;
            }
            this.Owner.Show();
            return;
        }
    }
}
