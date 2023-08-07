using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class BranchesService : IBranchesService
    {
        private readonly UnitOfWork _unitOfWork;
        public IConfiguration _configuration;
        public BranchesService(IConfiguration config, StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _configuration = config;
        }

        public IEnumerable<Branch> GetListBranches()
        {
            List<Branch> listBranches = _unitOfWork.BranchRepository.GetAll().ToList();
            if (listBranches.Any())
            {
                return listBranches;
            }
            return null;
        }

        public Branch GetBranchByCode(string branchCode)
        {
            Branch branch = _unitOfWork.BranchRepository.Get(b => b.BranchCode.Equals(branchCode));
            return branch;
        }
        public Branch GetBranchById(int branchId)
        {
            Branch branch = _unitOfWork.BranchRepository.Get(b => b.BranchCode.Equals(branchId));
            return branch;
        }
        public bool UpdateBranch(int branchId, Branch branch)
        {
            Branch branchCur = _unitOfWork.BranchRepository.Get(b => b.BranchCode.Equals(branchId));
            branchCur.BranchCode = branch.BranchCode;
            branchCur.BranchName = branch.BranchName;
            branchCur.Address = branch.Address;
            branchCur.PhoneNumber = branch.PhoneNumber;
            branchCur.ManagerID = branch.ManagerID;
            branchCur.ModifyDate = DateTime.Now;
            branchCur.ModifyBy = branch.ModifyBy;
            try
            {
                _unitOfWork.BranchRepository.Update(branchCur);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBranch(int branchId)
        {
            try
            {
                _unitOfWork.BranchRepository.Delete(branchId);
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
