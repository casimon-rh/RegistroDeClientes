using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;


namespace Visualize.Animacion
{
    public static class Transicion
    {
        public static void animarProgress(ProgressBar  progress,double nuevo)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            Storyboard sb = new Storyboard();     
            try
            {
                Duration duration = new Duration(TimeSpan.FromSeconds(1));
                DoubleAnimation doubleanimation = new DoubleAnimation(nuevo , duration);
                DoubleAnimation regreso;


                if (nuevo < 100)
                {
                    progress.IsEnabled = true;
                    progress.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
                    progress.Value = nuevo;
                }
                else
                {
                    doubleanimation = new DoubleAnimation(nuevo, duration);
                    regreso = new DoubleAnimation(0, duration);
                    

                    regreso.BeginTime = duration.TimeSpan;

                    Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(ProgressBar.ValueProperty  ));
                    Storyboard.SetTargetProperty(regreso, new PropertyPath(ProgressBar.ValueProperty));

                    sb.Children.Add(doubleanimation);
                    sb.Children.Add(regreso );


                    progress.BeginStoryboard(sb);


                    progress.Value = 0; 
                    
                
                }
 
       

             
            }
            catch (Exception ex)
            {
              //  throw ex;
            }
        }

     
        public static void esconderGrid(  Grid panel)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            try
            {
                panel.BeginAnimation(FrameworkElement.WidthProperty, null);
                panel.BeginAnimation(FrameworkElement.OpacityProperty, null);

                animacion.From = panel.Width;
                animacion.To = 0;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
                panel.BeginAnimation(FrameworkElement.WidthProperty, animacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DATAGRID B
        public static void esconderDataGrid(DataGrid panel)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            try
            {
                panel.BeginAnimation(FrameworkElement.WidthProperty, null);
                panel.BeginAnimation(FrameworkElement.OpacityProperty, null);

                animacion.From = panel.Width;
                animacion.To = 0;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
                panel.BeginAnimation(FrameworkElement.WidthProperty, animacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DATAGRID E

        public static void moverGridY(Grid panel, double to, double from, Double milisegundos)
        {
            try
            {
                DoubleAnimation animacion = new DoubleAnimation(from, to, TimeSpan.FromSeconds(milisegundos));
                panel.BeginAnimation(TranslateTransform.XProperty , animacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DATAGRID B
        public static void moverDataGridY(DataGrid panel, double to, double from, Double milisegundos)
        {
            try
            {
                DoubleAnimation animacion = new DoubleAnimation(from, to, TimeSpan.FromSeconds(milisegundos));
                panel.BeginAnimation(TranslateTransform.XProperty, animacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DATAGRID E




        public static void animarGrid(Grid  panel, Double to, Double from, Double milisegundos, DependencyProperty propiedad)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            try
            {
                // panel.BeginAnimation(propiedad , null);

                animacion.From = from;
                animacion.To = to;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(milisegundos));
                panel.BeginAnimation(propiedad, animacion);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //DATAGRID B
        public static void animarDataGrid(DataGrid panel, Double to, Double from, Double milisegundos, DependencyProperty propiedad)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            try
            {
                // panel.BeginAnimation(propiedad , null);

                animacion.From = from;
                animacion.To = to;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(milisegundos));
                panel.BeginAnimation(propiedad, animacion);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //DATAGRID E

        public static void animarGrid(Window  panel, Double to, Double from, Double milisegundos, DependencyProperty propiedad )
        {
            DoubleAnimation animacion = new DoubleAnimation();
            try
            {
               // panel.BeginAnimation(propiedad , null);

                animacion.From = from;
                animacion.To = to;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(milisegundos));
                panel.BeginAnimation(propiedad , animacion);

            }
            catch (Exception ex)
            {
                throw ex; 
            }
        
        }
       

        public static void verGrid(Grid panel)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            try
            {
                panel.BeginAnimation(FrameworkElement.WidthProperty, null);
                animacion.From = 0;
                animacion.To = panel.Width  ;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
                panel.BeginAnimation(FrameworkElement.WidthProperty, animacion);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DATAGRID B
        public static void verDataGrid(DataGrid panel)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            try
            {
                panel.BeginAnimation(FrameworkElement.WidthProperty, null);
                panel.BeginAnimation(FrameworkElement.OpacityProperty, null);

                animacion.From = 0;
                animacion.To = panel.Width;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

                panel.BeginAnimation(FrameworkElement.WidthProperty, animacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DATAGRID E

        public static void esconderGridDerecha(Grid panel)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            DoubleAnimation animacionO = new DoubleAnimation();


            try
            {
                panel.BeginAnimation(FrameworkElement.WidthProperty, null);
                panel.BeginAnimation(FrameworkElement.OpacityProperty, null);


                animacion.From = panel.Width;
                animacion.To = 0  ;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(1000)); 

                animacionO.From = 1;
                animacionO.To = 0;
                animacionO.Duration = new Duration(TimeSpan.FromMilliseconds(1000));


                Storyboard.SetTargetProperty(animacion, new PropertyPath(FrameworkElement.WidthProperty));
                Storyboard.SetTargetProperty(animacionO, new PropertyPath(FrameworkElement.OpacityProperty));


                sb.Children.Add(animacion);
                //sb.Children.Add(animacionO);

                panel.BeginStoryboard(sb);
                

                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DATAGRID B
        public static void esconderDataGridDerecha(DataGrid panel)
        {
            DoubleAnimation animacion = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            DoubleAnimation animacionO = new DoubleAnimation();


            try
            {
                panel.BeginAnimation(FrameworkElement.WidthProperty, null);
                panel.BeginAnimation(FrameworkElement.OpacityProperty, null);


                animacion.From = panel.Width;
                animacion.To = 0;
                animacion.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

                animacionO.From = 1;
                animacionO.To = 0;
                animacionO.Duration = new Duration(TimeSpan.FromMilliseconds(1000));


                Storyboard.SetTargetProperty(animacion, new PropertyPath(FrameworkElement.WidthProperty));
                Storyboard.SetTargetProperty(animacionO, new PropertyPath(FrameworkElement.OpacityProperty));


                sb.Children.Add(animacion);
                //sb.Children.Add(animacionO);

                panel.BeginStoryboard(sb);




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DATAGRID E


        
    }
}
