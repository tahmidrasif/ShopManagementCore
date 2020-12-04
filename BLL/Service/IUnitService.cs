using BLL.ViewModel.Unit;
using DLL.Models;
using DLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service
{
    public interface IUnitService
    {
        UnitViewModel GetUnitById(long id);
    }

    public class UnitService : IUnitService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public UnitViewModel GetUnitById(long id)
        {
            try
            {
                if (id > 0)
                {
                    var unit = _unitOfWork.UnitRepository.GetSingle(x => x.UnitId == id);

                    if (unit != null)
                    {
                        UnitViewModel unitVM = new UnitViewModel()
                        {
                            UnitId = unit.UnitId,
                            UnitName = unit.UnitName,
                            UnitType = unit.UnitType
                        };

                        return unitVM;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
