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
    public interface ISubCategoryService
    {

        List<SubCategoryViewModel> GetAllSubCategory();
        SubCategoryViewModel GetSingleSubCategory(long subcategoryId);
        SubCategoryViewModel GetSingleSubCategoryByCode(string categoryCode);
        string InsertSubCategory(SubCategoryInsertRequest subcategoryRequest);
        string UpdateSubCategory(long subcategoryId, SubCategoryUpdateRequest subcategoryRequest);
        string DeleteSubCategory(long subcategoryId);
        List<SubCategoryViewModel> GetAllSubCategoryByCategoryId(long categoryId);

    }

    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<SubCategoryViewModel> GetAllSubCategory()
        {
            try
            {
                List<SubCategoryViewModel> oSubcatVMList = new List<SubCategoryViewModel>();
                var oSubcategoryList = _unitOfWork.CategoryRepository.GetAllSubCategory(null);

                if (oSubcategoryList != null && oSubcategoryList.Count > 0)
                {
                    foreach (var item in oSubcategoryList)
                    {
                        SubCategoryViewModel subcatVM = new SubCategoryViewModel()
                        {
                            SubCategoryCode = item.SubCategoryCode,
                            Name = item.Name,
                            Description = item.Description,
                            CategoryId = item.CategoryId == null ? 0 : (long)item.CategoryId,
                            CategoryName = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryId == item.CategoryId).CategoryName
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
        public List<SubCategoryViewModel> GetAllSubCategoryByCategoryId(long categoryId)
        {
            try
            {
                List<SubCategoryViewModel> oSubcatVMList = new List<SubCategoryViewModel>();
                var oSubcategoryList = _unitOfWork.CategoryRepository.GetAllSubCategory(x=>x.CategoryId==categoryId);

                if (oSubcategoryList != null && oSubcategoryList.Count > 0)
                {
                    foreach (var item in oSubcategoryList)
                    {
                        SubCategoryViewModel subcatVM = new SubCategoryViewModel()
                        {
                            SubCategoryCode = item.SubCategoryCode,
                            Name = item.Name,
                            Description = item.Description,
                            CategoryId = item.CategoryId == null ? 0 : (long)item.CategoryId,
                            CategoryName = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryId == item.CategoryId).CategoryName
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

        public SubCategoryViewModel GetSingleSubCategoryByCode(string subcategoryCode)
        {
            try
            {

                var oSubCagtegory = _unitOfWork.SubCategoryRepository.GetSingle(x => x.SubCategoryCode == subcategoryCode);

                if (oSubCagtegory != null)
                {
                    SubCategoryViewModel oSubCategoryVM = new SubCategoryViewModel()
                    {
                        SubCategoryCode = oSubCagtegory.SubCategoryCode,
                        Name = oSubCagtegory.Name,
                        Description = oSubCagtegory.Description,
                        CategoryId = oSubCagtegory.CategoryId == null ? 0 : (long)oSubCagtegory.CategoryId,
                        CategoryName = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryId == oSubCagtegory.CategoryId).CategoryName
                    };
                    //oSubcatVMList.Add(subcatVM);


                    return oSubCategoryVM;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SubCategoryViewModel GetSingleSubCategory(long subcategoryId)
        {
            try
            {
 
                var oSubCagtegory = _unitOfWork.SubCategoryRepository.GetSingle(x=>x.SubCategoryId==subcategoryId);

                if (oSubCagtegory != null)
                {
                        SubCategoryViewModel oSubCategoryVM = new SubCategoryViewModel()
                        {
                            SubCategoryCode = oSubCagtegory.SubCategoryCode,
                            Name = oSubCagtegory.Name,
                            Description = oSubCagtegory.Description,
                            CategoryId = oSubCagtegory.CategoryId == null ? 0 : (long)oSubCagtegory.CategoryId,
                            CategoryName = _unitOfWork.CategoryRepository.GetSingle(x => x.CategoryId == oSubCagtegory.CategoryId).CategoryName
                        };
                        //oSubcatVMList.Add(subcatVM);
                   

                    return oSubCategoryVM;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string InsertSubCategory(SubCategoryInsertRequest subcategoryRequest)
        {

            try
            {
                if (IsSubCategoryCodeExist(subcategoryRequest.SubCategoryCode))
                {
                    return "Sub Category Already Exist!!!";
                }
                if (IsSubCategoryNameExist(subcategoryRequest.SubCategoryName))
                {
                    return "Sub Category Already Exist!!!";
                }

                SubCategory oCategory = new SubCategory()
                {
                    SubCategoryCode = subcategoryRequest.SubCategoryCode,
                    Name = subcategoryRequest.SubCategoryName,
                    Description = subcategoryRequest.Description,
                    CategoryId= subcategoryRequest.CategoryID,
                    CreatedBy = "Tahmid",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _unitOfWork.SubCategoryRepository.Add(oCategory);
                _unitOfWork.Save();
                return GlobalConstant.OPERATION_SUCCESS;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool IsSubCategoryNameExist(string subCategoryName)
        {
            var oSubcategory = _unitOfWork.SubCategoryRepository.GetSingle(x => x.Name == subCategoryName);
            if (oSubcategory == null)
            {
                return false;
            }
            return true;
        }

        private bool IsSubCategoryCodeExist(string subCategoryCode)
        {
            var oSubcategory = _unitOfWork.SubCategoryRepository.GetSingle(x => x.SubCategoryCode == subCategoryCode);
            if (oSubcategory == null)
            {
                return false;
            }
            return true;
        }

        public string UpdateSubCategory(long subcategoryId, SubCategoryUpdateRequest subcategoryRequest)
        {
            try
            {
                if (subcategoryId > 0)
                {

                    var oSubcategory = _unitOfWork.SubCategoryRepository.GetSingle(x => x.SubCategoryId == subcategoryId);
                    if (oSubcategory == null)
                        return "Invalid Category Id";

                    oSubcategory.Name = subcategoryRequest.SubCategoryName;
                    oSubcategory.Description = subcategoryRequest.Description;
                    oSubcategory.SubCategoryCode = subcategoryRequest.SubCategoryCode;
                    oSubcategory.CategoryId = subcategoryRequest.CategoryID;
                    oSubcategory.UpdatedBy = "Tahmid";
                    oSubcategory.UpdatedOn = DateTime.Now;

                    _unitOfWork.SubCategoryRepository.Update(oSubcategory);
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

        public string DeleteSubCategory(long subcategoryId)
        {
            try
            {
                if (subcategoryId > 0)
                {

                    var oSubcategory = _unitOfWork.SubCategoryRepository.GetSingle(x => x.SubCategoryId == subcategoryId);
                    if (oSubcategory == null)
                        return GlobalConstant.OPERATION_DATA_NOT_FOUND;

                    oSubcategory.IsActive = false;
                    oSubcategory.UpdatedBy = "Tahmid";
                    oSubcategory.UpdatedOn = DateTime.Now;

                    _unitOfWork.SubCategoryRepository.Delete(oSubcategory);
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

        
    }
}
