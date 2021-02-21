using AutoMapper;
using BLL.Request.Sale;
using DLL.Models;
using DLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.Helper;

namespace BLL.Service
{
    public interface ISaleService
    {
        string CompleateTransaction(PaymentRequest paymentRequest);
    }

    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public string CompleateTransaction(PaymentRequest paymentRequest)
        {
            try
            {

                string msg = PaymentValidation(paymentRequest);
                if (msg == "")
                {
                    
                    Order oOrder = new Order();
                    List<OrderDetails> oOrderDetailsList = new List<OrderDetails>();
                    Payment oPayment = new Payment();
                    string createdBy = "Tahmid";
                    DateTime createdOn = DateTime.Now;

                    //Order Start
                    _unitOfWork.BeginTrnsaction();

                    oOrder.SubTotal = paymentRequest.SubTotal;
                    oOrder.TotalVat = paymentRequest.TotalVat;
                    oOrder.OtherCharge = paymentRequest.OtherCharge;
                    oOrder.TotalDiscount = paymentRequest.TotalDiscount;
                    oOrder.GrandTotal = paymentRequest.GrandTotal;

                    oOrder.OrderCode = "SW-" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    oOrder.OrderType = "Shop-Purchase";
                    oOrder.OrderDate = DateTime.Now;
                    oOrder.DeliveryDate = DateTime.Now.ToString();
                    oOrder.DeliverDue = 0;
                    oOrder.BranchId = 1;
                    oOrder.Status = 1;
                    oOrder.CreatedBy = createdBy;
                    oOrder.CreatedOn = createdOn;
                    oOrder.IsActive = true;
                    oOrder.DeliveryCharge = 0;

                    _unitOfWork.OrderRepository.Add(oOrder);
                    //Order End


                    //Payment Start

                    oPayment.PaymentType = paymentRequest.PaymentType;
                    oPayment.PaymentMethod = paymentRequest.PaymentMethod;
                    oPayment.TotalAmount = paymentRequest.TotalAmount;
                    oPayment.PaidAmount = paymentRequest.PaidAmount;
                    oPayment.ChangeAmount = paymentRequest.ChangeAmount;
                    oPayment.CrDr = "CR";
                    oPayment.CreatedBy = createdBy;
                    oPayment.CreatedOn = createdOn;
                    oPayment.IsActive = true;
                    oPayment.Order = oOrder;
                    _unitOfWork.PaymentRepository.Add(oPayment);

                    //Payment Ends

                    //Order Details Start
                    foreach (var orderDetails in paymentRequest.OrderDetailsList)
                    {
                        var stock = _unitOfWork.ProductRepository.GetProductStock(orderDetails.ProductID);
                        var product = _unitOfWork.ProductRepository.GetSingle(x => x.ProductId == orderDetails.ProductID && x.IsActive == true);
                        var stockQty = stock == null ? 0 : stock.Quantity;
                        if (orderDetails.Quantity > stockQty)
                        {
                            _unitOfWork.RollbackTransaction();
                            
                            if (product == null)
                                return "Unhandled Error";

                            return "Product:" + product.Name + " is out of stock. Latest stock is: " + stockQty;
                        }
                        OrderDetails oOrderDetails = _mapper.Map<OrderDetails>(orderDetails);
                        oOrderDetails.CreatedBy = createdBy;
                        oOrderDetails.CreatedOn = createdOn;
                        oOrderDetails.IsActive = true;
                        oOrderDetails.Order = oOrder;

                        oOrderDetailsList.Add(oOrderDetails);

                        stock.Quantity -= orderDetails.Quantity;
                        stock.UpdatedBy = createdBy;
                        stock.UpdatedOn = createdOn;

                        _unitOfWork.StockRepository.Update(stock);

                        //var stockUpdateSts=_unitOfWork.ProductRepository.UpdateStock(orderDetails.ProductID, orderDetails.Quantity);
                        //if (stockUpdateSts < 1)
                        //{
                        //    _unitOfWork.RollbackTransaction();
                        //    return "Error in updating stock for Product:" + product.Name; ;
                        //}
                    }

                    //Order Details End

                    _unitOfWork.OrderDetailsRepository.AddRange(oOrderDetailsList);
                    _unitOfWork.Save();
                    _unitOfWork.CommitTransaction();
                    return GlobalConstant.OPERATION_SUCCESS;
                }

                return GlobalConstant.OPERATION_ERROR;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw ex;
            }

        }

        private string PaymentValidation(PaymentRequest paymentRequest)
        {
            if (paymentRequest.OrderDetailsList.Count() == 0)
            {
                return "Order List Can not be empty";
            }

            if (paymentRequest.GrandTotal == 0)
            {
                return "Grand Total can not be 0";
            }

            if (paymentRequest.PaidAmount < paymentRequest.GrandTotal)
            {
                return "Paid Amount can not be less than Grand Total";
            }
            return "";
        }
    }
}
