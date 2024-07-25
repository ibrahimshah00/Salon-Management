using Entities;
using Microsoft.AspNetCore.Components.Forms;


namespace ShopAdmin.Data
{
    public interface IMonthlySales
    {
        Task<List<EntMonthlySalesData>> GetMonthlySalesData(int id,int year);
    }
}
