using Data.XML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Visualize.Controles.ComboBox
{
        public class ItemPersonalizado
        {
            private string _value;
            private string _texto;

            public string value
            {
                get { return _value; }
                set { _value = value; }
            }

            public string texto
            {
                get { return _texto; }
                set { _texto = value; }
            }

            public ItemPersonalizado()
            {

            }
            public ItemPersonalizado(string value, string texto)
            {
                this.value = value;
                this.texto = texto;
            }

            public static List<ItemPersonalizado> getLista(DataSet data, List<Campo> camposTexto, List<Campo> camposValor)
            {
                List<ItemPersonalizado> lista = new List<ItemPersonalizado>();
                ItemPersonalizado elemento;
                DataTable tabla;
                int i = 0, j = 0;
                Object[] consulta;
                String valor;
                if (data != null || data.Tables.Count > 0)
                {

                    tabla = data.Tables[0];

                    if (tabla.Rows.Count > 0)
                    {
                        for (i = 0; i < tabla.Rows.Count; i++)
                        {
                            elemento = new ItemPersonalizado();
                            consulta = tabla.Rows[i].ItemArray;


                            foreach (Campo columna in camposTexto)
                            {
                                j = 0;
                                foreach (Object aux in consulta)
                                {
                                    if (tabla.Columns[j].ColumnName == columna.nombre)
                                    {
                                        if (!String.IsNullOrEmpty(columna.formato))
                                        {
                                            if (!(aux is DateTime))
                                                valor = string.Format(columna.formato, aux);
                                            else
                                                valor = ((DateTime)aux).ToString(columna.formato);

                                        }
                                        else
                                            valor = aux.ToString();
                                        if (j > 0)
                                            elemento.texto = elemento.texto + " " + valor;
                                        else
                                            elemento.texto = valor;
                                        break;
                                    }
                                    j++;
                                }
                            }


                            foreach (Campo columna in camposValor)
                            {
                                j = 0;
                                foreach (Object aux in consulta)
                                {
                                    if (tabla.Columns[j].ColumnName == columna.nombre)
                                    {
                                        if (!String.IsNullOrEmpty(columna.formato))
                                        {
                                            if (!(aux is DateTime))
                                                valor = string.Format(columna.formato, aux);
                                            else
                                                valor = ((DateTime)aux).ToString(columna.formato);
                                        }
                                        else
                                            valor = aux.ToString();

                                        if (j > 0)
                                            elemento.value = elemento.value + " " + valor;
                                        else
                                            elemento.value = valor;

                                        break;
                                    }
                                    j++;
                                }
                            }




                            lista.Add(elemento);
                        }
                        return lista;
                    }
                    else
                    {
                        return null;
                    }
                }
                return lista;
            }




            public static List<ItemPersonalizado> getLista(DataSet data)
            {
                List<ItemPersonalizado> lista = new List<ItemPersonalizado>();
                DataTable tabla;
                if (data != null || data.Tables.Count > 0)
                {
                    tabla = data.Tables[0];
                    cargaComboBoxRecursivo(tabla, ref lista, 0);

                    return lista;
                }
                else
                {
                    return null;
                }
            }

            public static void cargaComboBoxRecursivo(DataTable tabla, ref List<ItemPersonalizado> lista, int fila)
            {
                ItemPersonalizado elemento;
                try
                {

                    if (fila < tabla.Rows.Count)
                    {
                        if (tabla != null)
                        {
                            elemento = new ItemPersonalizado();
                            elemento.value = (string)tabla.Rows[fila].ItemArray[0];
                            elemento.texto = (string)tabla.Rows[fila].ItemArray[1];
                            lista.Add(elemento);
                            fila++;
                            cargaComboBoxRecursivo(tabla, ref lista, fila);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (tabla != null)
                    {
                        if (fila < tabla.Rows.Count)
                        {
                            elemento = new ItemPersonalizado();
                            elemento.value = (string)tabla.Rows[fila].ItemArray[0];
                            elemento.texto = (string)tabla.Rows[fila].ItemArray[0];
                            lista.Add(elemento);
                            fila++;
                            cargaComboBoxRecursivo(tabla, ref lista, fila);
                        }
                    }
                }

            }


            public static void cargaComboBox(System.Windows.Controls.ComboBox combo, DataSet data, List<Campo> camposTexto, List<Campo> camposValor)
            {
                List<ItemPersonalizado> lista;

                lista = getLista(data, camposTexto, camposValor);

                if (lista != null)
                {
                    combo.DisplayMemberPath = "texto";
                    combo.SelectedValuePath = "value";
                    combo.ItemsSource = lista;
                }

            }


            public static void cargaComboBox(ComboBoxAutoBusqueda combo, DataSet data, List<Campo> camposTexto, List<Campo> camposValor)
            {
                List<ItemPersonalizado> lista;

                lista = getLista(data, camposTexto, camposValor);

                if (lista != null)
                {
                    combo.listaOriginal = lista;
                }

            }
            public static void cargaComboBox(System.Windows.Controls.ComboBox combo, DataSet data)
            {
                List<ItemPersonalizado> lista;

                lista = getLista(data);

                if (lista != null)
                {
                    combo.DisplayMemberPath = "texto";
                    combo.SelectedValuePath = "value";
                    combo.ItemsSource = lista;
                }

            }


        }
    }

