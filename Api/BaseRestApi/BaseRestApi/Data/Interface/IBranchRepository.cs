using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BaseRestApi.DTO;
using BaseRestApi.Models;

namespace BaseRestApi.Data.Interface
{
    public interface IBranchRepository
    {
        List<BranchDto> GetBranch();

        void CreateBranch (BranchDto branch);
        void EditBranch (BranchDto editBranch);
        void DeleteBranch (int branchId);
        bool CheckBranchById(int branchId);
    }
}