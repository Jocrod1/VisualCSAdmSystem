using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int _Id_Detalle_Venta;
        private int _Id_Venta;
        private int _Id_Detalle_Ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;

        public int Id_Detalle_Venta { get => _Id_Detalle_Venta; set => _Id_Detalle_Venta = value; }
        public int Id_Venta { get => _Id_Venta; set => _Id_Venta = value; }
        public int Id_Detalle_Ingreso { get => _Id_Detalle_Ingreso; set => _Id_Detalle_Ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }


        //constructor vacio
        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int IdDetalleVenta, int IdVenta, int IdDetalleIngreso, int Cantidad, decimal PrecioVenta, decimal Descuento)
        {
            this.Id_Detalle_Venta = IdDetalleVenta;
            this.Id_Venta = Id_Venta;
            this.Id_Detalle_Ingreso = IdDetalleIngreso;
            this.Cantidad = Cantidad;
            this.Precio_Venta = PrecioVenta;
            this.Descuento = Descuento;

        }


        //Metodo Insertar
        public string Insertar(DDetalle_Venta Detalle_Venta, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "Insertar_Detalle_Venta";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle venta
                SqlParameter Parametro_Id_Detalle_Venta = new SqlParameter();
                Parametro_Id_Detalle_Venta.ParameterName = "@IdDetalleVenta";
                Parametro_Id_Detalle_Venta.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Venta.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Venta);

                //parametro id venta
                SqlParameter Parametro_Id_Venta = new SqlParameter();
                Parametro_Id_Venta.ParameterName = "@IdVenta";
                Parametro_Id_Venta.SqlDbType = SqlDbType.Int;
                Parametro_Id_Venta.Value = Detalle_Venta.Id_Venta;
                SqlComando.Parameters.Add(Parametro_Id_Venta);

                //parametro id detalle ingreso
                SqlParameter Parametro_Id_Detalle_Ingreso = new SqlParameter();
                Parametro_Id_Detalle_Ingreso.ParameterName = "@IdDetalleIngreso";
                Parametro_Id_Detalle_Ingreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Ingreso.Value= Detalle_Venta._Id_Detalle_Ingreso;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Ingreso);

                //parametro cantidad
                SqlParameter Parametro_Cantidad = new SqlParameter();
                Parametro_Cantidad.ParameterName = "@Cantidad";
                Parametro_Cantidad.SqlDbType = SqlDbType.Int;
                Parametro_Cantidad.Value = Detalle_Venta.Cantidad;
                SqlComando.Parameters.Add(Parametro_Cantidad);

                //parametro precio de venta
                SqlParameter Parametro_Precio_Venta = new SqlParameter();
                Parametro_Precio_Venta.ParameterName = "@PrecioVenta";
                Parametro_Precio_Venta.SqlDbType = SqlDbType.Money;
                Parametro_Precio_Venta.Value = Detalle_Venta.Precio_Venta;
                SqlComando.Parameters.Add(Parametro_Precio_Venta);

                //parametro descuento
                SqlParameter Parametro_Descuento = new SqlParameter();
                Parametro_Descuento.ParameterName = "@Descuento";
                Parametro_Descuento.SqlDbType = SqlDbType.Money;
                Parametro_Descuento.Value = Detalle_Venta.Descuento;
                SqlComando.Parameters.Add(Parametro_Descuento);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el detalle de venta";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            return respuesta;

        }
    }
}
}
