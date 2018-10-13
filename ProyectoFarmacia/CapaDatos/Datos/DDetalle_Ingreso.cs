using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        private int _Id_Detalle_Ingreso;
        private int _Id_Ingreso;
        private int _Id_Articulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccion;
        private DateTime _Fecha_Vencimiento;

        public int Id_Detalle_Ingreso { get => _Id_Detalle_Ingreso; set => _Id_Detalle_Ingreso = value; }
        public int Id_Ingreso { get => _Id_Ingreso; set => _Id_Ingreso = value; }
        public int Id_Articulo { get => _Id_Articulo; set => _Id_Articulo = value; }
        public decimal Precio_Compra { get => _Precio_Compra; set => _Precio_Compra = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public int Stock_Inicial { get => _Stock_Inicial; set => _Stock_Inicial = value; }
        public int Stock_Actual { get => _Stock_Actual; set => _Stock_Actual = value; }
        public DateTime Fecha_Produccion { get => _Fecha_Produccion; set => _Fecha_Produccion = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }

        //constructor vacio
        public DDetalle_Ingreso()
        {

        }

        //con parametros
        public DDetalle_Ingreso(int IdDetalleIngreso, int IdIngreso, int IdArticulo, decimal PrecioCompra, decimal PrecioVenta, int StockInicial, int StockActual, DateTime FechaProduccion, DateTime FechaVencimiento)
        {
            this.Id_Detalle_Ingreso = IdDetalleIngreso;
            this.Id_Ingreso = IdIngreso;
            this.Id_Articulo = IdArticulo;
            this.Precio_Compra = PrecioCompra;
            this.Precio_Venta = PrecioVenta;
            this.Stock_Inicial = StockInicial;
            this.Stock_Actual = StockActual;
            this.Fecha_Produccion = FechaProduccion;
            this.Fecha_Vencimiento = FechaVencimiento;
        }

        //Metodo Insertar
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso, ref SqlConnection SqlConectar, ref SqlTransaction SqlTransaccion)
        {
            string respuesta = "";

            try
            {

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "Insertar_Detalle_Ingreso";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle
                SqlParameter Parametro_Id_Detalle_Ingreso = new SqlParameter();
                Parametro_Id_Detalle_Ingreso.ParameterName = "@IdDetalleIngreso";
                Parametro_Id_Detalle_Ingreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Ingreso.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Ingreso);

                //parametro id ingreso
                SqlParameter Parametro_Id_Ingreso = new SqlParameter();
                Parametro_Id_Ingreso.ParameterName = "@IdIngreso";
                Parametro_Id_Ingreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Ingreso.Value = Detalle_Ingreso.Id_Ingreso;
                SqlComando.Parameters.Add(Parametro_Id_Ingreso);

                //parametro id articulo
                SqlParameter Parametro_Id_Articulo = new SqlParameter();
                Parametro_Id_Articulo.ParameterName = "@IdArticulo";
                Parametro_Id_Articulo.SqlDbType = SqlDbType.Int;
                Parametro_Id_Articulo.Value = Detalle_Ingreso.Id_Ingreso;
                SqlComando.Parameters.Add(Parametro_Id_Articulo);

                //parametro precio compra
                SqlParameter Parametro_Precio_Compra = new SqlParameter();
                Parametro_Precio_Compra.ParameterName = "@PrecioCompra";
                Parametro_Precio_Compra.SqlDbType = SqlDbType.Money;
                Parametro_Precio_Compra.Value = Detalle_Ingreso.Precio_Compra;
                SqlComando.Parameters.Add(Parametro_Precio_Compra);

                //parametro precio venta
                SqlParameter Parametro_Precio_Venta = new SqlParameter();
                Parametro_Precio_Venta.ParameterName = "@PrecioVenta";
                Parametro_Precio_Venta.SqlDbType = SqlDbType.Money;
                Parametro_Precio_Venta.Value = Detalle_Ingreso.Precio_Venta;
                SqlComando.Parameters.Add(Parametro_Precio_Venta);

                //parametro stock actual
                SqlParameter Parametro_Stock_Actual = new SqlParameter();
                Parametro_Stock_Actual.ParameterName = "@StockActual";
                Parametro_Stock_Actual.SqlDbType = SqlDbType.Int;
                Parametro_Stock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlComando.Parameters.Add(Parametro_Stock_Actual);

                //parametro stock inicial
                SqlParameter Parametro_Stock_Inicial = new SqlParameter();
                Parametro_Stock_Inicial.ParameterName = "@StockInicial";
                Parametro_Stock_Inicial.SqlDbType = SqlDbType.Int;
                Parametro_Stock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlComando.Parameters.Add(Parametro_Stock_Inicial);

                //parametro fecha produccion
                SqlParameter Parametro_Fecha_Produccion = new SqlParameter();
                Parametro_Fecha_Produccion.ParameterName = "@FechaProduccion";
                Parametro_Fecha_Produccion.SqlDbType = SqlDbType.Date;
                Parametro_Fecha_Produccion.Value = Detalle_Ingreso.Fecha_Produccion;
                SqlComando.Parameters.Add(Parametro_Fecha_Produccion);

                //parametro fecha vencimiento
                SqlParameter Parametro_Fecha_Vencimiento = new SqlParameter();
                Parametro_Fecha_Vencimiento.ParameterName = "@FechaVencimiento";
                Parametro_Fecha_Vencimiento.SqlDbType = SqlDbType.Date;
                Parametro_Fecha_Vencimiento.Value = Detalle_Ingreso.Fecha_Vencimiento;
                SqlComando.Parameters.Add(Parametro_Fecha_Vencimiento);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            return respuesta;

        }
    }
}
