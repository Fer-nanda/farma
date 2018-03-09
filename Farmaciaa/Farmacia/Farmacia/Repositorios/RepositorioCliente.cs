using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorios
{
    public class RepositorioCliente
    {
        ManejadorArchivos archivoCliente;
        List<clien> cli;
        public RepositorioCliente()
        {
            archivoCliente = new ManejadorArchivos("Clientes.txt");
            cli = new List<clien>();
        }

        public bool AgregarCliente(clien cliente)
        {
            cli.Add(cliente);
            bool resultado = ActualizarArchivo();
            cli = LeerClientes();
            return resultado;
        }

        

        public bool EliminarCliente(clien cliente)
        {
           clien temporal = new clien();
            foreach (var item in cli)
            {
                if (item.Telefono == cliente.Telefono)
                {
                    temporal = item;
                }
            }
            cli.Remove(temporal);
            bool resultado = ActualizarArchivo();
            cli = LeerClientes();
            return resultado;
        }

        public bool ModificarCliente(clien original, clien modificado)
        {
            clien temporal = new clien();
            foreach (var item in cli)
            {
                if (original.Telefono == item.Telefono)
                {
                    temporal = item;
                }
            }
            temporal.Nombre = modificado.Nombre;
            temporal.Direccion = modificado.Direccion;
            temporal.Rfc = modificado.Rfc;
            temporal.Telefono = modificado.Telefono;
            temporal.Email = modificado.Email;
            temporal.numCliente = modificado.numCliente;
            bool resultado = ActualizarArchivo();
            cli = LeerClientes();
            return resultado;
        }
        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (clien item in cli)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}\n", item.numCliente, item.Nombre, item.Direccion, item.Email, item.Telefono, item.Rfc);
            }
            return archivoCliente.Guardar(datos);
        }
        public List<clien> LeerClientes()
        {
            string datos = archivoCliente.Leer();
            if (datos != null)
            {
                List<clien> ami = new List<clien>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    clien a = new clien()
                    {
                        numCliente= campos[0],
                        Nombre = campos[1],
                        Direccion = campos[2],
                        Email = campos[3],
                        Telefono = campos[4],
                        Rfc = campos[5]
                        
                      
                    };
                    ami.Add(a);
                }
                cli = ami;
                return ami;
            }
            else
            {
                return null;
            }
        }

        
    }
}
