using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : BaseController
    {

        [HttpPost]
        [Route("ConfirmSale")]
        public IActionResult Post()
        {
            try
            {
                return Ok("Success");

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }


        }
    }
}