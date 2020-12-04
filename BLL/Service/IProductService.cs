using BLL.Request.Product;
using BLL.ViewModel.Product;
using DLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service
{
    public interface IProductService
    {
         List<ProductViewModel> GetAllProduct();
         ProductViewModel GetSingleProductById(long id);
        string InsertProduct(ProductInsertRequest product);
        string UpdateProduct(long productid,ProductUpdateRequest product);
        string DeleteProduct(long productid);
    }

    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitService _unitService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public ProductService(IUnitOfWork unitOfWork,IUnitService unitService,ICategoryService categoryService,ISubCategoryService subCategoryService)
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
                        oProductVM.ProductName=item.Name;
                        oProductVM.UnitID = (long)item.UnitId;
                        var unit = _unitService.GetUnitById((long)item.UnitId);
                        if (unit != null)
                        {
                            oProductVM.UnitName = unit.UnitName;
                        }
                        oProductVM.AvaliableQty = GetProductStock(item.ProductId);
                        oProductVM.CategoryID = (long)item.CategoryId;
                        var oCategoryVM = _categoryService.GetSingleCategory((long)item.CategoryId);
                        oProductVM.CategoryName = oCategoryVM == null ? "": oCategoryVM.CategoryName;
                        oProductVM.SubCategoryID = (long)item.SubCategoryId;
                        var oSubCategoryVM=_subCategoryService.GetSingleSubCategory((long)item.SubCategoryId);
                        oProductVM.SubCategoryName = oSubCategoryVM == null ? "" : oSubCategoryVM.Name;
                        var oProductPrice = _unitOfWork.ProductRepository.GetProductPriceById(item.ProductId);
                        if (oProductPrice != null)
                        {
                            oProductVM.SaleUnitPrice = oProductPrice.UnitSalesPrice??=0;
                            oProductVM.SaleVat = oProductPrice.Spvat??=0;
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
                var oProduct = _unitOfWork.ProductRepository.GetSingle(x => x.IsActive == true && x.ProductId==id);
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

        public string InsertProduct(ProductInsertRequest product)
        {
            throw new NotImplementedException();
        }

        public string UpdateProduct(long productid, ProductUpdateRequest product)
        {
            throw new NotImplementedException();
        }

        public string DeleteProduct(long productid)
        {
            throw new NotImplementedException();
        }
    }
}
