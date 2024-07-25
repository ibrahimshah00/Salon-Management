using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalUserInfo
    {
        public static async Task<List<EntUser>> GetUserInfo(int id)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetUserInfo", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntUser> listServices = new List<EntUser>();
                        while (sdr.Read())
                        {
                            EntUser ebw = new EntUser();
                            ebw.number = sdr["number"].ToString();
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());

                            if (sdr["dtime"] != DBNull.Value && sdr["dtime"] != null)
                            {
                                ebw.datetime = DateTime.Parse(sdr["dtime"].ToString());
                            }
                            else
                            {
                                // Handle the case where the database value is NULL
                                // You might set a default value, log an error, or take another appropriate action
                                ebw.datetime = DateTime.MinValue; // Default value, for example
                            }
                            ebw.employee=sdr["employee"].ToString();
                            ebw.name = sdr["name"].ToString();
                            ebw.amount = sdr["total"].ToString();
                            listServices.Add(ebw);
                        }

                        await con.CloseAsync();
                        return listServices;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public static async Task<List<EntUser>> GetUserInfobyemployee(string name)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_employeework", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@employee", name);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntUser> listServices = new List<EntUser>();
                        while (sdr.Read())
                        {
                            EntUser ebw = new EntUser();
                            ebw.number = sdr["number"].ToString();
                           
                            if (sdr["dtime"] != DBNull.Value && sdr["dtime"] != null)
                            {
                                ebw.datetime = DateTime.Parse(sdr["dtime"].ToString());
                            }
                            else
                            {
                                ebw.datetime = DateTime.MinValue; 
                            }
                           
                            ebw.name = sdr["name"].ToString();
                            ebw.amount = sdr["total"].ToString();
                            listServices.Add(ebw);
                        }

                        await con.CloseAsync();
                        return listServices;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public static async Task<List<EntUser>> Getemployeeworkbyday(string name,string date)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_employeeworkbydatee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@employee", name);
                        cmd.Parameters.AddWithValue("@dateValue", date);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntUser> listServices = new List<EntUser>();
                        while (sdr.Read())
                        {
                            EntUser ebw = new EntUser();
                            ebw.number = sdr["number"].ToString();

                            if (sdr["dtime"] != DBNull.Value && sdr["dtime"] != null)
                            {
                                ebw.datetime = DateTime.Parse(sdr["dtime"].ToString());
                            }
                            else
                            {
                                ebw.datetime = DateTime.MinValue;
                            }

                            ebw.name = sdr["name"].ToString();
                            ebw.amount = sdr["total"].ToString();
                            listServices.Add(ebw);
                        }

                        await con.CloseAsync();
                        return listServices;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
    }



    }


