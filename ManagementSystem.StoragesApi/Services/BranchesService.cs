using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Entities.Bills;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.StoragesApi.Services
{
    public class BranchesService : IBranchesService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StoragesDbContext _context;
        public BranchesService(StoragesDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _context = context;
        }

        public IEnumerable<Branch> GetListBranches()
        {
            List<Branch> listBranches = _unitOfWork.BranchRepository.GetMany(b => b.Status.Equals(ActiveStatus.Active)).ToList();
            var branchVerifies = _context.BranchVerifications.ToList();

            foreach (var branch in listBranches)
            {
                branch.BranchVerifications = branchVerifies.Where(x => x.BranchId == branch.BranchId).ToList();
            }
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
        public bool UpdateBranch(int branchId, BranchInfo branch, int? userId)
        {
            Branch branchCur = _unitOfWork.BranchRepository.Get(b => b.BranchId.Equals(branchId));
            branchCur.BranchCode = branch.BranchCode;
            branchCur.BranchName = branch.BranchName;
            branchCur.Address = branch.Address;
            branchCur.PhoneNumber = branch.PhoneNumber;
            branchCur.ModifyDate = DateTime.Now;
            branchCur.ModifyBy = userId;
            try
            {
                _unitOfWork.BranchRepository.Update(branchCur);

                if (!string.IsNullOrEmpty(branch.VefificationPassword))
                {
                    var verificationPasswords = branch.VefificationPassword.Split(',').Where(x => x != "null").ToList();

                    var listVerification = _context.BranchVerifications.Where(x => x.BranchId == branchId).ToList();
                    if (listVerification.Count()<2)
                    {
                        if (listVerification.Count() < 1 && verificationPasswords[0] != "null")
                        {
                            _context.BranchVerifications.Add(new BranchVerification()
                            {
                                BranchId = branchId,
                                VerifyPassword = verificationPasswords[0]
                            });
                        }

                        if (listVerification.Count() < 2 && verificationPasswords[1] != "null")
                        {
                            _context.BranchVerifications.Add(new BranchVerification()
                            {
                                BranchId = branchId,
                                VerifyPassword = verificationPasswords[1]
                            });
                        }
                    }
                    if (listVerification.Any())
                    {
                        if (verificationPasswords[0] != "null")
                        {
                            listVerification[0].VerifyPassword = verificationPasswords[0];
                            _context.BranchVerifications.Update(listVerification[0]);
                        }
                        if (listVerification.Count() > 1 && verificationPasswords[1] != "null")
                        {
                            listVerification[1].VerifyPassword = verificationPasswords[1];
                            _context.BranchVerifications.Update(listVerification[1]);
                        }
                        
                    }
                }

                _context.SaveChanges();
                _unitOfWork.Save();
                _unitOfWork.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBranch(int branchId, int? userId)
        {
            Branch branch = _unitOfWork.BranchRepository.GetByID(branchId);
            branch.Status -= ActiveStatus.Inactive;
            branch.ModifyDate = DateTime.Now;
            branch.ModifyBy = userId;
            try
            {
                _unitOfWork.BranchRepository.Update(branch);
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
