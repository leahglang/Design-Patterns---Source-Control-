using DesignProjectGit.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.Status
{
    public class Pull : IState
    {
        private static Pull _instance;
        public static Pull GetInstance()
        {

            if (_instance == null)
            {
                _instance = new Pull();
            }
            return _instance;
        }

        public void ChangeStatus(Component component)
        {
            component.Status = Push.GetInstance();
            Console.WriteLine("Pull");
        }

        public string GetStatus()
        {
            return "Pull";
        }
    }
}
