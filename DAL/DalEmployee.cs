using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalEmployee
    {
        public static async Task<List<EntEmployee>> GetEmployee()
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntEmployee> listOwners = new List<EntEmployee>();
                        while (sdr.Read())
                        {
                            EntEmployee ebw = new EntEmployee();
                            ebw.empid = int.Parse(sdr["empid"].ToString());
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());
                            ebw.firstname = sdr["firstname"].ToString();
                            ebw.lastname = sdr["lastname"].ToString();
                            ebw.emptype = sdr["emptype"].ToString();
                            ebw.cnic = sdr["cnic"].ToString();
                            ebw.phone = sdr["phone"].ToString();
                            ebw.dob = sdr["dob"].ToString();
                            ebw.padress = sdr["padress"].ToString();
                            ebw.tadress = sdr["tadress"].ToString();
                            ebw.joiningdate = sdr["joiningdate"].ToString();
                            ebw.username = sdr["username"].ToString();
                            ebw.password = int.Parse(sdr["password"].ToString());
                            ebw.role = sdr["role"].ToString();  
                            ebw.enddate = sdr["enddate"].ToString();
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


        public static async Task<List<EntEmployee>> GetEmployeeShop(int id)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetShopEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntEmployee> listOwners = new List<EntEmployee>();
                        while (sdr.Read())
                        {
                            EntEmployee ebw = new EntEmployee();
                            ebw.empid = int.Parse(sdr["empid"].ToString());
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());
                            ebw.firstname = sdr["firstname"].ToString();
                            ebw.lastname = sdr["lastname"].ToString();
                            ebw.emptype = sdr["emptype"].ToString();
                            ebw.cnic = sdr["cnic"].ToString();
                            ebw.phone = sdr["phone"].ToString();
                            ebw.dob = sdr["dob"].ToString();
                            ebw.padress = sdr["padress"].ToString();
                            ebw.tadress = sdr["tadress"].ToString();
                            ebw.joiningdate = sdr["joiningdate"].ToString();
                            ebw.enddate = sdr["enddate"].ToString();
                            ebw.username = sdr["username"].ToString();
                            ebw.image = sdr["image"].ToString();
                            ebw.password = int.Parse(sdr["password"].ToString());
                            ebw.role = sdr["role"].ToString();
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

        public static async Task<EntShop> GetShopByEmpId(int id)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetShopByEmployeeId", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", id);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        EntShop eb = new EntShop();
                        while (sdr.Read())
                        {
                            eb.empid = int.Parse(sdr["empid"].ToString());
                            eb.shopid = int.Parse(sdr["shopid"].ToString());
                            eb.boid = int.Parse(sdr["boid"].ToString());
                            eb.city = sdr["city"].ToString();
                            eb.area = sdr["area"].ToString();
                            eb.phone = sdr["phone"].ToString();
                            eb.location = sdr["location"].ToString();
                            eb.logurl = sdr["logurl"].ToString();
                            eb.image = sdr["image"].ToString();
                            eb.coverimageurl = sdr["coverimageurl"].ToString();
                            eb.isactive = sdr.GetBoolean(sdr.GetOrdinal("isactive"));
                            eb.businessdescription = sdr["businessdescription"].ToString();
                        }
                        await con.CloseAsync();
                        return eb;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }


    }



}




