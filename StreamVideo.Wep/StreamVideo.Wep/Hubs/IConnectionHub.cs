using StreamVideo.Wep.Models;
using System.Threading.Channels;

namespace StreamVideo.Wep.Hubs;

public interface IConnectionHub
{
    Task UpdateOnlineUsers(List<User> userList);
    Task CallAccepted(User acceptingUser);
    Task CallDeclined(User decliningUser, string reason);
    Task IncomingCall(User callingUser);
    Task ReceiveData(User signalingUser, string signal);
    Task UploadStream(ChannelReader<string> stream);
    Task CallEnded(User signalingUser, string signal);
}
