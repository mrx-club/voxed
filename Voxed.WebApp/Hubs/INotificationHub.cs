using System.Threading.Tasks;
using Voxed.WebApp.Models;

namespace Voxed.WebApp.Hubs
{
    public interface INotificationHub
    {
        Task Comment(CommentLiveUpdate comment);
        Task Notification(UserNotification notification);
        Task RemoveNotification(RemoveNotificationModel removeNotification);
        Task Vox(VoxResponse notification);
    }
}

