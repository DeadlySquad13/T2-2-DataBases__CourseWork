using HappyPocket.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HappyPocket.Form
{
    public static class Form
    {
        public static void AddNewRowToDataGrid<TEntity>(object sender, RoutedEventArgs e, DataGrid dataGrid) where TEntity : new() // Explicitly declaring that all classes of our type have a default constructor.
        {
            ((BindingList<TEntity>)dataGrid.ItemsSource).Add(new TEntity());
        }

        public static void DeleteRowFromDataGrid<TEntity>(object sender, RoutedEventArgs e, DataGrid dataGrid) where TEntity : class
        {
            var row = dataGrid.SelectedItem;
            if (row != CollectionView.NewItemPlaceholder)
            {
                TEntity castedRow = row as TEntity;
                // Handles case when row was deleted (for example, cleared by backspace) before update. We try to delete unexisting row and get error. 
                if (castedRow == null)
                {
                    return;
                }
                ((BindingList<TEntity>)dataGrid.ItemsSource).Remove(castedRow);
            }
        }
    }
}
