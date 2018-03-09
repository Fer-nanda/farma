using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorios
{
    public class RepositorioEmpleados
    {
        ManejadorArchivos archivoEmpleados;
        List<emple> empleados;
        public RepositorioEmpleados()
        {
            archivoEmpleados = new ManejadorArchivos("Empleados.txt");
            empleados = new List<emple>();
        }

        public bool AgregarEmpleados(emple emplea)
        {
            empleados.Add(emplea);
            bool resultado = ActualizarArchivo();
            empleados = LeerEmpleados();
            return resultado;
        }

        public bool EliminarEmplados(emple emplea)
        {
            emple temporal = new emple();
            foreach (var item in empleados)
            {
                if (item.Telefono == emplea.Telefono)
                {
                    temporal = item;
                }
            }
           empleados.Remove(temporal);
            bool resultado = ActualizarArchivo();
            empleados = LeerEmpleados();
            return resultado;
        }

        public bool ModificarEmpleados(emple original, emple modificado)
        {
            emple temporal = new emple();
            foreach (var item in empleados)
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
            temporal.Matricula = modificado.Matricula;
            temporal.puesto = modificado.puesto;
            bool resultado = ActualizarArchivo();
            empleados = LeerEmpleados();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (emple item in empleados)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}\n", item.Matricula, item.puesto, item.Nombre, item.Direccion, item.Telefono, item.Email, item.Rfc);
            }
            return archivoEmpleados.Guardar(datos);
        }

        public List<emple> LeerEmpleados()
        {
            string datos = archivoEmpleados.Leer();
            if (datos != null)
            {
                List<emple> empleado = new List<emple>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    emple a = new emple()
                    {
                        Matricula = campos[0],
                        puesto = campos[1],
                        Nombre = campos[2],
                        Direccion = campos[3],
       
                        Telefono = campos[4],
                        Email = campos[5],
                        
                        Rfc = campos[6]
                        
                        
                        
                        
                    };
                    empleado.Add(a);
                }
               empleados = empleado;
                return empleado;
            }
            else
            {
                return null;
            }
        }

        
    }
}
