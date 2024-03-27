using DesignProjectGit.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit
{
    public class Branch : Component
    {
        private string _name;
        private IState _status;
        private Stack<Branch> history;
        public Branch(string name) : base(name)
        {
            Children = new();
            history = new();
        }

        public override string Name { get => _name; set => _name = value; }
        public override IState Status { get => _status; set => _status = value; }
        public Dictionary<string, Component> Children { get; set; }

        public void Clone(string name)
        {
            Branch branch = new Branch(name) {
                _status = _status,
                Children = new()
            };
            foreach (var item in Children)
            {
                branch.Children.Add(item.Key, item.Value);
            }
        }
        public override void Merge(Component comp)
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
