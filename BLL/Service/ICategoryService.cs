using BLL.Request;
using BLL.Request.Category;
using BLL.ViewModel.Category;
using DLL.Models;
using DLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Helper;

namespace BLL.Service
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetAllCategory();
        CategoryViewModel GetSingleCategory(long categoryId);
        CategoryViewModel GetSingleByCategoryCode(string categoryCode);
        string InsertCategory(CategoryInsertRequest category);
        string UpdateCategory(long categoryid, CategoryUpdateRequest category);
        string DeleteCategory(long categoryid);

        List<SubCategoryViewModel> GetAllSubCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Implemented Method

        public List<CategoryViewModel> GetAllCategory()
        {
            try
            {
                List<CategoryViewModel> oCategoryVMList = new List<CategoryViewModel>();
                var oCategoryList = _unitOfWork.CategoryRepository.GetAll(x => x.IsActive == true);
                if (oCategoryList != null)
                {
                    foreach (var item in oCategoryList)
                    {
                        CategoryViewModel oCategoryVM = new CategoryViewModel();
                        oCategoryVM.CategoryID = item.CategoryId;
                        oCategoryVM.CategoryCode = item.CategoryCode;
                        oCategoryVM.CategoryName = item.CategoryName;
                        oCategoryVM.Description = item.Description;
                        //model.CreatedBy = item.CreatedBy;
                        //model.CreatedOn = item.CreatedOn;

                        oCategoryVMList.Add(oCategoryVM);
                    }

                    return oCategoryVMList;
                }

                else return null;
            }
            catch (Exception ex)
            {
                //Activity Log;
                throw ex;
            }

        }

        public CategoryViewModel GetSingleByCategoryCode(string categoryCode)
        {
            try
            {
                if (categoryCode != null)
                {
                    var category = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryCode == categoryCode);
                    if (category != null)
                    {
                        CategoryViewModel categoryVM = new CategoryViewModel()
                        {
                            CategoryID = category.CategoryId,
                            CategoryCode = category.CategoryCode,
                            CategoryName = category.CategoryName,
                            Description = category.Description
                        };
                        return categoryVM;
                    }

                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CategoryViewModel GetSingleCategory(long categoryId)
        {
            try
            {
                if (categoryId > 0)
                {
                    var category = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryId == categoryId);
                    if (category != null)
                    {
                        CategoryViewModel categoryVM = new CategoryViewModel()
                        {
                            CategoryID = category.CategoryId,
                            CategoryCode = category.CategoryCode,
                            CategoryName = category.CategoryName,
                            Description = category.Description
                        };
                        return categoryVM;
                    }

                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string InsertCategory(CategoryInsertRequest categoryRequest)
        {
            try
            {
                if (IsCategoryCodeExist(categoryRequest.CategoryCode))
                {
                    return "Category Already Exist!!!";
                }
                if (IsCategoryNameExist(categoryRequest.CategoryName))
                {
                    return "Category Already Exist!!!";
                }

                Category oCategory = new Category()
                {
                    CategoryCode = categoryRequest.CategoryCode,
                    CategoryName = categoryRequest.CategoryName,
                    Description = categoryRequest.Description,
                    CreatedBy = "Tahmid",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _unitOfWork.CategoryRepository.Add(oCategory);
                _unitOfWork.Save();
                return GlobalConstant.OPERATION_SUCCESS;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string UpdateCategory(long categoryid, CategoryUpdateRequest categoryRequest)
        {
            try
            {
                if (categoryid > 0)
                {

                    var oCategory = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryId == categoryid);
                    if (oCategory == null)
                        return "Invalid Category Id";

                    oCategory.CategoryName = categoryRequest.CategoryName;
                    oCategory.Description = categoryRequest.Description;
                    oCategory.UpdatedBy = "Tahmid";
                    oCategory.UpdatedOn = DateTime.Now;

                    _unitOfWork.CategoryRepository.Update(oCategory);
                    _unitOfWork.Save();

                    return GlobalConstant.OPERATION_SUCCESS;
                }
                return GlobalConstant.OPERATION_ERROR;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string DeleteCategory(long categoryId)
        {
            try
            {
                if (categoryId > 0)
                {

                    var oCategory = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryId == categoryId);
                    if (oCategory == null)
                        return GlobalConstant.OPERATION_DATA_NOT_FOUND;

                    oCategory.IsActive = false;
                    oCategory.UpdatedBy = "Tahmid";
                    oCategory.UpdatedOn = DateTime.Now;

                    _unitOfWork.CategoryRepository.Delete(oCategory);
                    _unitOfWork.Save();

                    return GlobalConstant.OPERATION_SUCCESS;
                }
                return GlobalConstant.OPERATION_ERROR;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SubCategoryViewModel> GetAllSubCategory()
        {
            try
            {
                List<SubCategoryViewModel> oSubcatVMList = new List<SubCategoryViewModel>();
                var oSubcategoryList= _unitOfWork.CategoryRepository.GetAllSubCategory(null);

                if(oSubcategoryList != null && oSubcategoryList.Count > 0)
                {
                    foreach (var item in oSubcategoryList)
                    {
                        SubCategoryViewModel subcatVM = new SubCategoryViewModel()
                        {
                            SubCategoryCode = item.SubCategoryCode,
                            Name=item.Name,
                            Description= item.Description,
                            CategoryId= item.CategoryId!=null?0:(long)item.CategoryId,
                            CategoryName= _unitOfWork.CategoryRepository.GetSingle(x=>x.CategoryId== item.CategoryId).CategoryName                     
                        };
                        oSubcatVMList.Add(subcatVM);
                    }

                    return oSubcatVMList;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


        #region User Defined Method
        private bool IsCategoryNameExist(string categoryName)
        {
            var oCategory = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryName == categoryName);
            if (oCategory != null)
                return true;
            return false;
        }

        private bool IsCategoryCodeExist(string categoryCode)
        {
            var oCategory = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryCode == categoryCode);
            if (oCategory != null)
                return true;
            return false;
        }
        #endregion
        
    }
}
