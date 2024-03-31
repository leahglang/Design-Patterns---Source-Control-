using DesignProjectGit.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit
{
    public class Folder: Component
    {
        private string _name;
        private IState _status;
        private Stack<Folder> history;
        public override string Name { get => _name; set => _name = value; }
        public override IState Status { get => _status; set => _status = value; }
        public Dictionary<string, Component> Children { get; set; }

        public Folder(string name) : base(name)
        {
            Children = new();
            history = new();
        }

        public override void Merge(Component comp)
        {
            if (this.Status.GetStatus() != "ReadyToMerge")
            {
                Console.WriteLine("error, you can't marge");
                return;
            }
            history.Push(new Folder(this.Name) { Status = this.Status, Children = this.Children });
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
            Console.WriteLine($"I'm folder & my name is {this._name}, my children are: ");
            foreach (var child in Children)
            {
                child.Value.Print();
            }
        }


        public override void Undo()
        {
            if (history.Count() <= 0)
            {
                return;
            }
            var last = history.Pop();
            if (last != null) return;
            this.Status = last.Status;
            this.Children = last.Children;
            foreach (var child in this.Children)
            {
                child.Value.Undo();
            }
        }
        public void Add(Component component)
        {
            if(component.GetType() == typeof(Branch)) return;
            Children.Add(component.Name, component);
            Status = Draft.GetInstance();
        }
    }
}

