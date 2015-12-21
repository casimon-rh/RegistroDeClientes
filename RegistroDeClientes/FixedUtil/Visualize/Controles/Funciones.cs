using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Visualize.Controles.ComboBox;

namespace Visualize.Controles
{
    public static class FuncionControl
    {
        public static bool hasChildren(DependencyObject obj)
        {
            return VisualTreeHelper.GetChildrenCount(obj) != 0;            
        }

        public static String getControlType(DependencyObject obj)
        {
            return obj.GetType().ToString();
        }

        public static Object[] getChildren(DependencyObject dp)
        {
            Object[] doa = new Object[VisualTreeHelper.GetChildrenCount(dp)];
            for (int z = 0; z < VisualTreeHelper.GetChildrenCount(dp); z++)doa[z] = VisualTreeHelper.GetChild(dp, z);
            return doa;
        }
        public static List<System.Windows.Controls.ComboBox> getComboboxes(DependencyObject dp)
        {
            List<System.Windows.Controls.ComboBox> lista = new List<System.Windows.Controls.ComboBox>();
            foreach (object obj in getChildren(dp))
            {
                if (getControlType(obj as DependencyObject) == "System.Windows.Controls.CustomComboBox")
                    lista.Add(obj as System.Windows.Controls.ComboBox);
                else if(getControlType(obj as DependencyObject) == "MahApps.Metro.Controls.FlipView")
                    if((obj as MahApps.Metro.Controls.FlipView).HasItems)
                    foreach (object obj2 in (obj as MahApps.Metro.Controls.FlipView).Items)
                        foreach (object obj3 in getComboboxes(obj2 as DependencyObject))
                            lista.Add(obj3 as System.Windows.Controls.ComboBox);
                    
                if (hasChildren(obj as DependencyObject))
                    foreach (object obj1 in getComboboxes(obj as DependencyObject))
                        lista.Add(obj1 as System.Windows.Controls.ComboBox);
                
            }return lista;
        }
        //public static List

        public static List<CustomComboBox> getCustomComboboxes(DependencyObject dp)
        {
            List<CustomComboBox> lista = new List<CustomComboBox>();
            foreach (object obj in getChildren(dp))
            {
                if (getControlType(obj as DependencyObject) == "Visualize.Controles.ComboBox.CustomComboBox")
                    lista.Add(obj as CustomComboBox);
                else if (getControlType(obj as DependencyObject) == "MahApps.Metro.Controls.FlipView")
                    if ((obj as MahApps.Metro.Controls.FlipView).HasItems)
                        foreach (object obj2 in (obj as MahApps.Metro.Controls.FlipView).Items)
                            foreach (object obj3 in getCustomComboboxes(obj2 as DependencyObject))
                                lista.Add(obj3 as CustomComboBox);

                if (hasChildren(obj as DependencyObject))
                    foreach (object obj1 in getCustomComboboxes(obj as DependencyObject))
                        lista.Add(obj1 as CustomComboBox);

            } return lista;
        }
        public static List<System.Windows.Controls.DatePicker> getDatePickers(DependencyObject dp)
        {
            List<System.Windows.Controls.DatePicker> lista = new List<System.Windows.Controls.DatePicker>();
            foreach (object obj in getChildren(dp))
            {
                if (getControlType(obj as DependencyObject) == "System.Windows.Controls.DatePicker")
                    lista.Add(obj as System.Windows.Controls.DatePicker);
                else if (getControlType(obj as DependencyObject) == "MahApps.Metro.Controls.FlipView")
                    if ((obj as MahApps.Metro.Controls.FlipView).HasItems)
                        foreach (object obj2 in (obj as MahApps.Metro.Controls.FlipView).Items)
                            foreach (object obj3 in getDatePickers(obj2 as DependencyObject))
                                lista.Add(obj3 as System.Windows.Controls.DatePicker);

                if (hasChildren(obj as DependencyObject))
                    foreach (object obj1 in getDatePickers(obj as DependencyObject))
                        lista.Add(obj1 as System.Windows.Controls.DatePicker);

            } return lista;
        }
        public static List<MahApps.Metro.Controls.NumericUpDown> getNumericUpDowns(DependencyObject dp)
        {
            List<MahApps.Metro.Controls.NumericUpDown> lista = new List<MahApps.Metro.Controls.NumericUpDown>();
            foreach (object obj in getChildren(dp))
            {
                if (getControlType(obj as DependencyObject) == "MahApps.Metro.Controls.NumericUpDown")
                    lista.Add(obj as MahApps.Metro.Controls.NumericUpDown);
                else if (getControlType(obj as DependencyObject) == "MahApps.Metro.Controls.FlipView")
                    if ((obj as MahApps.Metro.Controls.FlipView).HasItems)
                        foreach (object obj2 in (obj as MahApps.Metro.Controls.FlipView).Items)
                            foreach (object obj3 in getNumericUpDowns(obj2 as DependencyObject))
                                lista.Add(obj3 as MahApps.Metro.Controls.NumericUpDown);

                if (hasChildren(obj as DependencyObject))
                    foreach (object obj1 in getDatePickers(obj as DependencyObject))
                        lista.Add(obj1 as MahApps.Metro.Controls.NumericUpDown);

            } return lista;
        }
        public static List<TextBox> getTextBoxes(DependencyObject dp)
        {
            List<TextBox> lista = new List<TextBox>();
            foreach (object obj in getChildren(dp))
            {
                if (getControlType(obj as DependencyObject) == "System.Windows.Controls.TextBox")
                    lista.Add(obj as System.Windows.Controls.TextBox);
                else if (getControlType(obj as DependencyObject) == "MahApps.Metro.Controls.FlipView")
                    if ((obj as MahApps.Metro.Controls.FlipView).HasItems)
                        foreach (object obj2 in (obj as MahApps.Metro.Controls.FlipView).Items)
                            foreach (object obj3 in getTextBoxes(obj2 as DependencyObject))
                                lista.Add(obj3 as System.Windows.Controls.TextBox);

                if (hasChildren(obj as DependencyObject))
                    foreach (object obj1 in getTextBoxes(obj as DependencyObject))
                        lista.Add(obj1 as System.Windows.Controls.TextBox);

            } return lista;
        }
    }
}
