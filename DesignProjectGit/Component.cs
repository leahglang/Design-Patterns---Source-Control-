using DesignProjectGit.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit
{
    public abstract class Component
    {
        private Stack<Folder> history;
        public abstract string Name { get; set; }
        public abstract IState Status { get; set; }

        public Component(string name )
        {
            Name = name;
            Status = Draft.GetInstance();
        }

        public Component RequestReview()
        {
            if (Status.GetStatus() == "Commited")
            {
                Console.WriteLine($"The file {Name} wait to review");
            }
            Status.ChangeStatus(this);
            Status.ChangeStatus(this);
            return this;
        }
        public virtual Component Merged(Component comp)
        {
            if (comp.Status.GetStatus() != "ReadyToMerge")
            {
                Console.WriteLine("error, you can't marge");
                return this;
            }
            Status.ChangeStatus(this);
            return comp;
        }
        public abstract void Undo();
        public abstract void Print();

        public Component Added()
        {
            if (Status.GetStatus() == "Draft")
            {
                Status.ChangeStatus(this);
            }
            return this;
        }

        public virtual Component Commited() 
        {
            if(Status.GetStatus() == "Added")
            {
                Status.ChangeStatus(this);
            }
            return this;
        }

        public void Pull()
        {
            if( Status.GetStatus() == "Commited")
            {
                Status.ChangeStatus(this);
            }
        }

        public void Push()
        {
            if(Status.GetStatus() == "Commited" || Status.GetStatus() == "Pull")
            {
                Status.ChangeStatus(this);
            }
        }

        public void UnderReview()
        {
            if (Status.GetStatus() == "Push")
            {
                Status.ChangeStatus(this);
            }
        }

        public void ReadyToMerge()
        {
            if (Status.GetStatus() == "UnderReview")
            {
                Status.ChangeStatus(this);
            }
        }

    }
}
