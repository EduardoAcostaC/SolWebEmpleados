using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebEmpleados.Models;


namespace WebEmpleados.Datos
{
    public class D_Empleado
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        public List<Empleado> ObtenerTodos()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                //Creando una lista de empleados vacia
                List<Empleado> lista = new List<Empleado>();
                conexion.Open();

                string query = "SELECT idEmpleado, nombre, sueldo, fechaNacimiento, tiempoCompleto " +
                    "FROM Empleados;";

                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    //Creando un empleado
                    Empleado objEmpleado = new Empleado();
                    objEmpleado.idEmpleado = Convert.ToInt32(reader["idEmpleado"]);
                    objEmpleado.nombre = reader["nombre"].ToString();
                    objEmpleado.sueldo = Convert.ToDecimal(reader["sueldo"]);
                    objEmpleado.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    objEmpleado.tiempoCompleto = Convert.ToBoolean(reader["tiempoCompleto"]);

                    lista.Add(objEmpleado);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }

            
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string query = "INSERT INTO Empleados (nombre, sueldo, fechaNacimiento, tiempoCompleto) " +
                "VALUES (@parametro1, @parametro2, @parametro3, @parametro4);";

            SqlCommand comando = new SqlCommand(query, conexion);

            //Asignando valores a los parametros del query
            comando.Parameters.AddWithValue("@parametro1", empleado.nombre);
            comando.Parameters.AddWithValue("@parametro2", empleado.sueldo);
            comando.Parameters.AddWithValue("@parametro3", empleado.fechaNacimiento);
            comando.Parameters.AddWithValue("@parametro4", empleado.tiempoCompleto);

            comando.ExecuteNonQuery();

            conexion.Close();

        }

        public void EliminarEmpleado(Empleado empleado)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string query = "DELETE Empleados WHERE idEmpleado = @parametro1;";

            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.AddWithValue("@parametro1", empleado.idEmpleado);
            comando.ExecuteNonQuery();

            conexion.Close();  
        }

        public Empleado ObtenerEmpleadoPorId(int idEmpleado)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                string query = "SELECT idEmpleado, nombre, sueldo, fechaNacimiento, tiempoCompleto " +
                    "FROM Empleados WHERE idEmpleado = @parametro1;";

                SqlCommand comando = new SqlCommand( query, conexion);

                comando.Parameters.AddWithValue("@parametro1", idEmpleado);

                SqlDataReader reader = comando.ExecuteReader();

                reader.Read();

                //Creando un empleado
                Empleado objEmpleado = new Empleado();
                objEmpleado.idEmpleado = Convert.ToInt32(reader["idEmpleado"]);
                objEmpleado.nombre = reader["nombre"].ToString();
                objEmpleado.sueldo = Convert.ToDecimal(reader["sueldo"]);
                objEmpleado.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                objEmpleado.tiempoCompleto = Convert.ToBoolean(reader["tiempoCompleto"]);


                conexion.Close();
                return objEmpleado;
               
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
        

        public void EditarEmpleado(Empleado objEmpleado)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                string query = "UPDATE Empleados SET nombre = @parametro1, sueldo = @parametro2, fechaNacimiento = @parametro3, tiempoCompleto = @parametro4 " +
                    "WHERE idEmpleado = @parametro5;";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@parametro1", objEmpleado.nombre);
                comando.Parameters.AddWithValue("@parametro2", objEmpleado.sueldo);
                comando.Parameters.AddWithValue("@parametro3", objEmpleado.fechaNacimiento);
                comando.Parameters.AddWithValue("@parametro4", objEmpleado.tiempoCompleto);
                comando.Parameters.AddWithValue("@parametro5", objEmpleado.idEmpleado);

                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }

        }

        public List<Empleado> BuscarEmpleado(string texto)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            List<Empleado> lista = new List<Empleado>();
            try
            {
                conexion.Open();

                string query = "SELECT * FROM Empleados WHERE nombre LIKE @texto;";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@texto", "%" + texto + "%");


                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    //Creando un empleado
                    Empleado objEmpleado = new Empleado();
                    objEmpleado.idEmpleado = Convert.ToInt32(reader["idEmpleado"]);
                    objEmpleado.nombre = reader["nombre"].ToString();
                    objEmpleado.sueldo = Convert.ToDecimal(reader["sueldo"]);
                    objEmpleado.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    objEmpleado.tiempoCompleto = Convert.ToBoolean(reader["tiempoCompleto"]);

                    lista.Add(objEmpleado);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
        
    }
}