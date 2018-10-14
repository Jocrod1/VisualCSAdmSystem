using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    class NCliente
    {
        public static string Insertar(string Nombre_Cliente, string Direccion_Cliente, string Telefono_Cliente)
        {
            DCliente Objeto = new DCliente();
            Objeto.Nombre_Cliente = Nombre_Cliente;
            Objeto.Direccion_Cliente =Direccion_Cliente;
            Objeto.Telefono_Cliente = Telefono_Cliente;
            return Objeto.Insertar(Objeto);

        }

        //Metodo Editar
        public static string Editar(string Id_Cliente, string Nombre_Cliente, string Direccion_Cliente, string Telefono_Cliente)
        {
            DCliente Objeto = new DCliente();
            Objeto.Id_Cliente = Id_Cliente;
            Objeto.Nombre_Cliente = Nombre_Cliente;
            Objeto.Direccion_Cliente = Direccion_Cliente;
            Objeto.Telefono_Cliente = Telefono_Cliente;
            return Objeto.Editar(Objeto);

        }

        //Metodo Eliminar
        public static string Eliminar(string Id_Cliente)
        {
            DCliente Objeto = new DCliente();
            Objeto.Id_Cliente = Id_Cliente;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Metodo Buscar Cedula
        public static DataTable Buscar(string TextoBuscar)
        {
            DCliente Objeto = new DCliente();
            Objeto.Texto_Buscar = TextoBuscar;
            return Objeto.Buscar_Id(Objeto);
        }

    }
}
