using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        private int _Id_Ingreso;
        private string _Id_Trabajador;
        private int _Id_Proveedor;
        private DateTime _Fecha;
        private decimal _Precio_Total;
        private string _Estado;
        public int Id_Ingreso
        {
            get { return _Id_Ingreso; }
            set { _Id_Ingreso = value; }
        }
        public string Id_Trabajador
        {
            get { return _Id_Trabajador; }
            set { _Id_Trabajador = value; }
        }
        public int Id_Proveedor
        {
            get { return _Id_Proveedor; }
            set { _Id_Proveedor = value; }
        }
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public decimal Precio_Total
        {
            get { return _Precio_Total; }
            set { _Precio_Total = value; }
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        //constructor vacio
        public DIngreso()
        {

        }

        public DIngreso(int IdIngreso, string IdTrabajador, string IdProveedor, DateTime Fecha, decimal PrecioTotal, string Estado)
        {
            this.Id_Ingreso = IdIngreso;
            this.Id_Trabajador = IdTrabajador;
            this.Id_Proveedor = Id_Proveedor;
            this.Fecha = Fecha;
            this.Precio_Total = Precio_Total;
            this.Estado = Estado;
        }


        //metodos

        public string Insertar(DIngreso Ingreso, List<DDetalle_Ingreso> Detalle)
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
                SqlComando.CommandText = "Insertar_Ingreso";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id ingreso
                SqlParameter Parametro_Id_Ingreso = new SqlParameter();
                Parametro_Id_Ingreso.ParameterName = "@IdIngreso";
                Parametro_Id_Ingreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Ingreso.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Ingreso);

                //parametro id trabajador
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@IdTrabajador";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 20;
                Parametro_Id_Trabajador.Value = Ingreso.Id_Trabajador;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //parametro id proveedor
                SqlParameter Parametro_Id_Proveedor = new SqlParameter();
                Parametro_Id_Proveedor.ParameterName = "@IdProveedor";
                Parametro_Id_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Proveedor.Size = 20;
                Parametro_Id_Proveedor.Value = Ingreso.Id_Proveedor;
                SqlComando.Parameters.Add(Parametro_Id_Proveedor);

                //parametro fecha
                SqlParameter Parametro_Fecha_Ingreso = new SqlParameter();
                Parametro_Fecha_Ingreso.ParameterName = "@Fecha";
                Parametro_Fecha_Ingreso.SqlDbType = SqlDbType.Date;
                Parametro_Fecha_Ingreso.Value = Ingreso.Fecha;
                SqlComando.Parameters.Add(Parametro_Fecha_Ingreso);

                //parametro Precio Total
                SqlParameter Parametro_PrecioTotal_Ingreso = new SqlParameter();
                Parametro_PrecioTotal_Ingreso.ParameterName = "@PrecioTotal";
                Parametro_PrecioTotal_Ingreso.SqlDbType = SqlDbType.Money;
                Parametro_PrecioTotal_Ingreso.Value = Ingreso.Precio_Total;
                SqlComando.Parameters.Add(Parametro_PrecioTotal_Ingreso);

                //parametro estado
                SqlParameter Parametro_Estado = new SqlParameter();
                Parametro_Estado.ParameterName = "@Estado";
                Parametro_Estado.SqlDbType = SqlDbType.VarChar;
                Parametro_Estado.Size = 20;
                Parametro_Estado.Value = Ingreso.Estado;
                SqlComando.Parameters.Add(Parametro_Estado);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Proveedor";

                if (respuesta.Equals("OK"))
                {
                    this.Id_Ingreso = Convert.ToInt32(SqlComando.Parameters["IdIngreso"].Value);

                    foreach (DDetalle_Ingreso det in Detalle)
                    {
                        det.Id_Ingreso = this.Id_Ingreso;

                        //llamar a insertar
                        respuesta = det.Insertar(det, ref SqlConectar, ref SqlTransaccion);

                        if (!respuesta.Equals("OK"))
                        {
                            break;
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


        //Anular
        public string Anular(DIngreso Ingreso)
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
                SqlComando.CommandText = "Anular_Ingreso";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Ingreso = new SqlParameter();
                Parametro_Id_Ingreso.ParameterName = "@IdIngreso";
                Parametro_Id_Ingreso.SqlDbType = SqlDbType.Int;
                Parametro_Id_Ingreso.Value = Ingreso.Id_Ingreso;
                SqlComando.Parameters.Add(Parametro_Id_Ingreso);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el registro";

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
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Ingreso";
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
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Ingreso_Fecha";
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


        //mostrar detalle fecha
        public DataTable Mostrar_Detalle_Fecha(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Detalle_Ingreso");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Detalle_Ingreso";
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



    }
}

