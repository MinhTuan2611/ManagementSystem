using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class UnitsService : IUnitsService
    {
        private readonly UnitOfWork _unitOfWork;
        public UnitsService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public List<Unit> GetListUnits()
        {
            List<Unit> units = _unitOfWork.UnitRepository.GetAll().ToList();
            return units;
        }

        public Unit CreateUnit(Unit unit)
        {
            try
            {
                _unitOfWork.UnitRepository.Insert(unit);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return unit;
            } catch (Exception ex)
            {
                return null;
            }
            
        }
        public Unit UpdateUnit(Unit unit)
        {
            try
            {
                _unitOfWork.UnitRepository.Update(unit);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return unit;
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteUnit(int unitId)
        {
            try
            {
                _unitOfWork.UnitRepository.Delete(unitId);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
