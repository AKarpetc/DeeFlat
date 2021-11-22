using Microsoft.AspNetCore.SignalR;

namespace DeeFlat.Homework.WebHost
{
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name;
        }
    }
}
