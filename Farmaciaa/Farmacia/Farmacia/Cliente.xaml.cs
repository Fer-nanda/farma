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
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        Repositorios.RepositorioCliente repositorio;
        bool esNuevo;
        public Cliente()
        {
            InitializeComponent();
            repositorio = new Repositorios.RepositorioCliente();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }

        private void HabilitarCajas(bool habilitadas)
        {
            txbNombre.Clear();
            txbDireccion.Clear();
            txbEmail.Clear();
            txbRfc.Clear();
            txbTelefono.Clear();
            txbCliente.Clear();
            txbNombre.IsEnabled = habilitadas;
            txbDireccion.IsEnabled = habilitadas;
            txbEmail.IsEnabled = habilitadas;
            txbRfc.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbCliente.IsEnabled = habilitadas;

        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void ActualizarTabla()
        {
            dtgCliente.ItemsSource = null;
            dtgCliente.ItemsSource = repositorio.LeerClientes();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombre.Text) || string.IsNullOrEmpty(txbTelefono.Text) || string.IsNullOrEmpty(txbEmail.Text) || string.IsNullOrEmpty(txbDireccion.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                clien a = new clien()
                {
                    Nombre = txbNombre.Text,
                    Direccion = txbDireccion.Text,
                    Email = txbEmail.Text,
                    Rfc = txbRfc.Text,
                    Telefono = txbTelefono.Text,
                    numCliente = txbCliente.Text,


                };
                if(repositorio.AgregarCliente(a))
                {
                    MessageBox.Show("Guardado con Éxito", "cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar al cliente ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
            {
                clien original = dtgCliente.SelectedItem as clien;
                clien a =new clien();
                a.Nombre = txbNombre.Text;
                a.Direccion = txbDireccion.Text;
                a.Email = txbEmail.Text;
                a.Rfc = txbRfc.Text;
                a.Telefono = txbTelefono.Text;
                a.numCliente = txbCliente.Text;
                if(repositorio.ModificarCliente(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su cliente a sido actualizado", "cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu cliente ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerClientes().Count == 0)
            {
                MessageBox.Show("No Hay Registros", "cliente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCliente.SelectedItem != null)
                {
                    clien a = dtgCliente.SelectedItem as clien;
                    HabilitarCajas(true);
                    txbNombre.Text = a.Nombre;
                    txbDireccion.Text = a.Direccion;
                    txbEmail.Text = a.Email;
                    txbRfc.Text = a.Rfc;
                    txbTelefono.Text = a.Telefono;
                    txbCliente.Text = a.numCliente;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿Que Cliente???", "cliente", MessageBoxButton.OK, MessageBoxImage.Question);
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
            if (repositorio.LeerClientes().Count == 0)
            {
                MessageBox.Show("No tienes clientes", "clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgCliente.SelectedItem != null)
                {
                    clien a = dtgCliente.SelectedItem as clien;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarCliente(a))
                        {
                            MessageBox.Show("Tu cliente ha sido removido", "clientes", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar a tu cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "clientes", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
