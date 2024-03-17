using Dapper;
using Pichonweb2.DataAccess;
using Pichonweb2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace Pichonweb2.Repository
{
    public class ClientesRepository
    {
        public static string Insert(string Nombre, string ApellidoP, string ApellidoM, string Teléfono)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();     
                    param.Add("@opcion", "1");
                    param.Add("@Nombre", Nombre);
                    param.Add("@ApellidoP", ApellidoP);
                    param.Add("@ApellidoM", ApellidoM);
                    param.Add("@Telefono", Teléfono);
                    
                    
                    var data = conn.Query<Clientes>("[dbo].[SP_Clientes]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public static List<Clientes> GetAll()
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "2");

                    var data = conn.Query<Models.Clientes>("[dbo].[SP_Clientes]", param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                    return data;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Clientes GetById(int ID)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "3");
                    param.Add("@idClientes", ID);
                                       
                    var data = conn.Query<Clientes>("[dbo].[SP_Clientes]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return data;
                }
            }
           
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string Update(int IdCliente, string Nombre, string ApellidoP, string ApellidoM, string Teléfono)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@idClientes",IdCliente);
                    param.Add("@Nombre",Nombre);
                    param.Add("@ApellidoP",ApellidoP);
                    param.Add("@ApellidoM",ApellidoM);
                    param.Add("@Telefono",Teléfono);
                    param.Add("@opcion", "4");
                    
                    var data = conn.Query<Clientes>("[dbo].[SP_Clientes]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
                    param.Add("@idClientes", Id);
                    param.Add("@opcion", "5");

                    var data = conn.Query<Clientes>("[dbo].[SP_Clientes]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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