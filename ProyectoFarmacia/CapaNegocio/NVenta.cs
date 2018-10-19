using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class NVenta
    {
        //metodo insertar
        public static string Insertar(string IdCliente,string IdTrabajador, DateTime Fecha, decimal SubTotal, decimal Impuesto, decimal Total, DataTable DtDetalles)
        {
            DVenta Objeto = new DVenta();
            Objeto.Id_Cliente = IdCliente;
            Objeto.Id_Trabajador = IdTrabajador;
            Objeto.Fecha = Fecha;
            Objeto.SubTotal = SubTotal;
            Objeto.Impuesto = Impuesto;
            Objeto.Total = Total;
            List<DDetalle_Venta> Detalles = new List<DDetalle_Venta>();

            foreach (DataRow row in DtDetalles.Rows)
            {
                DDetalle_Venta Detalle = new DDetalle_Venta();
                Detalle.Id_Detalle_Ingreso = 0;
                Detalle.Cantidad = 2;
                Detalle.Precio_Venta = 2;
                Detalle.Descuento = 2;
                Detalles.Add(Detalle);

            }
            return Objeto.Insertar(Objeto, Detalles);
        }

        //Metodo Eliminar
        public static string Eliminar(int IdVenta)
        {
            DVenta Objeto = new DVenta();
            Objeto.Id_Venta = IdVenta;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        //Metodo Buscar por fechas
        public static DataTable Buscar_Fechas(string TextoBuscar, string TextoBuscar2)
        {
            DVenta Objeto = new DVenta();
            return Objeto.Buscar_Fechas(TextoBuscar, TextoBuscar2);
        }

        //Metodo mostrar detalle
        public static DataTable Mostrar_Detalle(string TextoBuscar)
        {
            DVenta Objeto = new DVenta();
            return Objeto.Mostrar_Detalle_Venta(TextoBuscar);
        }

        //Metodo mostrar por nombre
        public static DataTable Mostrar_Venta_Nombre(string TextoBuscar)
        {
            DVenta Objeto = new DVenta();
            return Objeto.Mostrar_Articulo_Venta_Nombre(TextoBuscar);
        }


    }
}
