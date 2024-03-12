using Dapper;
using Pichonweb2.DataAccess;
using Pichonweb2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pichonweb2.Repository
{
    public class EstadoRepository
    {
        public static string Insert(string Nombre)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "1");
                    param.Add("@Nombre", Nombre);

                    var data = conn.Query<Estado>("[dbo].[SP_Estado]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public static List<Estado> GetAll()
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "2");

                    var data = conn.Query<Estado>("[dbo].[SP_Estado]", param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                    return data;
                }
            }
          
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Estado GetById(int ID)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "3");
                    param.Add("@idEstado", ID);

                    var data = conn.Query<Estado>("[dbo].[SP_Estado]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return data;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string Update(int idEstado, string Nombre)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "4");
                    param.Add("@idEstado", idEstado);
                    param.Add("@Nombre", Nombre);

                    var data = conn.Query<Estado>("[dbo].[SP_Estado]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
                    param.Add("@idEstado", Id);
                    param.Add("@opcion", "5");

                    var data = conn.Query<Estado>("[dbo].[SP_Estado]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return "OK";
                }
            }
           
            catch (Exception ex)
            {
                throw ex;
            }

        
        }
     
    }
 
}