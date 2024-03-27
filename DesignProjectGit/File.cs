using DesignProjectGit.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit
{
    public class File : Component
    {
        public File(string name, string content = null) : base(name)
        {
            history = new();
            this.Content = content;
        }

        private Stack<MyFile> history;
        private string _name;
        private IState _status;
    }
}
