using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorios
{
    public class RepositorioCategoria
    {
        ManejadorArchivos archivocategoria;
        List<categoria> Cat;
        public RepositorioCategoria()
        {
            archivocategoria = new ManejadorArchivos("Categoria.txt");
            Cat = new List<categoria>();
        }
        public bool Agregarcategoria(categoria Cate)
        {
            Cat.Add(Cate);
            bool resultado = ActualizarArchivo();
            Cat = LeerCat();
            return resultado;
        }

        public bool EliminarCategoria(categoria Cate)
        {
            categoria temporal = new categoria();
            foreach (var item in Cat)
            {
                if (item.TipoCategoria == Cate.TipoCategoria)
                {
                    temporal = item;
                }
            }
            Cat.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Cat = LeerCat();
            return resultado;
        }

        public bool ModificarCategoria(categoria original, categoria modificado)
        {
            categoria temporal = new categoria();
            foreach (var item in Cat)
            {
                if (original.TipoCategoria == item.TipoCategoria)
                {
                    temporal = item;
                }
            }
            temporal.TipoCategoria = modificado.TipoCategoria;
            bool resultado = ActualizarArchivo();
            Cat = LeerCat();
            return resultado;
        }

        public List<categoria> LeerCat()
        {
            string datos = archivocategoria.Leer();
            if (datos != null)
            {
                List<categoria> Ca = new List<categoria>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    categoria a = new categoria()
                    {
                        TipoCategoria = campos[0]
                        
                    };
                    Ca.Add(a);
                }
                Cat = Ca;
                return Ca;
            }
            else
            {
                return null;
            }
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (categoria item in Cat)
            {
                datos += string.Format("{0}\n", item.TipoCategoria);
            }
            return archivocategoria.Guardar(datos);
        }
    }
}
