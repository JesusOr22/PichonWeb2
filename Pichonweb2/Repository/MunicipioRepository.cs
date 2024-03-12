using Dapper;
using Pichonweb2.DataAccess;
using Pichonweb2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pichonweb2.Repository
{
    public class MunicipioRepository
    {
        public static string Insert(string Nombre, int idEstado)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "1");
                    param.Add("@Nombre", Nombre);
                    param.Add("@idEstado", idEstado);

                    var data = conn.Query<Municipio>("[dbo].[SP_Municipio]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public static List<Municipio> GetAll()
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "2");

                    var data = conn.Query<Municipio>("[dbo].[SP_Municipio]", param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                    return data;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Municipio GetById(int ID)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "3");
                    param.Add("@idMunicipio", ID);

                    var data = conn.Query<Municipio>("[dbo].[Municipio]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return data;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string Update(int idMunicipio, string Nombre, int idEstado)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "4");
                    param.Add("@idMunicipio", idMunicipio);                    
                    param.Add("@Nombre", Nombre);
                    param.Add("@idEstado", idEstado);


                    var data = conn.Query<Municipio>("[dbo].[SP_Municipio]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
                    param.Add("@idMunicipio", Id);
                    param.Add("@opcion", "5");

                    var data = conn.Query<Municipio>("[dbo].[SP_Municipio]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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