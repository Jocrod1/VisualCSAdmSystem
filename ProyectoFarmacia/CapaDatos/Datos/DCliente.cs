using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private string _Id_Cliente;
        private string _Nombre_Cliente;
        private string _Direccion_Cliente;
        private string _Telefono_Cliente;
        private string _TextoBuscar;

        public string Id_Cliente { get => _Id_Cliente; set => _Id_Cliente = value; }
        public string Nombre_Cliente { get => _Nombre_Cliente; set => _Nombre_Cliente = value; }
        public string Direccion_Cliente { get => _Direccion_Cliente; set => _Direccion_Cliente = value; }
        public string Telefono_Cliente { get => _Telefono_Cliente; set => _Telefono_Cliente = value; }
        public string Texto_Buscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //constructor vacio
        public DCliente()
        {

        }

        public DCliente(string IdCliente, string NombreCliente, string DireccionCliente, string TelefonoCliente, string TextoBuscar)
        {
            this.Id_Cliente = IdCliente;
            this.Nombre_Cliente = NombreCliente;
            this.Direccion_Cliente = DireccionCliente;
            this.Telefono_Cliente = TelefonoCliente;
            this.Texto_Buscar = TextoBuscar;
        }

        //Metodos

        //insertar
        public string Insertar(DCliente Cliente)
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
                SqlComando.CommandText = "Insertar_Cliente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Cliente = new SqlParameter();
                Parametro_Id_Cliente.ParameterName = "@IdCliente";
                Parametro_Id_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Cliente.Size = 50;
                Parametro_Id_Cliente.Value = Cliente.Id_Cliente;
                SqlComando.Parameters.Add(Parametro_Id_Cliente);

                //parametro nombre
                SqlParameter Parametro_Nombre_Cliente = new SqlParameter();
                Parametro_Nombre_Cliente.ParameterName = "@NombreCliente";
                Parametro_Nombre_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Cliente.Size = 50;
                Parametro_Nombre_Cliente.Value = Cliente.Nombre_Cliente;
                SqlComando.Parameters.Add(Parametro_Nombre_Cliente);

                //parametro direccion
                SqlParameter Parametro_Direccion_Cliente = new SqlParameter();
                Parametro_Direccion_Cliente.ParameterName = "@DescripcionCliente";
                Parametro_Direccion_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion_Cliente.Size = 256;
                Parametro_Direccion_Cliente.Value = Cliente.Direccion_Cliente;
                SqlComando.Parameters.Add(Parametro_Direccion_Cliente);

                //parametro telefono
                SqlParameter Parametro_Telefono_Cliente = new SqlParameter();
                Parametro_Telefono_Cliente.ParameterName = "@TelefonoCliente";
                Parametro_Telefono_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Cliente.Size = 15;
                Parametro_Telefono_Cliente.Value = Cliente.Telefono_Cliente;
                SqlComando.Parameters.Add(Parametro_Telefono_Cliente);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro del Cliente";

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
        public string Editar(DCliente Cliente)
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
                SqlComando.CommandText = "Editar_Cliente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //PARAMETROS

                //parametro id
                SqlParameter Parametro_Id_Cliente = new SqlParameter();
                Parametro_Id_Cliente.ParameterName = "@IdCliente";
                Parametro_Id_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Cliente.Size = 50;
                Parametro_Id_Cliente.Value= Cliente.Id_Cliente;
                SqlComando.Parameters.Add(Parametro_Id_Cliente);

                //parametro nombre
                SqlParameter Parametro_Nombre_Cliente = new SqlParameter();
                Parametro_Nombre_Cliente.ParameterName = "@NombreCliente";
                Parametro_Nombre_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Cliente.Size = 50;
                Parametro_Nombre_Cliente.Value = Cliente.Nombre_Cliente;
                SqlComando.Parameters.Add(Parametro_Nombre_Cliente);

                //parametro direccion
                SqlParameter Parametro_Direccion_Cliente = new SqlParameter();
                Parametro_Direccion_Cliente.ParameterName = "@DireccionCliente";
                Parametro_Direccion_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Direccion_Cliente.Size = 256;
                Parametro_Direccion_Cliente.Value = Cliente.Direccion_Cliente;
                SqlComando.Parameters.Add(Parametro_Direccion_Cliente);

                //parametro telefono
                SqlParameter Parametro_Telefono_Cliente = new SqlParameter();
                Parametro_Telefono_Cliente.ParameterName = "@TelefonoCliente";
                Parametro_Telefono_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Telefono_Cliente.Size = 15;
                Parametro_Telefono_Cliente.Value = Cliente.Telefono_Cliente;
                SqlComando.Parameters.Add(Parametro_Telefono_Cliente);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se edito el registro de cliente";

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
        public string Eliminar(DCliente Cliente)
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
                SqlComando.CommandText = "Eliminar_Cliente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Cliente = new SqlParameter();
                Parametro_Id_Cliente.ParameterName = "@IdCliente";
                Parametro_Id_Cliente.SqlDbType = SqlDbType.VarChar;
                Parametro_Id_Cliente.Size = 50;
                Parametro_Id_Cliente.Value = Cliente.Id_Cliente;
                SqlComando.Parameters.Add(Parametro_Id_Cliente);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro de cliente";

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
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Cliente";
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

        //Buscar cedula
        public DataTable Buscar_Id(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Cliente";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar nombre
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = Cliente.Texto_Buscar;
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
