using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Request;
using BLL.Request.Category;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.Helper;

namespace ShopManagementCore.Controllers
{
   
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoryService _subcategoryService;
        private readonly ICategoryService _categoryService;
        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }


        [HttpGet]
        [Route("{GetAll}")]
        public IActionResult GetAll()
        {
            try
            {
                var oSubcategoryVMList = _subcategoryService.GetAllSubCategory();


                if (oSubcategoryVMList != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oSubcategoryVMList;

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
        [Route("GetAllSubCategoryByCategoryId/{categoryId}")]
        public IActionResult GetAll(long categoryId)
        {
            try
            {
                var oSubcategoryVMList = _subcategoryService.GetAllSubCategoryByCategoryId(categoryId);


                if (oSubcategoryVMList != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oSubcategoryVMList;

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
        [Route("GetSingleById/{subcategoryId}")]
        public IActionResult GetSingle(long subcategoryId)
        {
            try
            {
                var oSubcategoryVMList = _subcategoryService.GetSingleSubCategory(subcategoryId);


                if (oSubcategoryVMList != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = oSubcategoryVMList;

                    return Ok(response);
                }

                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;
                return NotFound(errorResponse);
            }
            catch (Exception ex)
            {
                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }


        }

        [HttpGet]
        [Route("GetSingleByCode/{subcategoryCode}")]
        public IActionResult GetSingle(string subcategoryCode)
        {
            try
            {
                var category = _subcategoryService.GetSingleSubCategoryByCode(subcategoryCode);


                if (category != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = category;

                    return Ok(response);
                }

                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;

                return NotFound(errorResponse);
            }
            catch (Exception ex)
            {
                errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_NOTFOUND;
                errorResponse.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_NOTFOUND;

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);

            }


        }

        [HttpPost]
        [Route("InsertSubCategory")]
        public IActionResult Post([FromBody]SubCategoryInsertRequest subcategoryRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(subcategoryRequest.SubCategoryCode))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Code Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(subcategoryRequest.SubCategoryName))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Name Required";
                    return BadRequest(errorResponse);
                }
              

                string msg = _subcategoryService.InsertSubCategory(subcategoryRequest);

                if (msg == "Success")
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
        [Route("UpdateSubcategory/{subcategoryid}")]
        public IActionResult Update(long subcategoryid, [FromBody] SubCategoryUpdateRequest subcategoryRequest)
        {
            try
            {

                if (string.IsNullOrEmpty(subcategoryRequest.SubCategoryName))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Name Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(subcategoryRequest.Description))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Description Required";
                    return BadRequest(errorResponse);

                }

                string msg = _subcategoryService.UpdateSubCategory(subcategoryid, subcategoryRequest);

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
        [Route("DeleteSubCategory/{categoryid}")]
        public IActionResult Delete(long categoryid)
        {
            try
            {
                string msg = _subcategoryService.DeleteSubCategory(categoryid);

                if (msg == "Success")
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
