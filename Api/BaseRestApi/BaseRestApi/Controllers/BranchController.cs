using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.DTO;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IBranchService BranchService { get; }
        private ILogger<BranchController> Logger { get; }
        private AppSettings AppSettings { get; }
        private ITrace Trace { get; }

        public BranchController(IBranchService BranchService , ILogger<BranchController> Logger, AppSettings AppSettings, ITrace Trace)
        {
            this.BranchService = BranchService;
            this.Logger = Logger;
            this.AppSettings = AppSettings;
            this.Trace = Trace;
        }

        [HttpGet]
        public Result<List<BranchDto>> GetBranch()
        {   
            Result<List<BranchDto>> result = new Result<List<BranchDto>>(Trace);
            result = BranchService.GetBranch();
            return result;

        }

        [HttpPost]
        public Result<string> CreateBranch([FromBody] BranchDto newBranch)
        {
            Result<string> result = new Result<string>(Trace);
            result = BranchService.CreateBranch(newBranch);
            return result;
        }

        [HttpPut]
        public Result<string> EditBranch([FromBody] BranchDto editBranch)
        {
            Result<string> result = new Result<string>(Trace);
            if(editBranch.ID == null)
            {
                result.Message = "Branch Id นี้ ไม่มีข้อมูล";
            }
            else
            {
                result = BranchService.EditBranch(editBranch);
            }
            return result;
        }

        [HttpDelete("{branchId}")]
        public Result<string> DeleteBranch(int? branchId)
        {
            Result<string> result = new Result<string>(Trace);
            if(!branchId.HasValue)
            {
                result.Message = "Branch Id นี้ ไม่มีข้อมูล";
            }
            else
            {
                result = BranchService.DeleteBranch(branchId.Value);
            }
            return result;
        }
    }
}