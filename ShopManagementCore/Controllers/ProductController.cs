using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BLL.Request;
using BLL.Request.Category;
using BLL.Request.Product;
using BLL.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Utility.Helper;

namespace ShopManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IOptions<GlobalApplicationSetting> _appsetting;
        public ProductController(IProductService productService, IOptions<GlobalApplicationSetting> appsetting)
        {
            _productService = productService;
            _appsetting = appsetting;
        }

        [HttpGet]
        [Route("{GetAll}")]
        [EnableCors("AllowOrigin")]
        public IActionResult GetAll(int currentPage,int pageSize)
        {
            try
            {
                Thread.Sleep(5000);
                var oProductVMList = _productService.GetAllProductVM(currentPage, pageSize);
                //var msg = _appsetting.Value.ShopName;

                if (oProductVMList != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oProductVMList;
                    response.DataCount = _productService.GetTotalCount();
                    return Ok(response);
                }

                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;

                return NotFound(errorResponse);
            }
            catch (Exception ex)
            {
                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_SERVER_ERROR;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SERVER_ERROR;
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }


        }


        [HttpGet]
        [Route("GetSingleById/{productid}")]
        public IActionResult GetSingle(long productid)
        {
            try
            {
                var oProductVM = _productService.GetSingleProductVmById(productid);


                if (oProductVM != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oProductVM;

                    return Ok(response);
                }

                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;
                return NotFound(errorResponse);
            }
            catch (Exception ex)
            {
                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SERVER_ERROR;

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }


        }



        [HttpPost]
        [Route("InsertProduct")]
        public IActionResult Post([FromBody]ProductInsertRequest prodrequest)
        {
            try
            {
                if (prodrequest == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Error in Parameters");
                }

                if(String.IsNullOrEmpty(prodrequest.ProductCode) || prodrequest.CategoryId <=0 
                    || prodrequest.SubCategoryId<=0 || prodrequest.UnitId!<= 0 )
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Error in Parameters");
                }


                string msg = _productService.InsertProduct(prodrequest);

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

        [HttpPut]
        [Route("Updateproduct/{productid}")]
        public IActionResult Update(long productid, [FromBody] ProductUpdateRequest product)
        {
            try
            {

                if (string.IsNullOrEmpty(product.Name))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Product Name Required";
                    return BadRequest(errorResponse);
                }
                if (product.CategoryId<=0)
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Required";
                    return BadRequest(errorResponse);

                }

                string msg = _productService.UpdateProduct(productid, product);

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

        [HttpDelete]
        [Route("Deleteproduct/{productid}")]
        public IActionResult Delete(long productid)
        {
            try
            {
                string strMsg = _productService.DeleteProduct(productid);

                if (strMsg == GlobalConstant.OPERATION_SUCCESS)
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
                    errorResponse.ResponseMessage = strMsg;

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