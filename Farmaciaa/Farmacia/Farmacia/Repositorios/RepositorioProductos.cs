using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorios
{
    public class RepositorioProductos
    {
        ManejadorArchivos archivo;
        List<productos> pro;
        public RepositorioProductos()
        {
            archivo = new ManejadorArchivos("productos.txt");
            pro = new List<productos>();
        }

        public bool AgregarProducto(productos producto)
        {
            pro.Add(producto);
            bool resultado = ActualizarArchivo();
            pro = LeerProductos();
            return resultado;
        }

        public bool EliminarProducto(productos producto)
        {
            productos temporal = new productos();
            foreach (var item in pro)
            {
                if (item.Nombre == producto.Nombre)
                {
                    temporal = item;
                }
            }
            pro.Remove(temporal);
            bool resultado = ActualizarArchivo();
            pro = LeerProductos();
            return resultado;
        }

        public bool ModificarProduto(productos original, productos modificado)
        {
            productos temporal = new productos();
            foreach (var item in pro)
            {
                if (original.Nombre == item.Nombre)
                {
                    temporal = item;
                }
            }
            temporal.Nombre = modificado.Nombre;
            temporal.cantidad = modificado.cantidad;
            temporal.Descrpcion = modificado.Descrpcion;
            temporal.tipo = modificado.tipo;
            temporal.precioCompra = modificado.precioCompra;
            temporal.precioVenta = modificado.precioVenta;
            temporal.Presentacion = modificado.Presentacion;
            bool resultado = ActualizarArchivo();
            pro = LeerProductos();
            return resultado;
        }

        

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (productos item in pro)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}\n", item.cantidad, item.tipo, item.Nombre,  item.Descrpcion, item.Presentacion, item.precioCompra, item.precioVenta);
            }
            return archivo.Guardar(datos);
        }

        public List<productos> LeerProductos()
        {
            string datos = archivo.Leer();
            if (datos != null)
            {
                List<productos> pr = new List<productos>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    productos a = new productos()
                    {
                        cantidad = campos[0],
                        tipo = campos[1],
                        Nombre = campos[2],
                        Presentacion = campos[3],

                        Descrpcion = campos[4],
                        precioCompra = campos[5],
                        precioVenta= campos[6]
                        
                    };
                    pr.Add(a);
                }
                pro = pr;
                return pr;
            }
            else
            {
                return null;
            }
        }
    }
}

        


