using BLL.Request.Product;
using BLL.ViewModel.Product;
using DLL.Models;
using DLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Helper;

namespace BLL.Service
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProduct();
        ProductViewModel GetSingleProductById(long id);
        string InsertProduct(ProductInsertRequest product);
        string UpdateProduct(long productid, ProductUpdateRequest product);
        string DeleteProduct(long productid);
        List<ProductViewModel> GetAllProductVM(int currentPage, int pageSize);
        ProductViewModel GetSingleProductVmById(long id);
        int GetTotalCount();
    }

    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitService _unitService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public ProductService(IUnitOfWork unitOfWork, IUnitService unitService, ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _unitOfWork = unitOfWork;
            _unitService = unitService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;

        }
        public List<ProductViewModel> GetAllProduct()
        {
            try
            {
                List<ProductViewModel> oProductVMList = new List<ProductViewModel>();
                var oProductList = _unitOfWork.ProductRepository.GetAll(x => x.IsActive == true);
                if (oProductList != null)
                {
                    foreach (var item in oProductList)
                    {
                        ProductViewModel oProductVM = new ProductViewModel();
                        oProductVM.ProductID = item.ProductId;
                        oProductVM.ProductCode = item.ProductCode;
                        oProductVM.ProductName = item.Name;
                        oProductVM.UnitID = (long)item.UnitId;
                        var unit = _unitService.GetUnitById((long)item.UnitId);
                        if (unit != null)
                        {
                            oProductVM.UnitName = unit.UnitName;
                        }
                        oProductVM.AvaliableQty = GetProductStock(item.ProductId);
                        oProductVM.CategoryID = (long)item.CategoryId;
                        var oCategoryVM = _categoryService.GetSingleCategory((long)item.CategoryId);
                        oProductVM.CategoryName = oCategoryVM == null ? "" : oCategoryVM.CategoryName;
                        oProductVM.SubCategoryID = (long)item.SubCategoryId;
                        var oSubCategoryVM = _subCategoryService.GetSingleSubCategory((long)item.SubCategoryId);
                        oProductVM.SubCategoryName = oSubCategoryVM == null ? "" : oSubCategoryVM.Name;
                        var oProductPrice = _unitOfWork.ProductRepository.GetProductPriceById(item.ProductId);
                        if (oProductPrice != null)
                        {
                            oProductVM.SaleUnitPrice = oProductPrice.UnitSalesPrice ??= 0;
                            oProductVM.SaleVat = oProductPrice.Spvat ??= 0;
                            oProductVM.SaleOtherCharge = oProductPrice.SpotherCharge ??= 0;
                            oProductVM.SaleTotalPrice = oProductPrice.Spdiscount ??= 0;
                            oProductVM.SaleTotalPrice = oProductPrice.TotalSalesPrice ??= 0;
                        }

                        oProductVMList.Add(oProductVM);
                    }

                    return oProductVMList;
                }

                else return null;
            }
            catch (Exception ex)
            {
                //Activity Log;
                throw ex;

            }
        }

        public List<ProductViewModel> GetAllProductVM(int currentPage, int pageSize)
        {
            try
            {
                List<ProductViewModel> oProductVMList = new List<ProductViewModel>();
                var oProductList = _unitOfWork.ProductRepository.GetAllProductVw(currentPage,pageSize);
                if (oProductList != null)
                {
                    foreach (var item in oProductList)
                    {
                        ProductViewModel oProductVM = new ProductViewModel();
                        oProductVM.ProductID = item.ProductId;
                        oProductVM.ProductCode = item.ProductCode;
                        oProductVM.ProductName = item.ProductName;
                        oProductVM.UnitID = (long)item.UnitId;

                        oProductVM.UnitName = item.UnitName;

                        oProductVM.AvaliableQty = (decimal)item.AvaliableQty;
                        oProductVM.CategoryID = (long)item.CategoryId;

                        oProductVM.CategoryName = item.CategoryName;
                        oProductVM.SubCategoryID = (long)item.SubCategoryId;

                        oProductVM.SubCategoryName = item.SubCategoryName;

                        oProductVM.SaleUnitPrice = item.SaleUnitPrice ??= 0;
                        oProductVM.SaleVat = item.SaleVat ??= 0;
                        oProductVM.SaleOtherCharge = item.SaleOtherCharge ??= 0;
                        oProductVM.SaleTotalPrice = item.SaleDiscount ??= 0;
                        oProductVM.SaleTotalPrice = item.SaleTotalPrice ??= 0;


                        oProductVMList.Add(oProductVM);
                    }

                    return oProductVMList;
                }

                else return null;
            }
            catch (Exception ex)
            {
                //Activity Log;
                throw ex;

            }
        }

        private decimal GetProductStock(long productId)
        {
            try
            {
                if (productId > 0)
                {
                    var stock = _unitOfWork.ProductRepository.GetProductStock(productId);
                    if (stock != null)
                    {
                        return stock.Quantity ??= 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
                //throw ex;
            }

        }

        public ProductViewModel GetSingleProductById(long id)
        {
            try
            {
                List<ProductViewModel> oProductVMList = new List<ProductViewModel>();
                var oProduct = _unitOfWork.ProductRepository.GetSingle(x => x.IsActive == true && x.ProductId == id);
                if (oProduct != null)
                {

                    ProductViewModel oProductVM = new ProductViewModel();
                    oProductVM.ProductID = oProduct.ProductId;
                    oProductVM.ProductCode = oProduct.ProductCode;
                    oProductVM.ProductName = oProduct.Name;
                    oProductVM.UnitID = (long)oProduct.UnitId;
                    var unit = _unitService.GetUnitById((long)oProduct.UnitId);
                    if (unit != null)
                    {
                        oProductVM.UnitName = unit.UnitName;
                    }
                    oProductVM.AvaliableQty = GetProductStock(oProduct.ProductId);
                    oProductVM.CategoryID = (long)oProduct.CategoryId;
                    var oCategoryVM = _categoryService.GetSingleCategory((long)oProduct.CategoryId);
                    oProductVM.CategoryName = oCategoryVM == null ? "" : oCategoryVM.CategoryName;
                    oProductVM.SubCategoryID = (long)oProduct.SubCategoryId;
                    var oSubCategoryVM = _subCategoryService.GetSingleSubCategory((long)oProduct.SubCategoryId);
                    oProductVM.SubCategoryName = oSubCategoryVM == null ? "" : oSubCategoryVM.Name;
                    var oProductPrice = _unitOfWork.ProductRepository.GetProductPriceById(oProduct.ProductId);
                    if (oProductPrice != null)
                    {
                        oProductVM.SaleUnitPrice = oProductPrice.UnitSalesPrice ??= 0;
                        oProductVM.SaleVat = oProductPrice.Spvat ??= 0;
                        oProductVM.SaleOtherCharge = oProductPrice.SpotherCharge ??= 0;
                        oProductVM.SaleTotalPrice = oProductPrice.Spdiscount ??= 0;
                        oProductVM.SaleTotalPrice = oProductPrice.TotalSalesPrice ??= 0;
                    }




                    return oProductVM;
                }

                else return null;
            }
            catch (Exception ex)
            {
                //Activity Log;
                throw ex;

            }
        }

        public ProductViewModel GetSingleProductVmById(long id)
        {
            try
            {
                //List<ProductViewModel> oProductVMList = new List<ProductViewModel>();
                var oProduct = _unitOfWork.ProductRepository.GetProductVwById(id);
                if (oProduct != null)
                {

                    ProductViewModel oProductVM = new ProductViewModel();
                    oProductVM.ProductID = oProduct.ProductId;
                    oProductVM.ProductCode = oProduct.ProductCode;
                    oProductVM.ProductName = oProduct.ProductName;
                    oProductVM.UnitID = (long)oProduct.UnitId;


                    oProductVM.UnitName = oProduct.UnitName;

                    oProductVM.AvaliableQty = (decimal)oProduct.AvaliableQty;
                    oProductVM.CategoryID = (long)oProduct.CategoryId;

                    oProductVM.CategoryName = oProduct.CategoryName;
                    oProductVM.SubCategoryID = (long)oProduct.SubCategoryId;

                    oProductVM.SubCategoryName = oProduct.SubCategoryName;

                    oProductVM.SaleUnitPrice = oProduct.SaleUnitPrice ??= 0;
                    oProductVM.SaleVat = oProduct.SaleVat ??= 0;
                    oProductVM.SaleOtherCharge = oProduct.SaleOtherCharge ??= 0;
                    oProductVM.SaleTotalPrice = oProduct.SaleDiscount ??= 0;
                    oProductVM.SaleTotalPrice = oProduct.SaleTotalPrice ??= 0;

                    return oProductVM;
                }

                else return null;
            }
            catch (Exception ex)
            {
                //Activity Log;
                throw ex;

            }
        }

        public string InsertProduct(ProductInsertRequest product)
        {
            try
            {
                if (product != null)
                {
                    if (IsProductAlreadyAvailable(product.Name, product.ProductCode))
                    {
                        return "Product is already available";
                    }

                    var category = _categoryService.GetSingleCategory((long)product.CategoryId);
                    if (category == null)
                    {
                        return "Category is not available";
                    }

                    var subcategory = _subCategoryService.GetSingleSubCategory((long)product.SubCategoryId);
                    if (subcategory == null)
                    {
                        return "Sub category is not available";
                    }

                    var unit = _unitService.GetUnitById((long)product.UnitId);
                    if (unit == null)
                    {
                        return "Unit is not available";
                    }

                    Product oProduct = new Product()
                    {
                        Name = product.Name,
                        ProductCode = product.ProductCode,
                        IsActive = true,
                        CategoryId = product.CategoryId,
                        SubCategoryId = product.SubCategoryId,
                        UnitId = product.UnitId,
                        CreatedBy = GlobalConstant.ADMIN_NAME,
                        CreatedOn = DateTime.Now
                    };

                    _unitOfWork.ProductRepository.Add(oProduct);
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

        public string UpdateProduct(long productid, ProductUpdateRequest product)
        {
            try
            {

                if (product != null)
                {
                    if (productid > 0)
                    {


                        var category = _categoryService.GetSingleCategory((long)product.CategoryId);
                        if (category == null)
                        {
                            return "Category is not available";
                        }

                        var subcategory = _subCategoryService.GetSingleSubCategory((long)product.SubCategoryId);
                        if (subcategory == null)
                        {
                            return "Sub category is not available";
                        }

                        var unit = _unitService.GetUnitById((long)product.UnitId);
                        if (unit == null)
                        {
                            return "Unit is not available";
                        }

                        Product oProduct = _unitOfWork.ProductRepository.GetSingle(x => x.IsActive == true && x.ProductId == productid);

                        if (oProduct != null)
                        {
                            oProduct.Name = product.Name;
                            oProduct.ProductCode = product.ProductCode;
                            oProduct.CategoryId = product.CategoryId;
                            oProduct.SubCategoryId = product.SubCategoryId;
                            oProduct.UnitId = product.UnitId;
                            oProduct.UpdatedBy = GlobalConstant.ADMIN_NAME;
                            oProduct.UpdatedOn = DateTime.Now;

                            _unitOfWork.ProductRepository.Update(oProduct);

                            _unitOfWork.Save();

                            return GlobalConstant.OPERATION_SUCCESS;
                        };



                    }
                }
                return GlobalConstant.OPERATION_ERROR;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string DeleteProduct(long productid)
        {
            try
            {
                if (productid > 0)
                {

                    var oProduct = _unitOfWork.ProductRepository.GetSingle(x => x.ProductId == productid && x.IsActive == true);
                    if (oProduct == null)
                        return GlobalConstant.OPERATION_DATA_NOT_FOUND;

                    oProduct.IsActive = false;
                    oProduct.UpdatedBy = GlobalConstant.ADMIN_NAME;
                    oProduct.UpdatedOn = DateTime.Now;

                    _unitOfWork.ProductRepository.Delete(oProduct);
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

        private bool IsProductAlreadyAvailable(string name, string productCode)
        {
            var productByName = _unitOfWork.ProductRepository.GetSingle(x => x.Name == name && x.IsActive == true);
            if (productByName != null)
            {
                return true;
            }
            var productByCode = _unitOfWork.ProductRepository.GetSingle(x => x.ProductCode == productCode && x.IsActive == true);
            if (productByCode != null)
            {
                return true;
            }
            return false;
        }

        public int GetTotalCount()
        {
           return _unitOfWork.ProductRepository.GetCount();
        }
    }
}