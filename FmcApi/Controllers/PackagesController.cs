using Azure;
using DAL;
using Entities;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        [HttpPost]
        [Route("savepackage")]
        public async Task SavePackage(EntPackages ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@packageid",ebo.packageid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@packagename",ebo.packagename),
                new SqlParameter("@servicename",ebo.services),
                new SqlParameter("@price",ebo.price),
                new SqlParameter("@image",ebo.image)

                };
                await MyCrud.CRUD("sp_InsertPackage", sp);
            }
        }
       

        [HttpDelete]
        [Route("deletepackage/{packageid}")]
        public async Task DeletePackage(int packageid)
        {
            if (packageid != 0)
            {
                SqlParameter[] sp = {
                        new SqlParameter("@packageid",packageid)
                        };
                await MyCrud.CRUD("sp_DeletePackages", sp);
            }
        }




        [HttpPut]
        [Route("updatepackages")]
        public async Task UpdatPackage(EntPackages ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@packageid",ebo.packageid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@packagename",ebo.packagename),
                new SqlParameter("@servicename",ebo.services),
                new SqlParameter("@price",ebo.price),
                new SqlParameter("@image",ebo.image)
                };
                await MyCrud.CRUD("sp_UpdatePackage", sp);
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetPackage()
        {
            List<EntPackages> entEmployee = new List<EntPackages>();
            entEmployee = await DalPackages.GetPackages();
            return new JsonResult(entEmployee);
        }

        [HttpGet]
        [Route("getpackagesbyshopid/{shopid}")]
        public async Task<JsonResult> GetShopPackage(int shopid)
        {
            List<EntPackages> entEmployee = new List<EntPackages>();
            entEmployee = await DalPackages.GetShopPackages(shopid);
            return new JsonResult(entEmployee);
        }

    }
    
}
