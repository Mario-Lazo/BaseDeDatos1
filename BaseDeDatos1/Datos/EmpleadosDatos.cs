using System.Data;
using System.Data.SqlClient;
using BaseDeDatos1.Models;  // Asegúrate de tener la referencia a los modelos

namespace BaseDeDatos1.Datos
{
    public class EmpleadosDatos
    {
        // Método para listar los empleados
        public List<EmpleadosModel> Listar()
        {
            var oLista = new List<EmpleadosModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_CRUD_Empleados", conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("@Operacion", "SELECT"));
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new EmpleadosModel
                            {
                                EmpleadoID = dr["EmpleadoID"] != DBNull.Value ? Convert.ToInt32(dr["EmpleadoID"]) : 0,
                                Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                                Edad = dr["Edad"] != DBNull.Value ? Convert.ToInt32(dr["Edad"]) : 0,
                                Departamento = dr["Departamento"] != DBNull.Value ? dr["Departamento"].ToString() : string.Empty,
                                FechaContratacion = dr["FechaContratacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaContratacion"]) : (DateTime?)null
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        // Método para obtener un empleado por ID
        public EmpleadosModel Obtener(int id)
        {
            var oEmpleado = new EmpleadosModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_CRUD_Empleados", conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("@Operacion", "SELECT"));
                    cmd.Parameters.Add(new SqlParameter("@EmpleadoID", id));
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oEmpleado.EmpleadoID = dr["EmpleadoID"] != DBNull.Value ? Convert.ToInt32(dr["EmpleadoID"]) : 0;
                            oEmpleado.Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty;
                            oEmpleado.Edad = dr["Edad"] != DBNull.Value ? Convert.ToInt32(dr["Edad"]) : 0;
                            oEmpleado.Departamento = dr["Departamento"] != DBNull.Value ? dr["Departamento"].ToString() : string.Empty;
                            oEmpleado.FechaContratacion = dr["FechaContratacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaContratacion"]) : (DateTime?)null;
                        }
                    }
                }
            }

            return oEmpleado;
        }

        // Método para guardar un empleado (INSERT)
        public bool Guardar(EmpleadosModel oEmpleado)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CRUD_Empleados", conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Operacion", "INSERT"));
                        cmd.Parameters.Add(new SqlParameter("@Nombre", oEmpleado.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@Departamento", oEmpleado.Departamento));
                        cmd.Parameters.Add(new SqlParameter("@Edad", oEmpleado.Edad));
                        cmd.Parameters.Add(new SqlParameter("@FechaContratacion", oEmpleado.FechaContratacion));
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }

                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }

        // Método para modificar un empleado (UPDATE)
        public bool Modificar(EmpleadosModel oEmpleado)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CRUD_Empleados", conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Operacion", "UPDATE"));
                        cmd.Parameters.Add(new SqlParameter("@EmpleadoID", oEmpleado.EmpleadoID));
                        cmd.Parameters.Add(new SqlParameter("@Nombre", oEmpleado.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@Departamento", oEmpleado.Departamento));
                        cmd.Parameters.Add(new SqlParameter("@Edad", oEmpleado.Edad));
                        cmd.Parameters.Add(new SqlParameter("@FechaContratacion", oEmpleado.FechaContratacion));
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }

                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }

        // Método para eliminar un empleado (DELETE)
        public bool Eliminar(int id)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CRUD_Empleados", conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Operacion", "DELETE"));
                        cmd.Parameters.Add(new SqlParameter("@EmpleadoID", id));
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.ExecuteNonQuery();
                    }

                    conexion.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
    }
}
