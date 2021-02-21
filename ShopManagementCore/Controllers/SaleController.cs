using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Request.Sale;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.Helper;

namespace ShopManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : BaseController
    {
        private readonly ISaleService _salesService;

        public SaleController(ISaleService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        [Route("ConfirmPayment")]
        public IActionResult ConfirmPayment()
        {
            try
            {

                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_SERVER_ERROR;
                errorResponse.ResponseMessage = "Test";
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);


            }
            catch (Exception ex)
            {
                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }

        }

        [HttpPost]
        [Route("ConfirmPayment")]
        public IActionResult ConfirmPayment([FromBody]PaymentRequest paymentRequest)
        {
            try
            {
                if (paymentRequest == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Error in Parameters");
                }

                string msg = _salesService.CompleateTransaction(paymentRequest);

                if (msg == GlobalConstant.OPERATION_SUCCESS)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = null;
                    return Ok(response);
                }
                else
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_SERVER_ERROR;
                    errorResponse.ResponseMessage = msg;
                    return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
                }

            }
            catch (Exception ex)
            {
                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }

        }

        
    }
}