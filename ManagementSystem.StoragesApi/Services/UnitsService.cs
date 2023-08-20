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

        public IEnumerable<Unit> GetListUnits()
        {
            List<Unit> units = _unitOfWork.UnitRepository.GetAll().ToList();
            if (units.Any())
            {
                return units;
            }
            return new List<Unit>();
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
        public bool UpdateUnit(Unit unit, int userId)
        {
            unit.ModifyDate = DateTime.Now;
            unit.ModifyBy = userId;
            try
            {
                _unitOfWork.UnitRepository.Update(unit);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
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
