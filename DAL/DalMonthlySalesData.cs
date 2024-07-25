using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL
{
    public class DalMonthlySalesData
    {
        public static async Task<List<EntMonthlySalesData>> GetMonthlySalesData(int shopId,int year)
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetMonthlySales", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@shopId", shopId);
                        cmd.Parameters.AddWithValue("@year", year);
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntMonthlySalesData> listmonthlysales = new List<EntMonthlySalesData>();

                        while (sdr.Read())
                        {
                            EntMonthlySalesData ebw = new EntMonthlySalesData();
                            ebw.MonthlySales = decimal.Parse(sdr["MonthlySales"].ToString());
                            ebw.MonthNumber = int.Parse(sdr["MonthNumber"].ToString());
                            ebw.YearNumber = int.Parse(sdr["YearNumber"].ToString());

                            listmonthlysales.Add(ebw);

                        }
                        await con.CloseAsync();

                        return listmonthlysales;

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

