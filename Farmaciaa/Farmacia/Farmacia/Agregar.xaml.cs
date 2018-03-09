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
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Window
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void btnCategoria_Click(object sender, RoutedEventArgs e)
        {
            Categoria MiVentana = new Categoria();
            MiVentana.Owner = this;
            MiVentana.ShowDialog();
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
           Produc MiVentana = new Produc();
            MiVentana.Owner = this;
            MiVentana.ShowDialog();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente MiVentana = new Cliente();
            MiVentana.Owner = this;
            MiVentana.ShowDialog();
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            empleados MiVentana = new empleados();
            MiVentana.Owner = this;
            MiVentana.ShowDialog();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
