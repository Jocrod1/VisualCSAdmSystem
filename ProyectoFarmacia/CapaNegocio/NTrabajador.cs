using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTrabajador
    {
        //metodo insertar
        public static string Insertar(string Id_Trabajador, string Nombre_Trabajador, string Direccion_Trabajador, string Sexo_Trabajador, int Acceso_Trabajador, string Password_Trabajador, string Texto_Buscar)
        {
            DTrabajador Objeto = new DTrabajador();
            Objeto.Id_Trabajador = Id_Trabajador;
            Objeto.Nombre_Trabajador = Nombre_Trabajador;
            Objeto.Direccion_Trabajador = Direccion_Trabajador;
            Objeto.Sexo_Trabajador = Sexo_Trabajador;
            Objeto.Acceso_Trabajador = Acceso_Trabajador;
            Objeto.Password_Trabajador = Password_Trabajador;
            Objeto.Texto_Buscar = Texto_Buscar;
            return Objeto.Insertar(Objeto);

        }

        //Metodo Editar
        public static string Editar(string Id_Trabajador, string Nombre_Trabajador, string Direccion_Trabajador, string Sexo_Trabajador, int Acceso_Trabajador, string Password_Trabajador, string Texto_Buscar)
        {
            DTrabajador Objeto = new DTrabajador();
            Objeto.Id_Trabajador = Id_Trabajador;
            Objeto.Nombre_Trabajador = Nombre_Trabajador;
            Objeto.Direccion_Trabajador = Direccion_Trabajador;
            Objeto.Sexo_Trabajador = Sexo_Trabajador;
            Objeto.Acceso_Trabajador = Acceso_Trabajador;
            Objeto.Password_Trabajador = Password_Trabajador;
            Objeto.Texto_Buscar = Texto_Buscar;
            return Objeto.Editar(Objeto);

        }

        //Metodo Eliminar
        public static string Eliminar(string Id_Trabajador)
        {
            DTrabajador Objeto = new DTrabajador();
            Objeto.Id_Trabajador = Id_Trabajador;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        //Metodo Buscar Cedula
        public static DataTable Buscar_Cedula(string TextoBuscar)
        {
            DTrabajador Objeto = new DTrabajador();
            Objeto.Texto_Buscar = TextoBuscar;
            return Objeto.Buscar_Id(Objeto);
        }

        //Metodo Buscar Nombre
        public static DataTable Buscar_Nombre(string TextoBuscar)
        {
            DTrabajador Objeto = new DTrabajador();
            Objeto.Texto_Buscar = TextoBuscar;
            return Objeto.Buscar_Nombre(Objeto);
        }
    }
}