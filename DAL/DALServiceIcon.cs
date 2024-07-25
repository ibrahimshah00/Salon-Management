using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALServiceIcon
    {
        public static async Task<List<ServiceIcon>> GetServiceIcon()
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetAllImages", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<ServiceIcon> listOwners = new List<ServiceIcon>();
                        while (sdr.Read())
                        {
                            ServiceIcon ebw = new ServiceIcon();
                            ebw.IconId = int.Parse(sdr["ImageId"].ToString());
                            ebw.Icon = sdr["FileName"].ToString();

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
    }
}
