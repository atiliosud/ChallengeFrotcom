using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFrotcom.Bussines.Service
{
    public class NotificationService : INotification
    {
        private List<Notification> notifications;

        public NotificationService()
        {
            notifications = new List<Notification>();
        }

        public void Handle(Notification notificacao)
        {
            notifications.Add(notificacao);
        }

        public List<Notification> GetNotification()
        {
            return notifications;
        }

        public bool HasNotification()
        {
            return notifications.Any();
        }
    }
}
