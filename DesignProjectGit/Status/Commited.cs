using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.State
{
    public class Commited :IState
    {
        private static Commited _instance;
        public static Commited GetInstance()
        {

            if (_instance == null)
            {
                _instance = new Commited();
            }
            return _instance;
        }

        public void ChangeStatus(Component component)
        {
            component.Status = Commited.GetInstance();
        }

        public string GetStatus()
        {
            return "Committed";
        }
    }
}
