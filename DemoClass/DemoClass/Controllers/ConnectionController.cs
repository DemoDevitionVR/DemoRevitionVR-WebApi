using DemoClass.Hubs;
using Microsoft.AspNetCore.Mvc;

namespace DemoClass.Controllers;



[ApiController]
[Route("[controller]")]
public class ConnectionController : ControllerBase
{

    private static List<SchoolHub> schoolsHub = new List<SchoolHub>();

    [HttpPost]
    public string PostDeciceID(string deviceID, string schoolID)
    {
        SchoolHub schoolHub = GetSchoolHub(schoolID);

        if (schoolHub != null)
            return schoolHub.GetClassName(deviceID);

        return "null";
    }


    private SchoolHub GetSchoolHub(string id)
    {
        SchoolHub schoolHub;

        int count = schoolsHub.Count;
        for (int i = 0; i < count; i++)
        {
            if (schoolsHub[i].ID == id)
            {
                schoolHub = schoolsHub[i];
                return schoolHub;
            }

        }

        schoolHub = new SchoolHub();
        schoolsHub.Add(schoolHub);

        return schoolHub;
    }
}
