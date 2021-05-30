using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HappyPocket.Form.Helper
{
    // Handle binding differently to allow the ItemsSource property to have access to the binding context.
    class DataGridComboBoxColumnWithBinding : DataGridComboBoxColumn
    {
        // Generates editing element with binding set.
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement element = base.GenerateEditingElement(cell, dataItem);
            CopyItemsSource(element); // Set binding.
            return element;
        }

        // Generates element with binding set.
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement element = base.GenerateElement(cell, dataItem);
            CopyItemsSource(element); // Set binding.
            return element;
        }

        // Sets binding between element and ComboBox.ItemsSourceProperty.
        private void CopyItemsSource(FrameworkElement element)
        {
            BindingOperations.SetBinding(element, ComboBox.ItemsSourceProperty,
                BindingOperations.GetBinding(this, ComboBox.ItemsSourceProperty));
        }
    }
}
