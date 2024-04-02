using DesignProjectGit.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.State;

public class Draft:IState
{
    private static Draft _instance;
    public static Draft GetInstance()
    {

        if (_instance == null)
        {
            _instance = new Draft();
        }
        return _instance;
    }

    public void ChangeStatus(Component component)
    {
        component.Status = Added.GetInstance();
        Console.WriteLine("Draft");
    }

    public string GetStatus()
    {       
        return "Draft";
    }
}
