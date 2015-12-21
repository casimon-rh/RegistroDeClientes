using Data.Interfaz;
using Extra.Plain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace RegistroDeClientesBD.Rutine
{
    public class RutinaClientes : IRutinasCatalogos<Cliente>, INotifyPropertyChanged
    {
        public override event IRutinasCatalogos<Cliente>.onError OnError;
        public override event IRutinasCatalogos<Cliente>.onPregunta OnPregunta;
        public override event IRutinasCatalogos<Cliente>.onSuccess OnSuccess;
        public override event IRutinasCatalogos<Cliente>.Delete Deleted;

        public delegate void mensaje(string s);
        public event mensaje OnMensaje;

        public Cliente Current
        {
            set { current = value; NotifyPropertyChanged("Current"); }
            get { return current; }
        }

        public IList<Cliente> Catalogos
        {
            set { catalogos = value; NotifyPropertyChanged("Catalogos"); }
            get { return catalogos; }
        }

        public void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.daoCatalogo = Service.FuncionDAO();
                Current = new Cliente();
                Catalogos = daoCatalogo.getAll();
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show("Error muy grave D: " + ex.Message, "BASES", MessageBoxButton.OK, MessageBoxImage.Error);
                (sender as Window).Close();
            }
        }
        public void onClick(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (this.evento)
                {
                    case EVENTO.ALTA:
                        daoCatalogo.refresh();
                        daoCatalogo.inserta(Current);
                        onCancela(sender, e);
                        break;
                    case EVENTO.BAJA:
                        this.OnPregunta("Desea borrar el siguiente registro: ", evento);
                        break;
                    case EVENTO.UPDATE:
                        this.OnPregunta("Desea editar el registro ", evento);
                        break;
                }
                Catalogos = daoCatalogo.getAll();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public void onCancela(object sender, RoutedEventArgs e)
        {
            try
            {
                Current = new Cliente();
                daoCatalogo.refresh();
                Catalogos = daoCatalogo.getAll();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public void onUpdate()
        {
            daoCatalogo.update();

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Delete()
        {
            try
            {
                daoCatalogo.borrar(Current);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

    }
}
