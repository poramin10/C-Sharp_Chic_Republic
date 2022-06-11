using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.DTO;

namespace BaseRestApi.Services.Interface
{
    public interface IBranchService
    {
        Result<List<BranchDto>> GetBranch();
        Result<string> CreateBranch(BranchDto branch);
        Result<string> EditBranch(BranchDto branch);
        Result<string> DeleteBranch(int branchId);
    }
}