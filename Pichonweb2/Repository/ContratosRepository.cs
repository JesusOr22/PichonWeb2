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
    public class ContratosRepository
    {
        public static string Insert(string idCliente, string idDirección, string idMunicipio, string idEstado, string FechaContrato, string FechaEvento, int Anticipo, int Precio, int Horas, string Estatus)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "1");
                    param.Add("@idCliente", idCliente);
                    param.Add("@idDirección", idDirección);
                    param.Add("@idMunicipio", idMunicipio);
                    param.Add("@idEstado", idEstado);
                    param.Add("@FechaContrato", FechaContrato);
                    param.Add ("@FechaEvento", FechaEvento);
                    param.Add ("@Anticipo", Anticipo);
                    param.Add ("@Precio", Precio);
                    param.Add ("@Horas", Horas);
                    param.Add ("@Estatus", Estatus);

                    var data = conn.Query<Contratos>("[dbo].[SP_Contratos]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public static List<Contratos> GetAll()
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "2");

                    var data = conn.Query<Contratos>("[dbo].[SP_Contratos]", param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                    return data;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static Contratos GetById(int ID)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "3");
                    param.Add("@idContrato", ID);

                    var data = conn.Query<Contratos>("[dbo].[SP_Contratos]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return data;
                }
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string Update(int idContrato, int idCliente, int idDirección, int idMunicipio, int idEstado, string FechaContrato, string FechaEvento, int Anticipo, int Precio, int Horas, string Estatus)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "4");
                    param.Add("@idContrato", idContrato);
                    param.Add("@idCliente", idCliente);
                    param.Add("@idDirección", idDirección);
                    param.Add("@idMunicipio", idMunicipio);
                    param.Add("@idEstado", idEstado);
                    param.Add("@FechaContrato", FechaContrato);
                    param.Add("@FechaEvento", FechaEvento);
                    param.Add("@Anticipo", Anticipo);
                    param.Add("@Precio", Precio);
                    param.Add("@Horas", Horas);
                    param.Add("@Estatus", Estatus);


                    var data = conn.Query<Contratos>("[dbo].[SP_Contratos]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
                    param.Add("@idContrato", Id);
                    param.Add("@opcion", "5");

                    var data = conn.Query<Contratos>("[dbo].[SP_Contratos]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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