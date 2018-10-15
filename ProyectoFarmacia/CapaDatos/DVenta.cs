using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        private int _Id_Venta;
        private string _Id_Cliente;
        private string _Id_Trabajador;
        private DateTime _Fecha;
        private decimal _SubTotal;
        private decimal _Impuesto;
        private decimal _Total;


        public int Id_Venta
        {
            get { return _Id_Venta; }
            set { _Id_Venta = value; }
        }
        public string Id_Cliente
        {
            get { return _Id_Cliente; }
            set { _Id_Cliente = value; }
        }
        public string Id_Trabajador
        {
            get { return _Id_Trabajador; }
            set { _Id_Trabajador = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }
        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }



        //constructor vacio
        public DVenta()
        {

        }

        public DVenta(int IdVenta, string IdCliente, string IdTrabajador, DateTime Fecha, decimal SubTotal, decimal Impuesto, decimal Total)
        {
            this.Id_Venta = IdVenta;
            this.Id_Cliente = IdCliente;
            this.Id_Trabajador = IdTrabajador;
            this.Fecha = Fecha;
            this.SubTotal = SubTotal;
            this.Impuesto = Impuesto;
            this.Total = Total;
        }

        //metodos

        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //transaccion
                SqlTransaction SqlTransaccion = SqlConectar.BeginTransaction();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.Transaction = SqlTransaccion;
                SqlComando.CommandText = "Insertar_Venta";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id venta
                SqlParameter Parametro_Id_Venta = new SqlParameter();
                Parametro_Id_Venta.ParameterName = "@IdVenta";
                Parametro_Id_Venta.SqlDbType = SqlDbType.Int;
                Parametro_Id_Venta.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Venta);

                //parametro id cliente
                SqlParameter Parametro_Id_Cliente = new SqlParameter();
                Parametro_Id_Cliente.ParameterName = "@IdCliente";
                Parametro_Id_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Cliente.Size = 20;
                Parametro_Id_Cliente.Value = Venta.Id_Cliente;
                SqlComando.Parameters.Add(Parametro_Id_Cliente);

                //parametro id trabajador 
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@IdTrabajador";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 20;
                Parametro_Id_Trabajador.Value = Venta.Id_Trabajador;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //parametro fecha
                SqlParameter Parametro_Fecha_Venta = new SqlParameter();
                Parametro_Fecha_Venta.ParameterName = "@Fecha";
                Parametro_Fecha_Venta.SqlDbType = SqlDbType.Date;
                Parametro_Fecha_Venta.Value = Venta.Fecha;
                SqlComando.Parameters.Add(Parametro_Fecha_Venta);

                //parametro subtotal
                SqlParameter Parametro_SubTotal_Venta = new SqlParameter();
                Parametro_SubTotal_Venta.ParameterName = "@SubTotal";
                Parametro_SubTotal_Venta.SqlDbType = SqlDbType.Money;
                Parametro_SubTotal_Venta.Value = Venta.SubTotal;
                SqlComando.Parameters.Add(Parametro_SubTotal_Venta);

                //parametro impuesto
                SqlParameter Parametro_Impuesto_Venta = new SqlParameter();
                Parametro_Impuesto_Venta.ParameterName = "@Impuesto";
                Parametro_Impuesto_Venta.SqlDbType = SqlDbType.Money;
                Parametro_Impuesto_Venta.Value = Venta.Impuesto;
                SqlComando.Parameters.Add(Parametro_Impuesto_Venta);

                //parametro total
                SqlParameter Parametro_Total_Venta = new SqlParameter();
                Parametro_Total_Venta.ParameterName = "@PrecioTotal";
                Parametro_Total_Venta.SqlDbType = SqlDbType.Money;
                Parametro_Total_Venta.Value = Venta.Total;
                SqlComando.Parameters.Add(Parametro_Total_Venta);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Proveedor";

                if (respuesta.Equals("OK"))
                {
                    this.Id_Venta = Convert.ToInt32(SqlComando.Parameters["IdVenta"].Value);

                    foreach (DDetalle_Venta det in Detalle)
                    {
                        det.Id_Venta = this.Id_Venta;

                        //llamar a insertar
                        respuesta = det.Insertar(det, ref SqlConectar, ref SqlTransaccion);

                        if (!respuesta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //se actualiza el stock
                            respuesta = Disminuir_Stock(det.Id_Detalle_Ingreso, det.Cantidad);

                            if(!respuesta.Equals("OK"))
                            {
                                //para que salga del bucle
                                break;
                            }
                        }

                    }
                }

                if (respuesta.Equals("OK"))
                {
                    SqlTransaccion.Commit();
                }
                else
                {
                    //si se recibe una espuesta contraria a ok negamos la transaccion
                    SqlTransaccion.Rollback();
                }


            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            //se cierra la conexion de la Base de Datos
            finally
            {
                if (SqlConectar.State == ConnectionState.Open)
                {
                    SqlConectar.Close();
                }
            }
            return respuesta;

        }

        //metodo eliminar
        public string Eliminar(DVenta Venta)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Eliminar_Venta";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Venta = new SqlParameter();
                Parametro_Id_Venta.ParameterName = "@IdVenta";
                Parametro_Id_Venta.SqlDbType = SqlDbType.Int;
                Parametro_Id_Venta.Value = Venta.Id_Venta;
                SqlComando.Parameters.Add(Parametro_Id_Venta);


                //ejecuta y lo envia en comentario
                //se coloca ok en ambas partes porque se puede ejecutar el codigo, eliminar el item pero decir que no lo hizo
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "OK";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            //se cierra la conexion de la Base de Datos
            finally
            {
                if (SqlConectar.State == ConnectionState.Open)
                {
                    SqlConectar.Close();
                }
            }
            return respuesta;

        }

        //Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Venta";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComando);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //Buscar fechas
        public DataTable Buscar_Fechas(string TextoBuscar, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Venta_Fecha";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar texto
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = TextoBuscar;
                SqlComando.Parameters.Add(Parametro_Texto_Buscar);

                //parametro buscar texto 2
                SqlParameter Parametro_Texto_Buscar2 = new SqlParameter();
                Parametro_Texto_Buscar2.ParameterName = "@TextoBuscar2";
                Parametro_Texto_Buscar2.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar2.Size = 50;
                Parametro_Texto_Buscar2.Value = TextoBuscar2;
                SqlComando.Parameters.Add(Parametro_Texto_Buscar2);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComando);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //mostrar detalle venta
        public DataTable Mostrar_Detalle_Venta(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Detalle_Venta");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Detalle_Venta";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar texto
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = TextoBuscar;
                SqlComando.Parameters.Add(Parametro_Texto_Buscar);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComando);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //mostrar articulos por nombre
        public DataTable Mostrar_Articulo_Venta_Nombre(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Articulo_Venta_Nombre";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar texto
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = TextoBuscar;
                SqlComando.Parameters.Add(Parametro_Texto_Buscar);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComando);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        //metodo disminuir stock
        public string Disminuir_Stock(int IdDetalleIngreso, int Cantidad)
        {
            string respuesta = "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Disminuir_Stock";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id detalle ingreso
                SqlParameter Parametro_Id_Detalle_Ingreso = new SqlParameter();
                Parametro_Id_Detalle_Ingreso.ParameterName = "@IdDetalleIngreso";
                Parametro_Id_Detalle_Ingreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Detalle_Ingreso.Value = IdDetalleIngreso;
                SqlComando.Parameters.Add(Parametro_Id_Detalle_Ingreso);

                //parametro cantidad
                SqlParameter Parametro_Cantidad = new SqlParameter();
                Parametro_Cantidad.ParameterName = "@Cantidad";
                Parametro_Cantidad.SqlDbType = SqlDbType.Int;
                Parametro_Cantidad.Value = Cantidad;
                SqlComando.Parameters.Add(Parametro_Cantidad);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el stock";

            }
            catch (Exception excepcion)
            {
                respuesta = excepcion.Message;
            }

            //se cierra la conexion de la Base de Datos
            finally
            {
                if (SqlConectar.State == ConnectionState.Open)
                {
                    SqlConectar.Close();
                }
            }
            return respuesta;

        }
    }
}

