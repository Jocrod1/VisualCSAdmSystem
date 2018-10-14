using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulos
    {

        private int _IdArticulo;
        private string _Nombre_Articulo;
        private string _Descripcion_Articulo;
        private byte[] _Imagen_Articulo;

        private string _TextoBuscar;

        public int Id_Articulo {
            get => _IdArticulo;
            set => _IdArticulo = value;
        }
        public string Nombre_Articulo {
            get => _Nombre_Articulo;
            set => _Nombre_Articulo = value;
        }
        public string Descripcion_Articulo {
            get => _Descripcion_Articulo;
            set => _Descripcion_Articulo = value;
        }
        public byte[] Imagen_Articulo {
            get => _Imagen_Articulo;
            set => _Imagen_Articulo = value;
        }
        public string TextoBuscar{
            get => _TextoBuscar;
            set => _TextoBuscar = value;
        }

        //constructor vacio
        public DArticulos()
        {

        }

        public DArticulos(int idcategoria, string nombrearticulo, string descripcionarticulo, byte[] imagenarticulo)
        {
            this.Id_Articulo = idcategoria;
            this.Nombre_Articulo = nombrearticulo;
            this.Descripcion_Articulo = descripcionarticulo;
            this.Imagen_Articulo = imagenarticulo;
        }

        //insertar
        public string Insertar(DArticulos Articulos)
        {
            string respuesta= "";
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                //conexion con la Base de Datos
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlConectar.Open();

                //comandos
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Insertar_Articulo";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Articulo = new SqlParameter();
                Parametro_Id_Articulo.ParameterName = "@IdArticulo";
                Parametro_Id_Articulo.SqlDbType= SqlDbType.Int;
                Parametro_Id_Articulo.Direction = ParameterDirection.Output;
                SqlComando.Parameters.Add(Parametro_Id_Articulo);

                //parametro nombre
                SqlParameter Parametro_Nombre_Articulo = new SqlParameter();
                Parametro_Nombre_Articulo.ParameterName= "@NombreArticulo";
                Parametro_Nombre_Articulo.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Articulo.Size = 50;
                Parametro_Nombre_Articulo.Value = Articulos.Nombre_Articulo;
                SqlComando.Parameters.Add(Parametro_Nombre_Articulo);

                //parametro descripcion
                SqlParameter Parametro_Descripcion_Articulo = new SqlParameter();
                Parametro_Descripcion_Articulo.ParameterName = "@DescripcionArticulo";
                Parametro_Descripcion_Articulo.SqlDbType = SqlDbType.VarChar;
                Parametro_Descripcion_Articulo.Size = 256;
                Parametro_Descripcion_Articulo.Value = Articulos.Descripcion_Articulo;
                SqlComando.Parameters.Add(Parametro_Nombre_Articulo);

                //parametro imagen
                SqlParameter Parametro_Imagen_Articulo = new SqlParameter();
                Parametro_Imagen_Articulo.ParameterName = "@ImagenArticulo";
                Parametro_Imagen_Articulo.SqlDbType = SqlDbType.Image;
                Parametro_Imagen_Articulo.Value = Articulos.Imagen_Articulo;
                SqlComando.Parameters.Add(Parametro_Imagen_Articulo);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el Registro";

            }
            catch(Exception excepcion)
            {
                respuesta= excepcion.Message;
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
        public string Editar(DArticulos Articulos)
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
                SqlComando.CommandText = "Editar_Articulo";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //PARAMETROS

                //parametro id
                SqlParameter Parametro_Id_Articulo = new SqlParameter();
                Parametro_Id_Articulo.ParameterName = "@IdArticulo";
                Parametro_Id_Articulo.SqlDbType = SqlDbType.Int;
                Parametro_Id_Articulo.Value= Articulos.Id_Articulo;
                SqlComando.Parameters.Add(Parametro_Id_Articulo);

                //parametro nombre
                SqlParameter Parametro_Nombre_Articulo = new SqlParameter();
                Parametro_Nombre_Articulo.ParameterName = "@NombreArticulo";
                Parametro_Nombre_Articulo.SqlDbType = SqlDbType.VarChar;
                Parametro_Nombre_Articulo.Size = 50;
                Parametro_Nombre_Articulo.Value = Articulos.Nombre_Articulo;
                SqlComando.Parameters.Add(Parametro_Nombre_Articulo);

                //parametro descripcion
                SqlParameter Parametro_Descripcion_Articulo = new SqlParameter();
                Parametro_Descripcion_Articulo.ParameterName = "@DescripcionArticulo";
                Parametro_Descripcion_Articulo.SqlDbType = SqlDbType.VarChar;
                Parametro_Descripcion_Articulo.Size = 256;
                Parametro_Descripcion_Articulo.Value = Articulos.Descripcion_Articulo;
                SqlComando.Parameters.Add(Parametro_Nombre_Articulo);

                //parametro imagen
                SqlParameter Parametro_Imagen_Articulo = new SqlParameter();
                Parametro_Imagen_Articulo.ParameterName = "@ImagenArticulo";
                Parametro_Imagen_Articulo.SqlDbType = SqlDbType.Image;
                Parametro_Imagen_Articulo.Value = Articulos.Imagen_Articulo;
                SqlComando.Parameters.Add(Parametro_Imagen_Articulo);


                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el Registro";

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
        public string Eliminar(DArticulos Articulos)
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
                SqlComando.CommandText = "Eliminar_Articulo";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametros

                //parametro id
                SqlParameter Parametro_Id_Articulo = new SqlParameter();
                Parametro_Id_Articulo.ParameterName = "@IdArticulo";
                Parametro_Id_Articulo.SqlDbType = SqlDbType.Int;
                Parametro_Id_Articulo.Value = Articulos.Id_Articulo;
                SqlComando.Parameters.Add(Parametro_Id_Articulo);

                //ejecuta y lo envia en comentario
                respuesta = SqlComando.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el Registro";

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
            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Mostrar_Articulo";
                SqlComando.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlComando);
                SqlData.Fill(DtResultado);
            }
            catch(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
    
        }

        //Buscar
        public DataTable Buscar_Nombre(DArticulos Articulos)
        {
            DataTable DtResultado = new DataTable("Articulo");
            SqlConnection SqlConectar = new SqlConnection();

            try
            {
                SqlConectar.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlComando = new SqlCommand();
                SqlComando.Connection = SqlConectar;
                SqlComando.CommandText = "Buscar_Articulo";
                SqlComando.CommandType = CommandType.StoredProcedure;

                //parametro buscar nombre
                SqlParameter Parametro_Texto_Buscar = new SqlParameter();
                Parametro_Texto_Buscar.ParameterName = "@TextoBuscar";
                Parametro_Texto_Buscar.SqlDbType = SqlDbType.VarChar;
                Parametro_Texto_Buscar.Size = 50;
                Parametro_Texto_Buscar.Value = Articulos.TextoBuscar;
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
