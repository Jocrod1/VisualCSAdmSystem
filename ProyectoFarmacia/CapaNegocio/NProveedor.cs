using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {

        //metodo insertar
        public static string Insertar(string Nombre_Proveedor, string DireccionFiscal_Proveedor, string Documento_Proveedor, string RepresentanteLegal_Proveedor, string Texto_Buscar)
        {
            DProveedor Objeto = new DProveedor();
            Objeto.Nombre_Proveedor = Nombre_Proveedor;
            Objeto.DireccionFiscal_Proveedor = DireccionFiscal_Proveedor;
            Objeto.Documento_Proveedor = Documento_Proveedor;
            Objeto.RepresentanteLegal_Proveedor = RepresentanteLegal_Proveedor;
            Objeto.Texto_Buscar = Texto_Buscar;
            return Objeto.Insertar(Objeto);

        }

        //Metodo Editar
        public static string Editar(int Id_Proveedor, string Nombre_Proveedor, string DireccionFiscal_Proveedor, string Documento_Proveedor, string RepresentanteLegal_Proveedor, string Texto_Buscar)
        {
            DProveedor Objeto = new DProveedor();
            Objeto.Id_Proveedor = Id_Proveedor;
            Objeto.Nombre_Proveedor = Nombre_Proveedor;
            Objeto.DireccionFiscal_Proveedor = DireccionFiscal_Proveedor;
            Objeto.Documento_Proveedor = Documento_Proveedor;
            Objeto.RepresentanteLegal_Proveedor = RepresentanteLegal_Proveedor;
            Objeto.Texto_Buscar = Texto_Buscar;
            return Objeto.Editar(Objeto);

        }

        //Metodo Eliminar
        public static string Eliminar(int Id_Proveedor)
        {
            DProveedor Objeto = new DProveedor();
            Objeto.Id_Proveedor = Id_Proveedor;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Metodo Buscar Representante
        public static DataTable Buscar_Cedula(string TextoBuscar)
        {
            DProveedor Objeto = new DProveedor();
            Objeto.Texto_Buscar = TextoBuscar;
            return Objeto.Buscar_RepresentanteLegal(Objeto);
        }

        //Metodo Buscar Documento
        public static DataTable Buscar_Nombre(string TextoBuscar)
        {
            DProveedor Objeto = new DProveedor();
            Objeto.Texto_Buscar = TextoBuscar;
            return Objeto.Buscar_RepresentanteLegal(Objeto);
        }
    }
}