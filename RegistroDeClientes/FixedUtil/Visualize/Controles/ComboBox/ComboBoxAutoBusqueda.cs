using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Visualize.Controles.ComboBox
{
    public class ComboBoxAutoBusqueda : System.Windows.Controls.ComboBox
    {

            private bool _buscar;
            private List<ItemPersonalizado> _listaOriginal;
            public bool buscar
            {
                get { return _buscar; }
                set { _buscar = value;

                if (buscar)
                {
                    this.PreviewKeyUp += filtrar;
                    this.GotFocus+=ComboBoxAutoBusqueda_GotFocus;
                    this.SelectionChanged+=ComboBoxAutoBusqueda_SelectionChanged;

                    this.StaysOpenOnEdit = true;
                    this.IsEditable = true;
                    this.IsTextSearchEnabled = false;
               
                }
                
                }
            
            }

            private void ComboBoxAutoBusqueda_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var textbox = (TextBox)this.Template.FindName("PART_EditableTextBox", this);
                textbox.Select(textbox.Text.Length, 0);
            }

            private void ComboBoxAutoBusqueda_GotFocus(object sender, System.Windows.RoutedEventArgs e)
            {
                var textbox = (TextBox)this.Template.FindName("PART_EditableTextBox", this);
                textbox.Select(textbox.Text.Length, 0);
            }

            public List<ItemPersonalizado> listaOriginal
            {

                get { return _listaOriginal; }

                set {
                    _listaOriginal = value;
                    setlistaOriginal();
                
                }
            
            }




            private void filtrar(object sender, KeyEventArgs e)
           {
               if (e.Key != System.Windows.Input.Key.Escape &&
               e.Key != System.Windows.Input.Key.Down &&
               e.Key != System.Windows.Input.Key.Up &&
               e.Key != System.Windows.Input.Key.Left &&
              e.Key != System.Windows.Input.Key.Right &&
               e.Key != System.Windows.Input.Key.Enter
                   )
               {

                   if (this.ItemsSource != null && listaOriginal != null)
                   {
                       this.IsDropDownOpen = true;
                       FilterCombo(e);
                   }
               }
               else
               {
                   
                   e.Handled = false;
               }
            }

            private void FilterCombo(KeyEventArgs e)
            {
                string texto;
   
                List<ItemPersonalizado> subLista;
               texto = this.Text;
                if (!(String.IsNullOrEmpty(texto)))
                {
                    ItemPersonalizado a = new ItemPersonalizado("", "");

                    subLista = listaOriginal.FindAll(item=> item.texto.Contains ( texto));
                    this.DisplayMemberPath = "texto";
                    this.SelectedValuePath = "value";
                    this.ItemsSource = subLista;

                    if (e.Key != System.Windows.Input.Key.Delete)
                    {
                        var textbox = (TextBox)this.Template.FindName("PART_EditableTextBox", this);
                        textbox.Select(textbox.Text.Length, 0);
                    }
                }else
                    setlistaOriginal();
            }

            private void setlistaOriginal()
            {

                if (listaOriginal != null)
                {
                    this.DisplayMemberPath = "texto";
                    this.SelectedValuePath = "value";
                    this.ItemsSource = listaOriginal;
                
                }
            
            }



    }
}
