using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IUnitsService
    {
        public List<Unit> GetListUnits();
        public Unit CreateUnit(Unit unit);
        public bool UpdateUnit(Unit unit, int userId);
        public bool DeleteUnit(int unitId);
    }
}
