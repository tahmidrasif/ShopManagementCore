using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagementCore.Response;

namespace ShopManagementCore.Controllers
{
    [ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        public SuccessResponse response;
        public ErrorResponse errorResponse;
        public BaseController()
        {
            response = new SuccessResponse();
            errorResponse = new ErrorResponse();
        }
    }

}