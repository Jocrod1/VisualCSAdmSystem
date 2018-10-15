using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        //metodo insertar
        public static string Insertar(string IdTrabajador, int IdProveedor, DateTime Fecha, decimal PrecioTotal, string Estado, DataTable DtDetalles)
        {
            DIngreso Objeto = new DIngreso();
            Objeto.Id_Trabajador = IdTrabajador;
            Objeto.Id_Proveedor = IdProveedor;
            Objeto.Fecha = Fecha;
            Objeto.Precio_Total = PrecioTotal;
            Objeto.Estado = Estado;
            List<DDetalle_Ingreso> Detalles = new List<DDetalle_Ingreso>();

            foreach (DataRow row in DtDetalles.Rows)
            {
                DDetalle_Ingreso Detalle = new DDetalle_Ingreso();
                Detalle.Id_Articulo = Convert.ToInt32(row["Id_Articulo"].ToString());
                Detalle.Precio_Compra = Convert.ToDecimal(row["Precio_Compra"].ToString());
                Detalle.Precio_Venta = Convert.ToDecimal(row["Precio_Venta"].ToString());
                Detalle.Stock_Inicial = Convert.ToInt32(row["Stock_Inicial"].ToString());
                Detalle.Stock_Actual = Convert.ToInt32(row["Stock_Inicial"].ToString());
                Detalle.Fecha_Produccion = Convert.ToDateTime(row["Fecha_Produccion"].ToString());
                Detalle.Fecha_Vencimiento = Convert.ToDateTime(row["Fecha_Vencimiento"].ToString());

                Detalles.Add(Detalle);

            }
            return Objeto.Insertar(Objeto, Detalles);
        }

        //Metodo Anular
        public static string Anular(int Id_Ingreso)
        {
            DIngreso Objeto = new DIngreso();
            Objeto.Id_Ingreso = Id_Ingreso;
            return Objeto.Anular(Objeto);
        }

        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //Metodo Buscar por fechas
        public static DataTable Buscar_Fechas(string TextoBuscar, string TextoBuscar2)
        {
            DIngreso Objeto = new DIngreso();
            return Objeto.Buscar_Fechas(TextoBuscar, TextoBuscar2);
        }

        //Metodo mostrar detalle
        public static DataTable Mostrar_Detalle(string TextoBuscar)
        {
            DIngreso Objeto = new DIngreso();
            return Objeto.Mostrar_Detalle_Fecha(TextoBuscar);
        }


    }
}
