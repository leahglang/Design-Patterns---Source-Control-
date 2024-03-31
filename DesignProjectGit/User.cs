using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit
{
    public class User
    {
        public string UserName { get; set; }

        public Dictionary<string, Branch> Repositories { get; set; }

        public User(string userName)
        {
            this.UserName = userName;
            this.Repositories = new();
        }

        public void AddBranch(string branchName)
        {
            this.Repositories.Add(branchName, new Branch(branchName));
        }

        public void RemoveBranch(string branchName)
        {
            Repositories.Remove(branchName);
        }

        public Branch GetBranch(string branchName)
        {
            try
            {
                return Repositories[branchName];
            }
            catch
            {
                Branch result;
                foreach (var branch in Repositories)
                {
                    result = branch.Value.GetBranch(branchName);
                    if (result != null) { return result; }
                }
            }
            return null;
        }
        public void print()
        {
            foreach (var branch in Repositories)
            {
                branch.Value.Print();
            }
        }
    }

}
