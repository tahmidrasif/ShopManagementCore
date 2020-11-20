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


//BadRequest()               Creates a BadRequestResult object with status code 400.
//Conflict()                 Creates a ConflictResult object with status code 409.
//Content()                  Creates a NegotiatedContentResult with the specified status code and data.
//Created()                  Creates a CreatedNegotiatedContentResult with status code 201 Created.
//CreatedAtRoute()           Creates a CreatedAtRouteNegotiatedContentResult with status code 201 created.
//InternalServerError()      Creates an InternalServerErrorResult with status code 500 Internal server error.
//NotFound()                 Creates a NotFoundResult with status code404.
//Ok()                       Creates an OkResult with status code 200.
//Redirect()                 Creates a RedirectResult with status code 302.
//RedirectToRoute()          Creates a RedirectToRouteResult with status code 302.
//ResponseMessage()          Creates a ResponseMessageResult with the specified HttpResponseMessage.
//StatusCode()               Creates a StatusCodeResult with the specified http status code.
//Unauthorized()             Creates an UnauthorizedResult with status code 401.