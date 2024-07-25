using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalBusinessOwner
    {
        public static async Task<List<EntBusinessOwner>> GetBusinessOwners()
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetBusinessOwners", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntBusinessOwner> listOwners = new List<EntBusinessOwner>();
                        while (sdr.Read())
                        {
                            EntBusinessOwner ebw = new EntBusinessOwner();
                            ebw.boid = int.Parse(sdr["boid"].ToString());
                            ebw.firstname = sdr["firstname"].ToString();
                            ebw.lastname = sdr["lastname"].ToString();
                            ebw.emailadress = sdr["emailadress"].ToString();
                            ebw.phone = sdr["phone"].ToString();
                            ebw.cnic = sdr["cnic"].ToString();
                            ebw.username = sdr["username"].ToString();
                            ebw.password = int.Parse(sdr["password"].ToString());
                            ebw.role = sdr["role"].ToString();
                            ebw.image = sdr["image"].ToString();

                            ebw.isactive = sdr.GetBoolean(sdr.GetOrdinal("isactive"));
                            listOwners.Add(ebw);

                        }
                        await con.CloseAsync();
                        return listOwners;
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public static async Task<List<EntBusinessOwner>> GetBusinessOwnerById(int id)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetBusinessOwnerById", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntBusinessOwner> listOwners = new List<EntBusinessOwner>();
                        while (sdr.Read())
                        {
                            EntBusinessOwner ebw = new EntBusinessOwner();
                            ebw.boid = int.Parse(sdr["boid"].ToString());
                            ebw.firstname = sdr["firstname"].ToString();
                            ebw.lastname = sdr["lastname"].ToString();
                            ebw.emailadress = sdr["emailadress"].ToString();
                            ebw.phone = sdr["phone"].ToString();
                            ebw.cnic = sdr["cnic"].ToString();
                            ebw.username = sdr["username"].ToString();
                            ebw.password = int.Parse(sdr["password"].ToString());
                            ebw.role = sdr["role"].ToString();
                            ebw.image = sdr["image"].ToString();

                            ebw.isactive = sdr.GetBoolean(sdr.GetOrdinal("isactive"));
                            listOwners.Add(ebw);

                        }
                        await con.CloseAsync();
                        return listOwners;
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        //public static async Task<UserAccount> Authenticate(string username, string password)
        //{
        //    try
        //    {
        //        using (SqlConnection con = DBHelper.GetConnection())
        //        {
        //            await con.OpenAsync();

        //            using (SqlCommand cmd = new SqlCommand("sp_Authentication", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@username", username);
        //                cmd.Parameters.AddWithValue("@password", password);
        //                SqlDataReader sdr = await cmd.ExecuteReaderAsync();

        //                UserAccount entBusinessOwner = new UserAccount();
        //                while (await sdr.ReadAsync())
        //                {
        //                    entBusinessOwner.UserName = sdr["firstname"].ToString();
        //                    entBusinessOwner.Role = sdr["role"].ToString();
        //                    entBusinessOwner.BOId = sdr["boid"].ToString();
        //                    //entBusinessOwner.EmpId = sdr["empid"].ToString();

        //                }
        //                await con.CloseAsync();
        //                return entBusinessOwner;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new UserAccount();
        //    }
        //}

        //public static async Task<UserAccount> Authenticate(string username, string password)
        //{
        //    try
        //    {
        //        using (SqlConnection con = DBHelper.GetConnection())
        //        {
        //            await con.OpenAsync();

        //            using (SqlCommand cmd = new SqlCommand("sp_Employyelogin", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@username", username);
        //                cmd.Parameters.AddWithValue("@password", password);
        //                SqlDataReader sdr = await cmd.ExecuteReaderAsync();

        //                UserAccount entBusinessOwner = new UserAccount();
        //                while (await sdr.ReadAsync())
        //                {
        //                    entBusinessOwner.UserName = sdr["firstname"].ToString();
        //                    entBusinessOwner.Role = sdr["role"].ToString();
        //                    //entBusinessOwner.BOId = sdr["empid"].ToString();
        //                    entBusinessOwner.EmpId = sdr["empid"].ToString();

        //                }
        //                await con.CloseAsync();
        //                return entBusinessOwner;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return new UserAccount();
        //    }
        //}

   // } }

        public static async Task<UserAccount> Authenticate(string username, string password)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_Authentication1", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();

                        UserAccount userAccount = new UserAccount();

                        while (await sdr.ReadAsync())
                        {
                            userAccount.Role = sdr["role"].ToString();
                            userAccount.BOId = sdr["boid"].ToString();
                            userAccount.UserName = sdr["username"].ToString();

                        }
                        await con.CloseAsync();
                        return userAccount;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new UserAccount();
            }
        }


    }

}


    

