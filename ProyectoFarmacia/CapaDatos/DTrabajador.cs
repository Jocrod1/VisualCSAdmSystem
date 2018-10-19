using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador
    {
        private string _Id_Trabajador;
        private string _Nombre_Trabajador;
        private string _Direccion_Trabajador;
        private string _Sexo_Trabajador;
        private int _Acceso_Trabajador;
        private string _Password_Trabajador;
        private string _Correo_Trabajador;
        private string _Telefono_Trabajador;
        private string _Texto_Buscar;


        public string Id_Trabajador
        {
            get { return _Id_Trabajador; }
            set { _Id_Trabajador = value; }
        }
        public string Nombre_Trabajador
        {
            get { return _Nombre_Trabajador; }
            set { _Nombre_Trabajador = value; }
        }
        public string Direccion_Trabajador
        {
            get { return _Direccion_Trabajador; }
            set { _Direccion_Trabajador = value; }
        }
        public string Sexo_Trabajador
        {
            get { return _Sexo_Trabajador; }
            set { _Sexo_Trabajador = value; }
        }
        public int Acceso_Trabajador
        {
            get { return _Acceso_Trabajador; }
            set { _Acceso_Trabajador = value; }
        }
        public string Password_Trabajador
        {
            get { return _Password_Trabajador; }
            set { _Password_Trabajador = value; }
        }
        public string Correo_Trabajador
        {
            get { return _Correo_Trabajador; }
            set { _Correo_Trabajador = value; }
        }
        public string Telefono_Trabajador
        {
            get { return _Telefono_Trabajador; }
            set { _Telefono_Trabajador = value; }
        }
        public string Texto_Buscar
        {
            get { return _Texto_Buscar; }
            set { _Texto_Buscar = value; }
        }





        //constructor vacio
        public DTrabajador()
        {
        }

        public DTrabajador(string IdTrabajador, string NombreTrabajador, string DireccionTrabajador, string SexoTrabajador, int AccesoTrabajador, string PasswordTrabajador,string CorreoTrabajador, string TelefonoTrabajador, string TextoBuscar)
        {
            this.Id_Trabajador = IdTrabajador;
            this.Nombre_Trabajador = NombreTrabajador;
            this.Direccion_Trabajador = DireccionTrabajador;
            this.Sexo_Trabajador = SexoTrabajador;
            this.Acceso_Trabajador = AccesoTrabajador;
            this.Password_Trabajador = PasswordTrabajador;
            this.Correo_Trabajador = CorreoTrabajador;
            this.Telefono_Trabajador = TelefonoTrabajador;
            this.Texto_Buscar = TextoBuscar;
        }

        //metodos

        //insertar
        public string Insertar(DTrabajador Trabajador)
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
                SqlComando.CommandText = "Insertar_Trabajador";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@IdTrabajador";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 50;
                Parametro_Id_Trabajador.Value = Trabajador.Id_Trabajador;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //parametro nombre
                SqlParameter Parametro_Nombre_Trabajador = new SqlParameter();
                Parametro_Nombre_Trabajador.ParameterName = "@NombreTrabajador";
                Parametro_Nombre_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Trabajador.Size = 50;
                Parametro_Nombre_Trabajador.Value = Trabajador.Nombre_Trabajador;
                SqlComando.Parameters.Add(Parametro_Nombre_Trabajador);

                //parametro direccion
                SqlParameter Parametro_Direccion_Trabajador = new SqlParameter();
                Parametro_Direccion_Trabajador.ParameterName = "@DescripcionTrabajador";
                Parametro_Direccion_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion_Trabajador.Size = 256;
                Parametro_Direccion_Trabajador.Value = Trabajador.Direccion_Trabajador;
                SqlComando.Parameters.Add(Parametro_Direccion_Trabajador);

                //parametro sexo
                SqlParameter Parametro_Sexo_Trabajador = new SqlParameter();
                Parametro_Sexo_Trabajador.ParameterName = "@SexoTrabajador";
                Parametro_Sexo_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Sexo_Trabajador.Size = 20;
                Parametro_Sexo_Trabajador.Value = Trabajador.Sexo_Trabajador;
                SqlComando.Parameters.Add(Parametro_Sexo_Trabajador);

                //parametro acceso
                SqlParameter Parametro_Acceso_Trabajador = new SqlParameter();
                Parametro_Acceso_Trabajador.ParameterName = "@AccesoTrabajador";
                Parametro_Acceso_Trabajador.SqlDbType = SqlDbType.Int;
                Parametro_Acceso_Trabajador.Value = Trabajador.Acceso_Trabajador;
                SqlComando.Parameters.Add(Parametro_Acceso_Trabajador);

                //parametro password
                SqlParameter Parametro_Password_Trabajador = new SqlParameter();
                Parametro_Password_Trabajador.ParameterName = "@PasswordTrabajador";
                Parametro_Password_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Password_Trabajador.Size = 50;
                Parametro_Password_Trabajador.Value = Trabajador.Password_Trabajador;
                SqlComando.Parameters.Add(Parametro_Password_Trabajador);

                //parametro correo
                SqlParameter Parametro_Correo_Proveedor = new SqlParameter();
                Parametro_Correo_Proveedor.ParameterName = "@CorreoTrabajador";
                Parametro_Correo_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Correo_Proveedor.Size = 50;
                Parametro_Correo_Proveedor.Value = Trabajador.Correo_Trabajador;
                SqlComando.Parameters.Add(Parametro_Correo_Proveedor);

                //parametro telefono
                SqlParameter Parametro_Telefono_Proveedor = new SqlParameter();
                Parametro_Telefono_Proveedor.ParameterName = "@TelefonoTrabajador";
                Parametro_Telefono_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Proveedor.Size = 20;
                Parametro_Telefono_Proveedor.Value = Trabajador.Telefono_Trabajador;
                SqlComando.Parameters.Add(Parametro_Telefono_Proveedor);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Trabajador";

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
        public string Editar(DTrabajador Trabajador)
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
                SqlComando.CommandText = "Editar_Trabajador";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //PARAMETROS

                //parametro id
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@IdTrabajador";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 50;
                Parametro_Id_Trabajador.Value = Trabajador.Id_Trabajador;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);

                //parametro nombre
                SqlParameter Parametro_Nombre_Trabajador = new SqlParameter();
                Parametro_Nombre_Trabajador.ParameterName = "@NombreTrabajador";
                Parametro_Nombre_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Trabajador.Size = 50;
                Parametro_Nombre_Trabajador.Value = Trabajador.Nombre_Trabajador;
                SqlComando.Parameters.Add(Parametro_Nombre_Trabajador);

                //parametro direccion
                SqlParameter Parametro_Direccion_Trabajador = new SqlParameter();
                Parametro_Direccion_Trabajador.ParameterName = "@DescripcionTrabajador";
                Parametro_Direccion_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion_Trabajador.Size = 256;
                Parametro_Direccion_Trabajador.Value = Trabajador.Direccion_Trabajador;
                SqlComando.Parameters.Add(Parametro_Direccion_Trabajador);

                //parametro sexo
                SqlParameter Parametro_Sexo_Trabajador = new SqlParameter();
                Parametro_Sexo_Trabajador.ParameterName = "@SexoTrabajador";
                Parametro_Sexo_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Sexo_Trabajador.Size = 20;
                Parametro_Sexo_Trabajador.Value = Trabajador.Sexo_Trabajador;
                SqlComando.Parameters.Add(Parametro_Sexo_Trabajador);

                //parametro acceso
                SqlParameter Parametro_Acceso_Trabajador = new SqlParameter();
                Parametro_Acceso_Trabajador.ParameterName = "@AccesoTrabajador";
                Parametro_Acceso_Trabajador.SqlDbType = SqlDbType.Int;
                Parametro_Acceso_Trabajador.Value = Trabajador.Acceso_Trabajador;
                SqlComando.Parameters.Add(Parametro_Acceso_Trabajador);

                //parametro password
                SqlParameter Parametro_Password_Trabajador = new SqlParameter();
                Parametro_Password_Trabajador.ParameterName = "@PasswordTrabajador";
                Parametro_Password_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Password_Trabajador.Size = 50;
                Parametro_Password_Trabajador.Value = Trabajador.Password_Trabajador;
                SqlComando.Parameters.Add(Parametro_Password_Trabajador);

                //parametro correo
                SqlParameter Parametro_Correo_Proveedor = new SqlParameter();
                Parametro_Correo_Proveedor.ParameterName = "@CorreoTrabajador";
                Parametro_Correo_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Correo_Proveedor.Size = 50;
                Parametro_Correo_Proveedor.Value = Trabajador.Correo_Trabajador;
                SqlComando.Parameters.Add(Parametro_Correo_Proveedor);

                //parametro telefono
                SqlParameter Parametro_Telefono_Proveedor = new SqlParameter();
                Parametro_Telefono_Proveedor.ParameterName = "@TelefonoTrabajador";
                Parametro_Telefono_Proveedor.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Proveedor.Size = 20;
                Parametro_Telefono_Proveedor.Value = Trabajador.Telefono_Trabajador;
                SqlComando.Parameters.Add(Parametro_Telefono_Proveedor);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el registro de trabajador";

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
        public string Eliminar(DTrabajador Trabajador)
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
                SqlComando.CommandText = "Eliminar_Trabajador";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Trabajador = new SqlParameter();
                Parametro_Id_Trabajador.ParameterName = "@IdTrabajador";
                Parametro_Id_Trabajador.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Trabajador.Size = 50;
                Parametro_Id_Trabajador.Value = Trabajador.Id_Trabajador;
                SqlComando.Parameters.Add(Parametro_Id_Trabajador);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro de trabajador";

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
            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Trabajador";
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

        //Buscar nombre
        public DataTable Buscar_Nombre(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Trabajador_Nombre";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar nombre
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = Trabajador.Texto_Buscar;
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

        //buscar cedula
        public DataTable Buscar_Id(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Trabajador_Cedula";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar nombre
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = Trabajador.Texto_Buscar;
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

        public DataTable BuscarCedula(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Trabajador_CedulaT";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar nombre
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = Trabajador.Texto_Buscar;
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
