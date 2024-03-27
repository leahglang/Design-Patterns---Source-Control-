using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.State;

public class Staged : IState
{
    private static Staged _instance;
    public static Staged GetInstance()
    {

        if (_instance == null)
        {
            _instance = new Staged();
        }
        return _instance;
    }

    public void ChangeStatus(Component component)
    {
        component.Status = Staged.GetInstance();
    }

    public string GetStatus()
    {
        return "Staged";
    }
}
