using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;

namespace ManagementSystem.StoragesApi.Services
{
    public class BranchesService : IBranchesService
    {
        private readonly UnitOfWork _unitOfWork;
        public BranchesService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<Branch> GetListBranches()
        {
            List<Branch> listBranches = _unitOfWork.BranchRepository.GetAll().ToList();
            if (listBranches.Any())
            {
                return listBranches;
            }
            return new List<Branch>();
        }

        public Branch CreateBranch(Branch branch)
        {
            try
            {
                _unitOfWork.BranchRepository.Insert(branch);
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return branch;
            } catch (Exception ex)
            {
                return null;
            }
            
        }

        public Branch GetBranchByCode(string branchCode)
        {
            Branch branch = _unitOfWork.BranchRepository.Get(b => b.BranchCode.Equals(branchCode));
            return branch;
        }
        public Branch GetBranchById(int branchId)
        {
            Branch branch = _unitOfWork.BranchRepository.Get(b => b.BranchId.Equals(branchId));
            return branch;
        }
        public bool UpdateBranch(int branchId, BranchRequest branch)
        {
            Branch branchCur = _unitOfWork.BranchRepository.Get(b => b.BranchId.Equals(branchId));
            branchCur.BranchCode = branch.BranchCode;
            branchCur.BranchName = branch.BranchName;
            branchCur.Address = branch.Address;
            branchCur.PhoneNumber = branch.PhoneNumber;
            branchCur.ModifyDate = DateTime.Now;
            branchCur.ModifyBy =  0;
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
