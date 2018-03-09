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
    /// Lógica de interacción para Produc.xaml
    /// </summary>
    public partial class Produc : Window
    {
        Repositorios.RepositorioProductos repositorio;
        bool esNuevo;
        public Produc()
        {
            InitializeComponent();
            repositorio = new Repositorios.RepositorioProductos();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void HabilitarCajas(bool habilitadas)
        {
            txbCantidad.Clear();
            txbCategoria.Clear();
            txbDescripcion.Clear();
            txbNombre.Clear();
            txbPrecioCompra.Clear();
            txbPrecioVenta.Clear();
            txbPresentacion.Clear();
            txbCantidad.IsEnabled = habilitadas;
            txbCategoria.IsEnabled = habilitadas;
            txbDescripcion.IsEnabled = habilitadas;
            txbNombre.IsEnabled = habilitadas;
            txbPrecioCompra.IsEnabled = habilitadas;
            txbPrecioVenta.IsEnabled = habilitadas;
            txbPresentacion.IsEnabled = habilitadas;
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbCategoria.Text) || string.IsNullOrEmpty(txbPrecioVenta.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

               productos a = new productos()
                {
                    Descrpcion = txbDescripcion.Text,
                    cantidad = txbCantidad.Text,
                    tipo = txbCategoria.Text,
                    Nombre = txbNombre.Text,
                    precioCompra = txbPrecioCompra.Text,
                    precioVenta=txbPrecioVenta.Text,
                    Presentacion=txbPresentacion.Text
                };
                if (repositorio.AgregarProducto(a))
                {
                    MessageBox.Show("Guardado con Éxito", "productos", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar al producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                productos original = dtgProductos.SelectedItem as productos;
                productos a = new productos();
                a.cantidad = txbCantidad.Text;
                a.Descrpcion = txbDescripcion.Text;
                a.precioCompra = txbPrecioCompra.Text;
                a.Nombre = txbNombre.Text;
                a.precioVenta = txbPrecioVenta.Text;
                a.Presentacion = txbPresentacion.Text;
                a.tipo = txbCategoria.Text;
                if (repositorio.ModificarProduto(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su producto a sido actualizado", "producto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar al producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ActualizarTabla()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = repositorio.LeerProductos();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProductos().Count == 0)
            {
                MessageBox.Show("No tienes Productos", "producto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProductos.SelectedItem != null)
                {
                    productos a = dtgProductos.SelectedItem as productos;
                    HabilitarCajas(true);
                    txbCantidad.Text = a.cantidad;
                    txbCategoria.Text = a.tipo;
                    txbDescripcion.Text = a.Descrpcion;
                    txbNombre.Text = a.Nombre;
                    txbPrecioCompra.Text = a.precioCompra;
                    txbPrecioVenta.Text = a.precioVenta;
                    txbPresentacion.Text = a.Presentacion;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Producto", MessageBoxButton.OK, MessageBoxImage.Question);
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
            if (repositorio.LeerProductos().Count == 0)
            {
                MessageBox.Show("No tienes Productos", "Productos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgProductos.SelectedItem != null)
                {
                    productos a = dtgProductos.SelectedItem as productos;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarProducto(a))
                        {
                            MessageBox.Show("Tu producto ha sido removido", "producto", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar al producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "producto", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
