using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotification _notification;
        public NotificationManager(INotification notification)
        {
            _notification = notification;
        }

        public Notification GetById(int id)
        {
            return _notification.GetById(id);
        }

        public List<Notification> GetList()
        {
            return _notification.GetAll();
        }

        public void TAdd(Notification notification)
        {
            _notification.Insert(notification);
        }

        public void TDelete(Notification notification)
        {
            _notification.Delete(notification);
        }

        public void TUpdate(Notification notification)
        {
            _notification.Update(notification);
        }
    }
}
