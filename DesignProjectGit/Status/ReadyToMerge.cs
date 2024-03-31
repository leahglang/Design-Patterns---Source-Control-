using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.State
{
    public class ReadyToMerge : IState
    {
        private static ReadyToMerge _instance;
        public static ReadyToMerge GetInstance()
        {

            if (_instance == null)
            {
                _instance = new ReadyToMerge();
            }
            return _instance;
        }

        public void ChangeStatus(Component component)
        {
            component.Status = ReadyToMerge.GetInstance();
        }

        public string GetStatus()
        {
            return "ReadyToMerge";
        }
    }
}
