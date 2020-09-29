using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BLL.Request;
using BLL.Request.Category;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagementCore.Response;

using Utility.Helper;

namespace ShopManagementCore.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("{list}")]
        public IActionResult GetAll()
        {
            try
            {
                var categoryList = _categoryService.GetAllCategory();


                if (categoryList != null)
                {
                    response.ResponseCode = GlobalConstant.RESPONSE_CODE_SUCCESS;
                    response.ResponseMessage = GlobalConstant.RESPONSE_MESSAGE_SUCCESS;
                    response.ResponseToken = null;
                    response.Data = categoryList;

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
        [Route("singlebyid/{categoryId}")]
        public IActionResult GetSingle(long categoryId)
        {
            try
            {
                var category = _categoryService.GetSingleCategory(categoryId);


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

        [HttpGet]
        [Route("singlebycode/{categoryCode}")]
        public IActionResult GetSingle(string categoryCode)
        {
            try
            {
                var category = _categoryService.GetSingleByCategoryCode(categoryCode);


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
        [Route("insert")]
        public IActionResult Post([FromBody]CategoryInsertRequest category)
        {
            try
            {
                if (string.IsNullOrEmpty(category.CategoryCode))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Code Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(category.CategoryName))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Name Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(category.Description))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Description Required";
                    return BadRequest(errorResponse);

                }

                string msg=_categoryService.InsertCategory(category);

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
        [Route("update/{categoryid}")]
        public IActionResult Update(long categoryid,[FromBody] CategoryUpdateRequest category)
        {
            try
            {
               
                if (string.IsNullOrEmpty(category.CategoryName))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Name Required";
                    return BadRequest(errorResponse);
                }
                if (string.IsNullOrEmpty(category.Description))
                {
                    errorResponse.ResponseCode = GlobalConstant.RESPONSE_CODE_BAD_REQUEST;
                    errorResponse.ResponseMessage = "Category Description Required";
                    return BadRequest(errorResponse);

                }

                string msg = _categoryService.UpdateCategory(categoryid,category);

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

        [HttpDelete]
        [Route("delete/{categoryid}")]
        public IActionResult Delete(long categoryid)
        {
            try
            {
                string msg = _categoryService.DeleteCategory(categoryid);

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