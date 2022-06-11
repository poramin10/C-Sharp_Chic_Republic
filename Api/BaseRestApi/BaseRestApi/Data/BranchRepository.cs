using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.Data.Interface;
using BaseRestApi.DTO;
using BaseRestApi.Models;
using BaseRestApi.Data;

namespace BaseRestApi.Data
{
    public class BranchRepository : IBranchRepository
    {
        private BaseRestApiContext Context { get; }

        public BranchRepository(BaseRestApiContext Context)
        {
            this.Context = Context;
        }

        public List<BranchDto> GetBranch()
        {
            List<BranchDto> branchList = Context.Branchs
                .Select((branch)=>
                    new BranchDto
                    {
                        ID = branch.ID,
                        Namebranch = branch.Namebranch
                    }
            ).ToList();
            return branchList;
        }

        public void CreateBranch(BranchDto branch)
        {
            Branch newBranch = new Branch
            {
                Namebranch = branch.Namebranch,
            };

            Context.Branchs.Add(newBranch);
            Context.SaveChanges();
        }

        public bool CheckBranchById(int branchId)
        {
            return Context.Branchs.Any(Branch => Branch.ID == branchId);
        }

        public void DeleteBranch(int branchId)
        {
           Branch currentBranch = Context.Branchs.Where(branch => branch.ID == branchId).FirstOrDefault();
           Context.Remove(currentBranch);
           Context.SaveChanges();
        }

        public void EditBranch(BranchDto editBranch)
        {
            Branch currentBranch = Context.Branchs.Where(branch => branch.ID == editBranch.ID).FirstOrDefault();
            
            if(editBranch.Namebranch != null)
            {
                currentBranch.Namebranch = editBranch.Namebranch;
            }
            
            Context.SaveChanges();
        }
    }
}