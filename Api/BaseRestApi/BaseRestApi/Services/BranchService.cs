using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.Data.Interface;
using BaseRestApi.DTO;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using BaseRestApi.Data;


namespace BaseRestApi.Services
{
    public class BranchService : IBranchService
    {
        private AppSettings AppSettings {get;}
        private ITrace Trace {get;}
        private ILogger<BranchService> Logger {get;}
        private IBranchRepository BranchRepository {get;}

        public BranchService(AppSettings appSettingsAccessor, ITrace trace, ILogger<BranchService> logger, IBranchRepository BranchRepository)
        {
            this.AppSettings = appSettingsAccessor;
            this.Trace = trace;
            this.Logger = logger;
            this.BranchRepository = BranchRepository;
        }

        public Result<string> CreateBranch(BranchDto branch)
        {
            Result<string> result = new Result<string>(Trace);
            BranchRepository.CreateBranch(branch);
            result.Success = true;
            result.Message = AppSettings?.SuccessMessage?.CreateSuccess!;
            return result;
        }

        public Result<List<BranchDto>> GetBranch()
        {
            Result<List<BranchDto>> result = new Result<List<BranchDto>>(Trace);
            List<BranchDto> createResult = BranchRepository.GetBranch();
            result.Success = true;
            result.Message = AppSettings?.SuccessMessage?.GetSuccess!;
            result.Data = createResult;
            return result;
        }

        public Result<string> DeleteBranch(int branchId)
        {
            Result<string> result = new Result<string> (Trace);
            bool isHaveBranch = BranchRepository.CheckBranchById(branchId);
            if(!isHaveBranch)
            {
                // result.Message = AppSettings.ErrorMessage.EmptyBranchId;
                result.Message = "Branch Id นี้ ไม่มีข้อมูล";
            }
            else
            {
                BranchRepository.DeleteBranch(branchId);
                result.Success = true;
                result.Message = AppSettings?.SuccessMessage?.DeleteSuccess!;
            }
            return result;
        }

        public Result<string> EditBranch(BranchDto branch)
        {
            Result<string> result = new Result<string>(Trace);
            bool isHaveBranch = BranchRepository.CheckBranchById(branch.ID);
            if(!isHaveBranch)
            {
                result.Message = AppSettings.ErrorMessage.EmptyBranchId;
            }
            else
            {
                BranchRepository.EditBranch(branch);
                result.Success = true;
                result.Message = AppSettings.SuccessMessage.ModifySuccess;
            }
            return result;
        }
    }
}