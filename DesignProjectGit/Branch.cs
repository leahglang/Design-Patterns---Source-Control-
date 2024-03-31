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
        public override string Name { get => _name; set => _name = value; }
        public override IState Status { get => _status; set => _status = value; }
        public Dictionary<string, Component> Children { get; set; }

        public Branch(string name) : base(name)
        {
            Children = new();
            history = new();
        }

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
            this.Children.Add(name, branch);
            Status = Draft.GetInstance();
        }

        public void Add(Component component)
        {
            Children.Add(component.Name, component);
            Status = Draft.GetInstance();
        }

        public void DeleteBranch(string branchName)
        {
            Children.Remove(branchName);
            Status = Draft.GetInstance();
        }

        public override void Merge(Component comp)
        {
            if(this.Status.GetStatus() != "ReadyToMerge")
            {
                Console.WriteLine("error, you can't marge");
                return;
            }
            history.Push(new Branch(this.Name) { Status = this.Status, Children = this.Children});
            foreach (var child in ((Branch)comp).Children)
            {
                try
                {
                    this.Children[child.Key].Merge(child.Value);
                }
                catch (Exception)
                {
                    this.Children.Add(child.Key, child.Value);
                }
            }
            Status.ChangeStatus(this);
        }

        public override void Print()
        {
            Console.WriteLine($"I'm branch & my name is {this._name}, my children are: ");
            foreach(var child in Children)
            {
                child.Value.Print();
            }
        }

        public Branch GetBranch(string branchName)
        {
            try
            {
                return (Branch)Children[branchName];
            }
            catch
            {
                Branch result;
                foreach (var child in Children)
                {
                    if (child.GetType() != typeof(Branch)) { return null; }
                    result = ((Branch)child.Value).GetBranch(branchName);
                    if (result != null) return result;
                }
            }
            return null;
        }

        public override void Undo()
        {
            Branch last = history.Pop();
            if( last != null ) return;
            this.Status = last.Status;
            this.Children = last.Children;
            foreach(var child in this.Children)
            {
                child.Value.Undo();
            }
        }
    }
}
