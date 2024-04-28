using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameworks;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());

        public IActionResult Index()
        {
            var values=blogManager.GetBlogListCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values=blogManager.GetBlogById(id);

            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values=blogManager.GetListCategoryByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                           select new SelectListItem
                                                           {
                                                               Text = x.CategoryName,
                                                               Value = x.CategoryId.ToString()
                                                           }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidation blogValidations = new BlogValidation();
            ValidationResult validationResult = blogValidations.Validate(blog);

            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1; 
                blogManager.TAdd(blog);
                
                
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValue=blogManager.GetById(id);
            blogManager.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue=blogManager.GetById(id);
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            blog.WriterId = 1;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
