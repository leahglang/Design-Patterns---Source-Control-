using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignProjectGit.State;

public class UnderReview : IState
{
    private static UnderReview _instance;
    public static UnderReview GetInstance()
    {

        if (_instance == null)
        {
            _instance = new UnderReview();
        }
        return _instance;
    }

    public void ChangeStatus(Component component)
    {
        component.Status = ReadyToMerge.GetInstance();
        Console.WriteLine("UnderReview");
    }

    public string GetStatus()
    {  
        return "UnderReview";    
    }
}
