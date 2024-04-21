using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comments
{
    public class CommentListByBlog:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EFCommentRepository());

       public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.GetListId(id);

            return View(values);
        } 
    }
}
