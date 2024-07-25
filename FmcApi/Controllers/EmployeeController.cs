using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        [Route("saveemployee")]
        public async Task SaveEmployee(EntEmployee ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@empid",ebo.empid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@joiningdate",ebo.joiningdate),
                new SqlParameter("@enddate",ebo.enddate),
                new SqlParameter("@dob",ebo.dob),
                new SqlParameter("@emptype",ebo.emptype),
                new SqlParameter("@padress",ebo.padress),
                new SqlParameter("@tadress",ebo.tadress),
                new SqlParameter("@username",ebo.username),
                new SqlParameter("@password",ebo.password),
                new SqlParameter("@role",ebo.role),
                new SqlParameter("@isactive",ebo.isactive),
                new SqlParameter("@image",ebo.image)

                };
                await MyCrud.CRUD("sp_InsertEmployee", sp);
            }
        }

        [HttpDelete]
        [Route("deleteemployee/{empid}")]
        public async Task DeleteEmployee(int empid)
        {
            if (empid != 0)
            {
                SqlParameter[] sp = {
                        new SqlParameter("@empid",empid)
                        };
                await MyCrud.CRUD("sp_DeleteEmployee", sp);
            }
        }

        [HttpPut]
        [Route("updateemployee")]
        public async Task UpdateEmployee(EntEmployee ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@empid",ebo.empid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@joiningdate",ebo.joiningdate),
                new SqlParameter("@enddate",ebo.enddate),
                new SqlParameter("@emptype",ebo.emptype),
                new SqlParameter("@padress",ebo.padress),
                new SqlParameter("@tadress",ebo.tadress),
                new SqlParameter("@dob",ebo.dob),
                new SqlParameter("@username",ebo.username),
                new SqlParameter("@password",ebo.password),
                new SqlParameter("@role",ebo.role),
                new SqlParameter("@image",ebo.image),

                new SqlParameter("@isactive",ebo.isactive)

                };
                await MyCrud.CRUD("sp_UpdateEmployee", sp);
            }
        }

        [HttpGet]

        public async Task<JsonResult> GetEmployee()
        {
            List<EntEmployee> entEmployee = new List<EntEmployee>();
            entEmployee = await DalEmployee.GetEmployee();
            return new JsonResult(entEmployee);
        }

        [HttpGet]
        [Route("Getempoyeebyshopid/{shopid}")]
        public async Task<JsonResult> GetShopEmployee(int shopid)
        {
            List<EntEmployee> entEmployee = new List<EntEmployee>();
            entEmployee = await DalEmployee.GetEmployeeShop(shopid);
            return new JsonResult(entEmployee);
        }


        [HttpGet]
        [Route("Getshopbyemployeeid/{empid}")]
        public async Task<JsonResult> Get_Shop_by_EmployeeId(int empid)
        {   
            EntShop entEmployee = await DalEmployee.GetShopByEmpId(empid);
            if (entEmployee != null)
            {
                return new JsonResult(entEmployee);
            }
            else
            {
                // You can customize the response when no shop is found, such as returning a 404 status code.
                return new JsonResult("Shop not found for the given employee ID") { StatusCode = 404 };
            }

        }

        [HttpGet]
        [Route("GetMonthlySales/{shopId}/{year}")]
        public async Task<JsonResult> GetMonthlySales(int shopId, int year)
        {
            List<EntMonthlySalesData> monthlySales = await DalMonthlySalesData.GetMonthlySalesData(shopId, year);
            if (monthlySales != null)
            {
                return new JsonResult(monthlySales);
            }
            else
            {
                // You can customize the response when no shop is found, such as returning a 404 status code.
                return new JsonResult("No sales data found for the given shop ID and year") { StatusCode = 404 };
            }

        }

    }
 }