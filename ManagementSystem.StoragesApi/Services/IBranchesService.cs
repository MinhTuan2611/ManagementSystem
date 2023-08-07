using ManagementSystem.Common.Entities;

namespace ManagementSystem.StoragesApi.Services
{
    public interface IBranchesService
    {
        IEnumerable<Branch> GetListBranches();

        Branch GetBranchByCode(string branchCode);

        Branch GetBranchById(int branchId);

        bool UpdateBranch(int branchId, Branch branch);
        bool DeleteBranch(int branchId);

    }
}
