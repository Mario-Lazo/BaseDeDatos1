using System.Data;
using System.Data.SqlClient;
using BaseDeDatos1.Models;  // Asegúrate de tener la referencia a los modelos

namespace BaseDeDatos1.Datos
{
    public class TipoCambioDatos
    {
        // Método para listar los tipos de cambio
        public List<Models.TipoCambioModel> Listar()
        {
            var oLista = new List<Models.TipoCambioModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_CRUD_TiposDeCambio", conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("@Operacion", "SELECT"));
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Models.TipoCambioModel
                            {
                                Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                                MonedaOrigen = dr["MonedaOrigen"] != DBNull.Value ? dr["MonedaOrigen"].ToString() : string.Empty,
                                MonedaDestino = dr["MonedaDestino"] != DBNull.Value ? dr["MonedaDestino"].ToString() : string.Empty,
                                Fecha = dr["Fecha"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha"]) : (DateTime?)null,
                                TipoDeCambioCompra = dr["TipoDeCambioCompra"] != DBNull.Value ? Convert.ToDecimal(dr["TipoDeCambioCompra"]) : 0,
                                TipoDeCambioVenta = dr["TipoDeCambioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["TipoDeCambioVenta"]) : 0
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        // Método para obtener un tipo de cambio por ID
        public Models.TipoCambioModel Obtener(int id)
        {
            var oTipoCambio = new Models.TipoCambioModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("sp_CRUD_TiposDeCambio", conexion))
                {
                    cmd.Parameters.Add(new SqlParameter("@Operacion", "SELECT"));
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            oTipoCambio.Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0;
                            oTipoCambio.MonedaOrigen = dr["MonedaOrigen"] != DBNull.Value ? dr["MonedaOrigen"].ToString() : string.Empty;
                            oTipoCambio.MonedaDestino = dr["MonedaDestino"] != DBNull.Value ? dr["MonedaDestino"].ToString() : string.Empty;
                            oTipoCambio.Fecha = dr["Fecha"] != DBNull.Value ? Convert.ToDateTime(dr["Fecha"]) : (DateTime?)null;
                            oTipoCambio.TipoDeCambioCompra = dr["TipoDeCambioCompra"] != DBNull.Value ? Convert.ToDecimal(dr["TipoDeCambioCompra"]) : 0;
                            oTipoCambio.TipoDeCambioVenta = dr["TipoDeCambioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["TipoDeCambioVenta"]) : 0;
                        }
                    }
                }
            }

            return oTipoCambio;
        }

        // Método para guardar un tipo de cambio (INSERT)
        public bool Guardar(Models.TipoCambioModel oTipoCambio)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CRUD_TiposDeCambio", conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Operacion", "INSERT"));
                        cmd.Parameters.Add(new SqlParameter("@MonedaOrigen", oTipoCambio.MonedaOrigen));
                        cmd.Parameters.Add(new SqlParameter("@MonedaDestino", oTipoCambio.MonedaDestino));
                        cmd.Parameters.Add(new SqlParameter("@Fecha", oTipoCambio.Fecha));
                        cmd.Parameters.Add(new SqlParameter("@TipoDeCambioCompra", oTipoCambio.TipoDeCambioCompra));
                        cmd.Parameters.Add(new SqlParameter("@TipoDeCambioVenta", oTipoCambio.TipoDeCambioVenta));
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

        // Método para modificar un tipo de cambio (UPDATE)
        public bool Modificar(Models.TipoCambioModel oTipoCambio)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CRUD_TiposDeCambio", conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Operacion", "UPDATE"));
                        cmd.Parameters.Add(new SqlParameter("@Id", oTipoCambio.Id));
                        cmd.Parameters.Add(new SqlParameter("@MonedaOrigen", oTipoCambio.MonedaOrigen));
                        cmd.Parameters.Add(new SqlParameter("@MonedaDestino", oTipoCambio.MonedaDestino));
                        cmd.Parameters.Add(new SqlParameter("@Fecha", oTipoCambio.Fecha));
                        cmd.Parameters.Add(new SqlParameter("@TipoDeCambioCompra", oTipoCambio.TipoDeCambioCompra));
                        cmd.Parameters.Add(new SqlParameter("@TipoDeCambioVenta", oTipoCambio.TipoDeCambioVenta));
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

        public bool Eliminar(int id)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaConexion()))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_CRUD_TiposDeCambio", conexion))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Operacion", "DELETE"));
                        cmd.Parameters.Add(new SqlParameter("@Id", id));
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
