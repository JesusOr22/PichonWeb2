using Dapper;
using Pichonweb2.DataAccess;
using Pichonweb2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Pichonweb2.Repository
{
    public class DirecciónRepository
    {
        public static string Insert(int idCliente, string Calle, string Numero, int CP, int idMunicipio, int idEstado)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "1");
                    param.Add("@idCliente", idCliente);
                    param.Add("@Calle", Calle);
                    param.Add("@Numero", Numero);
                    param.Add("@CP", CP);
                    param.Add("@idMunicipio", idMunicipio);
                    param.Add("@idEstado", idEstado);

                    var data = conn.Query<Dirección>("[dbo].[SP_Dirección]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return "OK";

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Dirección> GetAll()
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "2");

                    var data = conn.Query<Models.Dirección>("[dbo].[SP_Dirección]", param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                    return data;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Dirección GetById(int ID)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "3");
                    param.Add("@idDirección", ID);

                    var data = conn.Query<Dirección>("[dbo].[SP_Dirección]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return data;
                }
            }
           
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string Update(int idDirección, int idCliente, string Calle, string Numero, int CP, int idMunicipio, int idEstado)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "4");
                    param.Add("@idDirección", idDirección);
                    param.Add("@idCliente", idCliente);
                    param.Add("@Calle", Calle);
                    param.Add("@Numero", Numero);
                    param.Add("@CP", CP);
                    param.Add("@idMunicipio", idMunicipio);
                    param.Add("@idEstado", idEstado);

                    var data = conn.Query<Dirección>("[dbo].[SP_Dirección]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return "OK";
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string DeleteById(int Id)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@idDirección", Id);
                    param.Add("@opcion", "5");

                    var data = conn.Query<Dirección>("[dbo].[SP_Dirección]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return "OK";
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}