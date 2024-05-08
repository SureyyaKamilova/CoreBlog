﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetList().ToPagedList(page, 3);
            return View(values);
        }
    }
}
