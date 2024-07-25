using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalPackages
    {
        public static async Task<List<EntPackages>> GetPackages()
        { 
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                { 
                    await con.OpenAsync();
                    using(SqlCommand cmd = new SqlCommand("GetPackages", con)) 
                    {
                        cmd.CommandType=System.Data.CommandType.StoredProcedure;
                        SqlDataReader sdr=await cmd.ExecuteReaderAsync();
                        List<EntPackages> listpackage = new List<EntPackages>();

                        while (sdr.Read()) 
                        {
                            EntPackages ebw= new EntPackages();
                            ebw.packageid = int.Parse(sdr["packageid"].ToString());
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());
                            ebw.packagename = sdr["packagename"].ToString();
                            ebw.services = sdr["servicename"].ToString();
                            ebw.price = int.Parse(sdr["price"].ToString());
                            ebw.image= sdr["image"].ToString();
                            listpackage.Add(ebw);

                        }
                        await con.CloseAsync();

                        return listpackage;

                    }
                }
            }
            catch
            {
                return null;
            }
        
        }


        public static async Task<List<EntPackages>> GetShopPackages(int id)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetShopPackages", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntPackages> listpackage = new List<EntPackages>();

                        while (sdr.Read())
                        {
                            EntPackages ebw = new EntPackages();
                            ebw.packageid = int.Parse(sdr["packageid"].ToString());
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());
                            ebw.packagename = sdr["packagename"].ToString();
                            ebw.services = sdr["servicename"].ToString();
                            ebw.price = int.Parse(sdr["price"].ToString());
                            ebw.image = sdr["image"].ToString();

                            listpackage.Add(ebw);

                        }
                        await con.CloseAsync();

                        return listpackage;

                    }
                }
            }
            catch
            {
                return null;
            }

        }
    }
}
