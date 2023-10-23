namespace StreamVideo.Wep.Models;

public class Call
{
    public User From { get; set; }
    public User To { get; set; }
    public DateTime CallStartTime { get; set; }
}
