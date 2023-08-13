using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IBranchesService
    {
        IEnumerable<Branch> GetListBranches();

        Branch GetBranchByCode(string branchCode);

        Branch GetBranchById(int branchId);

        Branch CreateBranch(Branch branch);

        bool UpdateBranch(int branchId, BranchInfo branch, int? userId);
        bool DeleteBranch(int branchId, int? userId);
    }
}
