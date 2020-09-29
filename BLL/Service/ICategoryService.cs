using BLL.Request;
using BLL.Request.Category;
using BLL.ViewModel.Category;
using DLL.Models;
using DLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;


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
                List<CategoryViewModel> categoryVMList = new List<CategoryViewModel>();
                var categoryList = _unitOfWork.categoryRepository.GetAll(x => x.IsActive == true);
                if (categoryList != null)
                {
                    foreach (var item in categoryList)
                    {
                        CategoryViewModel categoryVM = new CategoryViewModel();
                        categoryVM.CategoryCode = item.CategoryCode;
                        categoryVM.CategoryName = item.CategoryName;
                        categoryVM.Description = item.Description;
                        //model.CreatedBy = item.CreatedBy;
                        //model.CreatedOn = item.CreatedOn;

                        categoryVMList.Add(categoryVM);
                    }

                    return categoryVMList;
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
                    var category = _unitOfWork.categoryRepository.GetSingle(x => x.CategoryCode == categoryCode);
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
                    var category = _unitOfWork.categoryRepository.GetSingle(x => x.CategoryId == categoryId);
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

        public string InsertCategory(CategoryInsertRequest category)
        {
            try
            {
                if (IsCategoryCodeExist(category.CategoryCode))
                {
                    return "Category Already Exist!!!";
                }
                if (IsCategoryNameExist(category.CategoryName))
                {
                    return "Category Already Exist!!!";
                }

                Category objCategory = new Category()
                {
                    CategoryCode = category.CategoryCode,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    CreatedBy = "Tahmid",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _unitOfWork.categoryRepository.Add(objCategory);
                _unitOfWork.Save();
                return "Success";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string UpdateCategory(long categoryid, CategoryUpdateRequest category)
        {
            try
            {
                if (categoryid > 0)
                {

                    var objcategory = _unitOfWork.categoryRepository.GetSingle(x => x.CategoryId == categoryid);
                    if (objcategory == null)
                        return "Invalid Category Id";

                    objcategory.CategoryName = category.CategoryName;
                    objcategory.Description = category.Description;
                    objcategory.UpdatedBy = "Tahmid";
                    objcategory.UpdatedOn = DateTime.Now;

                    _unitOfWork.categoryRepository.Update(objcategory);
                    _unitOfWork.Save();

                    return "Success";
                }
                return "Invalid Category Id";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string DeleteCategory(long categoryid)
        {
            try
            {
                if (categoryid > 0)
                {

                    var objcategory = _unitOfWork.categoryRepository.GetSingle(x => x.CategoryId == categoryid);
                    if (objcategory == null)
                        return "Invalid Category Id";

                    objcategory.IsActive = false;
                    objcategory.UpdatedBy = "Tahmid";
                    objcategory.UpdatedOn = DateTime.Now;

                    _unitOfWork.categoryRepository.Delete(objcategory);
                    _unitOfWork.Save();

                    return "Success";
                }
                return "Invalid Category Id";
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
                List<SubCategoryViewModel> subcatVMList = new List<SubCategoryViewModel>();
                var subcategoryList= _unitOfWork.categoryRepository.GetAllSubCategory(null);

                if(subcategoryList!=null && subcategoryList.Count > 0)
                {
                    foreach (var item in subcategoryList)
                    {
                        SubCategoryViewModel subcatVM = new SubCategoryViewModel()
                        {
                            SubCategoryCode = item.SubCategoryCode,
                            Name=item.Name,
                            Description= item.Description,
                            CategoryId= item.CategoryId!=null?0:(long)item.CategoryId,
                            CategoryName= _unitOfWork.categoryRepository.GetSingle(x=>x.CategoryId== item.CategoryId).CategoryName                     
                        };
                        subcatVMList.Add(subcatVM);
                    }

                    return subcatVMList;
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
            var category = _unitOfWork.categoryRepository.GetSingle(x => x.CategoryName == categoryName);
            if (category != null)
                return true;
            return false;
        }

        private bool IsCategoryCodeExist(string categoryCode)
        {
            var category = _unitOfWork.categoryRepository.GetSingle(x => x.CategoryCode == categoryCode);
            if (category != null)
                return true;
            return false;
        }
        #endregion
        
    }
}
