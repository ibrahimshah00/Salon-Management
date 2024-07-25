using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessOwnerController : ControllerBase
    {
        [HttpPost]
        [Route("savebo")]
        public async Task SaveOwnerInfo(EntBusinessOwner ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@boid",ebo.boid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@emailadress",ebo.emailadress),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@isactive",ebo.isactive),
                new SqlParameter("@username",ebo.username),
                new SqlParameter("@password",ebo.password),
                new SqlParameter("@role",ebo.role),
                new SqlParameter("@image",ebo.image)
                };
                await MyCrud.CRUD("InsertBusinessOwner", sp);
            }
        }

        [HttpDelete]
        [Route("deleteowner/{BOId}")]
        public async Task DeleteOwnerInfo(int BOId)
        {
            if (BOId != 0)
            {
                SqlParameter[] sp = {
                new SqlParameter("@boid",BOId)
                };
                await MyCrud.CRUD("DeleteBusinessOwner", sp);
            }
        }


        [HttpPut]
            [Route("updateowner")]
        public async Task UpdateOwnerInfo(EntBusinessOwner ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@boid",ebo.boid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@emailadress",ebo.emailadress),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@isactive",ebo.isactive),
                new SqlParameter("@username",ebo.username),
                new SqlParameter("@password",ebo.password),
                 new SqlParameter("@image",ebo.image),
                new SqlParameter("@role",ebo.role)
                };
                await MyCrud.CRUD("UpdateBusinessOwner", sp);
            }
        }
        [HttpGet]
        [Route("getowners")]
        public async Task<JsonResult> GetOwners()
        {
            List<EntBusinessOwner> entBusinessOwners = new List<EntBusinessOwner>();
            entBusinessOwners = await DalBusinessOwner.GetBusinessOwners();
            return new JsonResult(entBusinessOwners);
        }

        
        [HttpGet]
        [Route("GetOwnerbyid/{boid}")]
        public async Task<JsonResult> GetOwnersShop(int boid)
        {
            
             List<EntShop> entBusinesses=new List<EntShop>();
            entBusinesses = await DalShop.GetOwnerShop(boid);
            return new JsonResult(entBusinesses);

        }

        [HttpGet]
        [Route("GetBusinessOwner/{boid}")]

        public async Task<JsonResult> GetBusinessOwnerById(int boid)
        {
            List<EntBusinessOwner> entBusinessOwners = new List<EntBusinessOwner>();
            entBusinessOwners = await DalBusinessOwner.GetBusinessOwnerById(boid);
            return new JsonResult(entBusinessOwners);
        }
    }
}
