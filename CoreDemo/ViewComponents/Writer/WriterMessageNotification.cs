using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageRepository());
        public IViewComponentResult Invoke()
        {
            string message;
            message = "deneme11@gmail.com";
            var values = messageManager.GetInboxListByWriter(message);
            return View();
        }
    }
}
