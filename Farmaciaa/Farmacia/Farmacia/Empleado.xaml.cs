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
    /// Lógica de interacción para Empleado.xaml
    /// </summary>
    public partial class empleados : Window
    {
        Repositorios.RepositorioEmpleados repositorio;
        bool esNuevo;
        public empleados()
        {
            InitializeComponent();
            repositorio = new Repositorios.RepositorioEmpleados();
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
            txbPuesto.Clear();
            txbMatricula.Clear();
            txbNombre.IsEnabled = habilitadas;
            txbDireccion.IsEnabled = habilitadas;
            txbEmail.IsEnabled = habilitadas;
            txbRfc.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbMatricula.IsEnabled = habilitadas;
            txbPuesto.IsEnabled = habilitadas;
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
            dtgEmplados.ItemsSource = null;
            dtgEmplados.ItemsSource = repositorio.LeerEmpleados();
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

                emple a = new emple()
                {
                    Nombre = txbNombre.Text,
                    Direccion = txbDireccion.Text,
                    Email = txbEmail.Text,
                    Rfc = txbRfc.Text,
                    Telefono = txbTelefono.Text,
                    puesto= txbPuesto.Text,
                    Matricula=txbMatricula.Text,


                };
                if(repositorio.AgregarEmpleados(a))
                {
                    MessageBox.Show("Guardado con Éxito", "empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar al empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
            else
            {
                emple original = dtgEmplados.SelectedItem as emple;
                emple a = dtgEmplados.SelectedItem as emple;
                a.Nombre = txbNombre.Text;
                a.Direccion = txbDireccion.Text;
                a.Email = txbEmail.Text;
                a.Rfc = txbRfc.Text;
                a.Telefono = txbTelefono.Text;
                a.puesto = txbPuesto.Text;
                a.Matricula = txbMatricula.Text;
                if (repositorio.ModificarEmpleados(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su empleado a sido actualizado", "empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar al empleado ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                    
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerEmpleados().Count == 0)
            {
                MessageBox.Show("No Hay Registros", "empleado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmplados.SelectedItem != null)
                {
                    emple a = dtgEmplados.SelectedItem as emple;
                    HabilitarCajas(true);
                    txbNombre.Text = a.Nombre;
                    txbDireccion.Text = a.Direccion;
                    txbEmail.Text = a.Email;
                    txbRfc.Text = a.Rfc;
                    txbTelefono.Text = a.Telefono;
                    txbPuesto.Text = a.puesto;
                    txbMatricula.Text = a.Matricula;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿Que Empleado???", "empleado", MessageBoxButton.OK, MessageBoxImage.Question);
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
            if (repositorio.LeerEmpleados().Count == 0)
            {
                MessageBox.Show("No Hay Registros", "cliente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgEmplados.SelectedItem != null)
                {
                    emple a = dtgEmplados.SelectedItem as emple;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        if (repositorio.EliminarEmplados(a))
                        {
                            MessageBox.Show("El Empleado ha sido removida", "empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar al empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                            
                    }
                }
                else
                {
                    MessageBox.Show("¿Que empleado???", "empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
