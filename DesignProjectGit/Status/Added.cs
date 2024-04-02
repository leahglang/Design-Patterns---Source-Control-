using DesignProjectGit.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.Status
{
    public class Added : IState
    {
        private static Added _instance;
        public static Added GetInstance()
        {

            if (_instance == null)
            {
                _instance = new Added();
            }
            return _instance;
        }

        public void ChangeStatus(Component component)
        {
            component.Status = Commited.GetInstance();
            Console.WriteLine("Added");
        }

        public string GetStatus()
        {
            return "Added";
        }
    }
}
