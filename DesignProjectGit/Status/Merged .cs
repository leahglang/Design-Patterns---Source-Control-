using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.State
{
    public class Merged: IState
    {
        private static Merged _instance;
        public static Merged GetInstance()
        {

            if (_instance == null)
            {
                _instance = new Merged();
            }
            return _instance;
        }

        public void ChangeStatus(Component component)
        {
            component.Status = Merged.GetInstance();
        }

        public string GetStatus()
        {
            return "Merged";
        }
    }
}
