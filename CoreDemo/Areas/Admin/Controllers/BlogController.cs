using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("BlogLists");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";

                int blogRowCount = 2;
                foreach (var blog in GetBlogList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = blog.BlogId;
                    worksheet.Cell(blogRowCount, 2).Value = blog.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogList.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel{BlogId=1,BlogName="C# Proqramlaşdırmaya Giriş"},
                new BlogModel{BlogId=2,BlogName="Tesla Firmasının Maşınları"},
                new BlogModel {BlogId=3,BlogName="2024 Paris Voleybol Olimpiyatları"}
            };
            return blogModels;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("BlogLists");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";

                int blogRowCount = 2;
                foreach (var blog in BlogTitleList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = blog.Id;
                    worksheet.Cell(blogRowCount, 2).Value = blog.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogList.xlsx");
                }
            }
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> blogModel2 = new List<BlogModel2>();
            using(var context=new Context())
            {
                blogModel2 = context.Blogs.Select(x => new BlogModel2
                { 
                    Id=x.BlogId,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return blogModel2;
        }
    }
}
