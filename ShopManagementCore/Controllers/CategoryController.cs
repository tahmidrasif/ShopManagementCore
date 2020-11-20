using System;
using BLL.Request;
using BLL.Request.Category;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Utility.Helper;

namespace ShopManagementCore.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IOptions<GlobalApplicationSetting> _appsetting;

        public CategoryController(ICategoryService categoryService, IOptions<GlobalApplicationSetting>  appsetting)
        {
            _categoryService = categoryService;
            _appsetting = appsetting;
        }


        [HttpGet]
        [Route("{GetAll}")]
        public IActionResult GetAll()
        {
            try
            {
                var oCategoryVMList = _categoryService.GetAllCategory();
                //var msg = _appsetting.Value.ShopName;

                if (oCategoryVMList != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oCategoryVMList;

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
        [Route("GetSingleById/{categoryId}")]
        public IActionResult GetSingle(long categoryId)
        {
            try
            {
                var oCategoryVM = _categoryService.GetSingleCategory(categoryId);


                if (oCategoryVM != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oCategoryVM;

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

        [HttpGet]
        [Route("GetSingleByCode/{categoryCode}")]
        public IActionResult GetSingle(string categoryCode)
        {
            try
            {
                var oCategoryVM = _categoryService.GetSingleByCategoryCode(categoryCode);


                if (oCategoryVM != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oCategoryVM;

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
        [Route("InsertCategory")]
        public IActionResult Post([FromBody]CategoryInsertRequest categoryRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(categoryRequest.CategoryCode))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Code Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(categoryRequest.CategoryName))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Name Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(categoryRequest.Description))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Description Required";
                    return BadRequest(errorResponse);

                }

                string msg=_categoryService.InsertCategory(categoryRequest);

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
        [Route("UpdateCategory/{categoryId}")]
        public IActionResult Update(long categoryId,[FromBody] CategoryUpdateRequest categoryRequest)
        {
            try
            {
               
                if (string.IsNullOrEmpty(categoryRequest.CategoryName))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Name Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(categoryRequest.Description))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Description Required";
                    return BadRequest(errorResponse);

                }

                string msg = _categoryService.UpdateCategory(categoryId, categoryRequest);

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
        [Route("DeleteCategory/{categoryId}")]
        public IActionResult Delete(long categoryId)
        {
            try
            {
                string strMsg = _categoryService.DeleteCategory(categoryId);

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