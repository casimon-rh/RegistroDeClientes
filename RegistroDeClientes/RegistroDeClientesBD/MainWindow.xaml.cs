using Data.Interfaz;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Extra.Plain;
using RegistroDeClientesBD.Rutine;
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
using System.Windows.Threading;
using Visualize.Controles.Metro;

namespace RegistroDeClientesBD
{
    public partial class MainWindow : MetroWindow
    {
        RutinaClientes rutinas;
        Dispatcher dsDispatch;
        public delegate void Show(bool b, EVENTO evt);

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                rutinas = Resources["Rutina"] as RutinaClientes;
                this.Loaded += rutinas.MetroWindow_Loaded;
                rutinas.OnError += rutinas_onFailure;
                rutinas.OnPregunta += rutinas_onUploadSuccess;
                rutinas.OnMensaje += Rutinas_OnMensaje;
                dsDispatch = this.Dispatcher;
            }
            catch (Exception)
            {

                throw;
            }
        }

        async void Rutinas_OnMensaje(string s)
        {
            await this.ShowMessageAsync("Bases", s);
        }

        void Flip_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
        }



        void rutinas_onUploadSuccess()
        {
        }
        void rutinas_onFailure(Exception ex)
        {
        }
        void rutinas_onLoadSuccess()
        {
        }
        void success()
        {
        }

        async void rutinas_onUploadSuccess(string s, EVENTO evento)
        {

            MessageDialogResult res = await Dialogs.showQuestionMessage(s, "Bases", this).ConfigureAwait(false);
            Show ss = new Show(evalua);
            try
            {
                dsDispatch.BeginInvoke(ss, res == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative, evento);
            }
            catch (Exception ex) { }

        }
        private void ElDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as DataGrid).SelectedIndex != -1)
            {
                rutinas.evento = EVENTO.UPDATE;
                Flip.SelectedIndex = 1;
                Id.IsEnabled = false;
            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo.IsEnabled = false;
            rutinas.evento = EVENTO.ALTA;
            rutinas.Current = new Cliente();
            Flip.SelectedIndex = 1;
            Borrar.IsEnabled = false;
        }

        private void Flip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as FlipView).SelectedIndex == 0 && rutinas != null)
            {
                ElDataGrid.SelectedIndex = -1;
                Nuevo.IsEnabled = true;
                Aceptar.IsEnabled = false;
                rutinas.onCancela(sender, e);
            }
            else if (rutinas != null)
            {
                Nuevo.IsEnabled = false;
                Aceptar.IsEnabled = true;
                if (rutinas.Current != null&& rutinas.Current.IdCliente!=0)
                    Borrar.IsEnabled = true;
            }

        }
        void evalua(bool res, EVENTO evento)
        {
            if (res)
            {
                if (evento == EVENTO.UPDATE)
                    rutinas.onUpdate();
                else
                    rutinas.Delete();

                Cancelar_Click(null, null);
                Flip.SelectedIndex = 0;
            }
            else
                rutinas.evento = EVENTO.UPDATE;
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (rutinas.Current != null)
            {
                rutinas.evento = EVENTO.BAJA;
                rutinas.onClick(sender, e);
            }

        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Flip.SelectedIndex = 0;
            rutinas.onCancela(sender, e);
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (rutinas.Current.IdCliente != 0 && rutinas.Catalogos.Where(x => x.IdCliente == (rutinas.Current.IdCliente)).Count() <= 1)
            {
                rutinas.onClick(sender, e);
                if (rutinas.evento == EVENTO.ALTA)
                    Flip.SelectedIndex = 0;
            }
            else
            {
                Rutinas_OnMensaje("Por favor especifique un id que no este registrado");
            }
        }

        private void ElDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
