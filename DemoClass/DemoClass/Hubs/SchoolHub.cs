using Microsoft.AspNetCore.SignalR;

namespace DemoClass.Hubs;

public class SchoolHub : Hub
{
    public string ID { get; set; }

    private static List<string> nameClasses = new List<string>();

    private static List<string> deviceIds = new List<string>();

    private static List<string> connectionIds = new List<string>();


    public async Task JoinClass(string className)
    {
        if (!nameClasses.Contains(className))
        {
            nameClasses.Add(className);
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, className);
    }

    public async Task LeaveClass(string className)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, className);
    }


    

    public async Task BroadcastMessage(float x, float y, float z)
    {

        if (!connectionIds.Contains(Context.ConnectionId.ToString()))
        {

            connectionIds.Add(Context.ConnectionId.ToString());

        }

        int id = connectionIds.IndexOf(Context.ConnectionId.ToString());

        await Clients.Others.SendAsync("OnMessageReceived", id, x, y, z);
    }


    public string GetClassName(string deviceID)
    {
        if (!deviceIds.Contains(deviceID))
        {
            deviceIds.Add(deviceID);
        }

        return "Class" + deviceIds.Count / 10;
    }



    public List<string> GetNameClasses(string deviceID)
    {
        

        return nameClasses;
    }


}
