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
    public class UserRepository
    {
        public static User Login(string usuario, string Contraseña )
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    User resp = new User();
                    string query = "Select * from Usuarios where Usuario='" + usuario + "' and Contraseña='" + Contraseña + "';";
                    resp = conn.Query<User>(query, commandType: CommandType.Text).FirstOrDefault();
                    conn.Close();
                    return resp;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static string Insert(User model)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "1");
                    param.Add("@Nombre",model.Nombre);
                    param.Add("@Usuario",model.Usuario);
                    param.Add("@Contraseña",model.Contraseña);
                    param.Add("@Teléfono",model.Teléfono);
                    param.Add("@Activo",model.Activo);

                    var data = conn.Query<Models.User>("[dbo].[SP_Usuarios]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public static List<User> GetAll()
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "2");

                    var data = conn.Query<Models.User>("[dbo].[SP_Usuarios]", param, commandType: CommandType.StoredProcedure).ToList();
                    conn.Close();
                    return data;
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
        public static User GetById(string idUsuarios)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "3");
                    param.Add("@idUsuarios", idUsuarios);

                    var data = conn.Query<Models.User>("[dbo].[SP_Usuarios]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    conn.Close();
                    return data;
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
        public static string Update(User model)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@opcion", "4");
                    param.Add("@idUsuarios", model.idUsuarios);
                    param.Add("@Nombre", model.Nombre);
                    param.Add("@Usuario", model.Usuario);
                    param.Add("@Contraseña", model.Contraseña);
                    param.Add("@Teléfono", model.Teléfono);
                    param.Add("@Activo", model.Activo);

                    var data = conn.Query<Models.User>("[dbo].[SP_Usuarios]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public static string DeleteById(string idUsuarios)
        {
            try
            {
                using (var conn = ConnectionDB.GetConnection)
                {
                    var param = new DynamicParameters();
                    param.Add("@idUsuarios", idUsuarios);
                    param.Add("@opcion", "5");

                    var data = conn.Query<Models.User>("[dbo].[SP_Usuarios]", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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