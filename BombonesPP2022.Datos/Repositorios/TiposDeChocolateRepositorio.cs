using BombonesPP2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Datos.Repositorios
{
    public class TiposDeChocolateRepositorio
    {
        private readonly ConexionBd conexionBd;


        public TiposDeChocolateRepositorio()
        {
            conexionBd = new ConexionBd();
        }
        public List<TipoDeChocolate> GetLista()
        {
            List<TipoDeChocolate> lista = new List<TipoDeChocolate>();
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "SELECT TipoChocolateId, Chocolate, RowVersion FROM TiposDeChocolate";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoDeChocolate tipoDeChocolate = ConstruirTipoDeChocolate(reader);
                            lista.Add(tipoDeChocolate);
                        }
                    }
                }

                return lista;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        private TipoDeChocolate ConstruirTipoDeChocolate(SqlDataReader reader)
        {
            return new TipoDeChocolate()
            {
                TipoChocolateId = reader.GetInt32(0),
                Chocolate = reader.GetString(1),
                RowVersion = (byte[])reader[2]

            };
        }

        public int Agregar(TipoDeChocolate tipoDeChocolate)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "INSERT INTO TiposDeChocolate (Chocolate) VALUES (@choc)";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@choc", tipoDeChocolate.Chocolate);

                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        tipoDeChocolate.TipoChocolateId = (int)(decimal)comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM TiposDeChocolate WHERE TipoChocolateId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", tipoDeChocolate.TipoChocolateId);
                        tipoDeChocolate.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Chocolate repetido");
                }

                throw new Exception(e.Message);
            }
        }

        public int Borrar(TipoDeChocolate tipoDeChocolate)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM TiposDeChocolate WHERE TipoChocolateId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", tipoDeChocolate.TipoChocolateId);
                    comando.Parameters.AddWithValue("@r", tipoDeChocolate.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro relacionado... baja denegada");
                }
                throw new Exception(e.Message);
            }
        }

        public int Editar(TipoDeChocolate tipoDeChocolate)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexionBd.AbrirConexion())
                {
                    var cadenaComando = "UPDATE TiposDeChocolate SET Chocolate=@nom WHERE TipoChocolateId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", tipoDeChocolate.Chocolate);
                    comando.Parameters.AddWithValue("@id", tipoDeChocolate.TipoChocolateId);
                    comando.Parameters.AddWithValue("@r", tipoDeChocolate.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM TiposDeChocolate WHERE TipoChocolateId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", tipoDeChocolate.TipoChocolateId);
                        tipoDeChocolate.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Chocolate repetido");
                }
                throw new Exception(e.Message);
            }
        }
    }
}
