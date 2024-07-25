using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;
using System.Data.SqlClient;


namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("getuserinfo/{shopid}")]
        public async Task<JsonResult> GetUserInfo(int shopid)
        {
            List<EntUser> entuser = new List<EntUser>();
            entuser = await DalUserInfo.GetUserInfo(shopid);
            return new JsonResult(entuser);
        }

        [HttpGet]
        [Route("getemployeeworkbyday/{employee}/{date}")]
        public async Task<JsonResult> getemployeeworkbyday(string employee,string date)
        {
            List<EntUser> entuser = new List<EntUser>();
            entuser = await DalUserInfo.Getemployeeworkbyday(employee,date);
            return new JsonResult(entuser);
        }



        [HttpGet]
        [Route("getuserinfobyemployee/{employee}")]
        public async Task<JsonResult> GetUserInfobyemployee(string employee)
        {
            List<EntUser> entuser = new List<EntUser>();
            entuser = await DalUserInfo.GetUserInfobyemployee(employee);
            return new JsonResult(entuser);
        }


        [HttpPost]
        [Route("saveuserinfo")]
        public async Task SaveServices(EntUser ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@name",ebo.name),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@employee",ebo.employee),
                new SqlParameter("@total",ebo.amount),
                new SqlParameter("@number",ebo.number),
                new SqlParameter("@dtime",ebo.datetime)
                
                };
                await MyCrud.CRUD("InsertUserInfo", sp);
            }
        }



    }
}
