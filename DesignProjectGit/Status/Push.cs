using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.State;

public class Push : IState
{
    private static Push _instance;
    public static Push GetInstance()
    {

        if (_instance == null)
        {
            _instance = new Push();
        }
        return _instance;
    }

    public void ChangeStatus(Component component)
    {
        component.Status = UnderReview.GetInstance();
        Console.WriteLine("Push");
    }

    public string GetStatus()
    {
        return "Push";
    }
}
