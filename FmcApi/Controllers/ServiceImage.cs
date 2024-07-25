using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceImage : ControllerBase
    {
        [HttpPost]
        [Route("saveImage")]
        public async Task SaveImage(ServiceIcon ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@ImageId",ebo.IconId),
                new SqlParameter("@FileName",ebo.Icon),

                };
                await MyCrud.CRUD("AddNewImage", sp);
            }
        }

        [HttpDelete]
        [Route("deleteservice/{ImageId}")]
        public async Task DeleteServices(int ImageId)
        {
            if (ImageId != 0)
            {
                SqlParameter[] sp = {
                        new SqlParameter("@ImageId",ImageId)
                        };
                await MyCrud.CRUD("sp_DeleteImage", sp);
            }
        }

        [HttpPut]
        [Route("updateImage")]
        public async Task UpdatServices(ServiceIcon ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@ImageId",ebo.IconId),
                new SqlParameter("@FileName",ebo.Icon),

                };
                await MyCrud.CRUD("sp_UpdateImage", sp);
            }
        }



        [HttpGet]
        public async Task<JsonResult> GetIcon()
        {
            List<ServiceIcon> entEmployee = new List<ServiceIcon>();
            entEmployee = await DALServiceIcon.GetServiceIcon();
            return new JsonResult(entEmployee);
        }

    }
    }