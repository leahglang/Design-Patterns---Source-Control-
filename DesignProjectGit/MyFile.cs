﻿using DesignProjectGit.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit
{
    public class MyFile : Component
    {   
        private Stack<MyFile> history;
        private string _name;
        private IState _status;

        public override string Name { get => _name; set => _name = value; }
        public override IState Status { get => _status; set => _status = value; }
        public string Content { get; set; }

        public MyFile(string name, string content = null) : base(name)
        {
            history = new();
            this.Content = content;
        }

        public override Component Merged(Component comp)
        {
            Component myFile = base.Merged(comp);
            if (myFile == comp)
            {
                if (((MyFile)myFile).Content.Equals(((MyFile)comp).Content))
                {
                    Console.WriteLine("The files are same");
                }
                else
                {
                    Console.WriteLine("The marge be succsesfully");
                }
            }
            return myFile;
            //history.Push(new MyFile(this.Name) { Status = this.Status });
            //this.Content = ((MyFile)comp).Content;
            //Status.ChangeStatus(this);
        }

        public override void Undo()
        {
            if (history.Count() <= 0)
            {
                return;
            }
            var last = history.Pop();
            if (last == null) return;
            this.Status = last.Status;
            this.Content = last.Content;
        }

        public override void Print()
        {
            Console.WriteLine($"I'm file & my name is {this._name} and I contain : {this.Content}");
        }
    }
}
