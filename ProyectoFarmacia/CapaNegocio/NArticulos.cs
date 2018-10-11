using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulos
    {
        //Metodo Insertar
        public static string Insertar(string Nombre_Articulo, string Descripcion_Articulo, byte[] Imagen_Articulo)
        {
            DArticulos Objeto = new DArticulos();
            Objeto.Nombre_Articulo = Nombre_Articulo;
            Objeto.Descripcion_Articulo = Descripcion_Articulo;
            Objeto.Imagen_Articulo = Imagen_Articulo;
            return Objeto.Insertar(Objeto);

        }

        //Metodo Editar
        public static string Editar(int Id_Articulo, string Nombre_Articulo, string Descripcion_Articulo, byte[] Imagen_Articulo)
        {
            DArticulos Objeto = new DArticulos();
            Objeto.Id_Articulo = Id_Articulo;
            Objeto.Nombre_Articulo = Nombre_Articulo;
            Objeto.Descripcion_Articulo = Descripcion_Articulo;
            Objeto.Imagen_Articulo = Imagen_Articulo;
            return Objeto.Editar(Objeto);

        }

        //Metodo Eliminar
        public static string Eliminar(int Id_Articulo)
        {
            DArticulos Objeto = new DArticulos();
            Objeto.Id_Articulo = Id_Articulo;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DArticulos().Mostrar();
        }

        //Metodo Buscar Nombre
        public static DataTable Buscar(string TextoBuscar)
        {
            DArticulos Objeto = new DArticulos();
            Objeto.TextoBuscar = TextoBuscar;
            return Objeto.Buscar_Nombre(Objeto);
        }


    }
}
