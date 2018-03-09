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
using System.Windows.Shapes;

namespace Farmacia
{
    /// <summary>
    /// Lógica de interacción para Categoria.xaml
    /// </summary>
    public partial class Categoria : Window
    {
        Repositorios.RepositorioCategoria repositorio;
        bool esNuevo;
        public Categoria()
        {
            InitializeComponent();
            repositorio = new Repositorios.RepositorioCategoria();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void ActualizarTabla()
        {
            dtgCategoria.ItemsSource = null;
            dtgCategoria.ItemsSource = repositorio.LeerCat();
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void HabilitarCajas(bool habilitadas)
        {
            txbTipoCategoria.Clear();
            txbTipoCategoria.IsEnabled = habilitadas;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbTipoCategoria.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                categoria a = new categoria()
                {
                    TipoCategoria = txbTipoCategoria.Text,

                };
                if (repositorio.Agregarcategoria(a))
                {
                    MessageBox.Show("Guardado con Éxito", "categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar a la categoria ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                categoria original = dtgCategoria.SelectedItem as categoria;
                categoria a = new categoria();
                a.TipoCategoria = txbTipoCategoria.Text;
                if (repositorio.ModificarCategoria(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su categoria a sido actualizado", "categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a la categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerCat().Count == 0)
            {
                MessageBox.Show("No Hay Registros", "categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCategoria.SelectedItem != null)
                {
                    categoria a = dtgCategoria.SelectedItem as categoria;
                    HabilitarCajas(true);
                    txbTipoCategoria.Text = a.TipoCategoria;

                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿Que categoria???", "categoria", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerCat().Count == 0)
            {
                MessageBox.Show("No tienes Categoria", "categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCategoria.SelectedItem != null)
                {
                    categoria a = dtgCategoria.SelectedItem as categoria;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.TipoCategoria + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarCategoria(a))
                        {
                            MessageBox.Show("Tu categoria ha sido removido", "categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar a la categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "categoria", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }


        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
    

