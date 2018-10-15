using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor
    {
        private int _Id_Proveedor;
        private string _Nombre_Proveedor;
        private string _DireccionFiscal_Proveedor;
        private string _Documento_Proveedor;
        private string _RepresentanteLegal_Proveedor;
        private string _Texto_Buscar;


        public int Id_Proveedor
        {
            get { return _Id_Proveedor; }
            set { _Id_Proveedor = value; }
        }
        public string Nombre_Proveedor
        {
            get { return _Nombre_Proveedor; }
            set { _Nombre_Proveedor = value; }
        }
        public string DireccionFiscal_Proveedor
        {
            get { return _DireccionFiscal_Proveedor; }
            set { _DireccionFiscal_Proveedor = value; }
        }
        public string Documento_Proveedor
        {
            get { return _Documento_Proveedor; }
            set { _Documento_Proveedor = value; }
        }
        public string RepresentanteLegal_Proveedor
        {
            get { return _RepresentanteLegal_Proveedor; }
            set { _RepresentanteLegal_Proveedor = value; }
        }
        public string Texto_Buscar
        {
            get { return _Texto_Buscar; }
            set { _Texto_Buscar = value; }
        }

        //constructor vacio
        public DProveedor()
        {

        }


        public DProveedor(int IdProveedor, string NombreProveedor, string DireccionFiscalProveedor, string DocumentoProveedor, string RepresentanteLegalProveedor, string TextoBuscar)
        {
            this.Id_Proveedor = IdProveedor;
            this.Nombre_Proveedor = NombreProveedor;
            this.DireccionFiscal_Proveedor = DireccionFiscalProveedor;
            this.Documento_Proveedor = DocumentoProveedor;
            this.RepresentanteLegal_Proveedor = RepresentanteLegalProveedor;
            this.Texto_Buscar = TextoBuscar;
        }

        //metodos

        //insertar
        public string Insertar(DProveedor Proveedor)
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
                SqlComando.CommandText = "Insertar_Proveedor";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Proveedor = new SqlParameter();
                Parametro_Id_Proveedor.ParameterName = "@IdProveedor";
                Parametro_Id_Proveedor.SqlDbType = SqlDbType.Int;
                Parametro_Id_Proveedor.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Proveedor);

                //parametro nombre
                SqlParameter Parametro_Nombre_Proveedor = new SqlParameter();
                Parametro_Nombre_Proveedor.ParameterName = "@NombreProveedor";
                Parametro_Nombre_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Proveedor.Size = 50;
                Parametro_Nombre_Proveedor.Value = Proveedor.Nombre_Proveedor;
                SqlComando.Parameters.Add(Parametro_Nombre_Proveedor);

                //parametro direccionfiscal
                SqlParameter Parametro_DireccionFiscal_Proveedor = new SqlParameter();
                Parametro_DireccionFiscal_Proveedor.ParameterName = "@DireccionFiscalProveedor";
                Parametro_DireccionFiscal_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_DireccionFiscal_Proveedor.Size = 250;
                Parametro_DireccionFiscal_Proveedor.Value = Proveedor.DireccionFiscal_Proveedor;
                SqlComando.Parameters.Add(Parametro_DireccionFiscal_Proveedor);

                //parametro documento
                SqlParameter Parametro_Documento_Proveedor = new SqlParameter();
                Parametro_Documento_Proveedor.ParameterName = "@DocumentoProveedor";
                Parametro_Documento_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Documento_Proveedor.Size = 50;
                Parametro_Documento_Proveedor.Value = Proveedor.Documento_Proveedor;
                SqlComando.Parameters.Add(Parametro_Documento_Proveedor);

                //parametro representantelegal
                SqlParameter Parametro_RepresentanteLegal_Proveedor = new SqlParameter();
                Parametro_RepresentanteLegal_Proveedor.ParameterName = "@RepresentanteLegalProveedor";
                Parametro_RepresentanteLegal_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_RepresentanteLegal_Proveedor.Size = 150;
                Parametro_RepresentanteLegal_Proveedor.Value = Proveedor.RepresentanteLegal_Proveedor;
                SqlComando.Parameters.Add(Parametro_RepresentanteLegal_Proveedor);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Proveedor";

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

        //editar
        public string Editar(DProveedor Proveedor)
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
                SqlComando.CommandText = "Editar_Proveedor";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //PARAMETROS

                //parametro id
                SqlParameter Parametro_Id_Proveedor = new SqlParameter();
                Parametro_Id_Proveedor.ParameterName = "@IdProveedor";
                Parametro_Id_Proveedor.SqlDbType = SqlDbType.Int;
                Parametro_Id_Proveedor.Value = Proveedor.Id_Proveedor;
                SqlComando.Parameters.Add(Parametro_Id_Proveedor);

                //parametro nombre
                SqlParameter Parametro_Nombre_Proveedor = new SqlParameter();
                Parametro_Nombre_Proveedor.ParameterName = "@NombreProveedor";
                Parametro_Nombre_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Proveedor.Size = 50;
                Parametro_Nombre_Proveedor.Value = Proveedor.Nombre_Proveedor;
                SqlComando.Parameters.Add(Parametro_Nombre_Proveedor);

                //parametro direccionfiscal
                SqlParameter Parametro_DireccionFiscal_Proveedor = new SqlParameter();
                Parametro_DireccionFiscal_Proveedor.ParameterName = "@DireccionFiscalProveedor";
                Parametro_DireccionFiscal_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_DireccionFiscal_Proveedor.Size = 250;
                Parametro_DireccionFiscal_Proveedor.Value = Proveedor.DireccionFiscal_Proveedor;
                SqlComando.Parameters.Add(Parametro_DireccionFiscal_Proveedor);

                //parametro documento
                SqlParameter Parametro_Documento_Proveedor = new SqlParameter();
                Parametro_Documento_Proveedor.ParameterName = "@DocumentoProveedor";
                Parametro_Documento_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Documento_Proveedor.Size = 50;
                Parametro_Documento_Proveedor.Value = Proveedor.Documento_Proveedor;
                SqlComando.Parameters.Add(Parametro_Documento_Proveedor);

                //parametro representantelegal
                SqlParameter Parametro_RepresentanteLegal_Proveedor = new SqlParameter();
                Parametro_RepresentanteLegal_Proveedor.ParameterName = "@RepresentanteLegalProveedor";
                Parametro_RepresentanteLegal_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_RepresentanteLegal_Proveedor.Size = 150;
                Parametro_RepresentanteLegal_Proveedor.Value = Proveedor.RepresentanteLegal_Proveedor;
                SqlComando.Parameters.Add(Parametro_RepresentanteLegal_Proveedor);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el registro de Proveedor";

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

        //Eliminar
        public string Eliminar(DProveedor Proveedor)
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
                SqlComando.CommandText = "Eliminar_Proveedor";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Proveedor = new SqlParameter();
                Parametro_Id_Proveedor.ParameterName = "@IdProveedor";
                Parametro_Id_Proveedor.SqlDbType = SqlDbType.Int;
                Parametro_Id_Proveedor.Value = Proveedor.Id_Proveedor;
                SqlComando.Parameters.Add(Parametro_Id_Proveedor);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro de proveedor";

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
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Proveedor";
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

        //Buscar representante legal
        public DataTable Buscar_RepresentanteLegal(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Proveedor_RepresentanteLegal";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar texto
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = Proveedor.Texto_Buscar;
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

        //buscar documento
        public DataTable Buscar_Documento(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Proveedor_Documento";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar texto
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = Proveedor.Texto_Buscar;
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