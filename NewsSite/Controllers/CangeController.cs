using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsSite.Repozitory;
using NewsSite.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using NewsSite.Interface;

namespace NewsSite.Controllers
{
    public class CangeController : Controller
    {
        private static AppDbContent db;
        private readonly IAllNews allNews;
        private readonly INewsCategories allCategories;
        private readonly IWebHostEnvironment hostingEnvironment;
        public CangeController(AppDbContent context,IAllNews _allNews, IWebHostEnvironment hosting, INewsCategories _allCategories)
        {
            allNews = _allNews;
            allCategories = _allCategories;
            hostingEnvironment = hosting;
            db = context;
            
        }

        public IActionResult GetResult()
        {
            return View(allNews.GetAllNews);
        }

        public IActionResult AddNews()
        {

            return View(allNews.AddNewsGet());
        }
        [HttpPost]
        public IActionResult AddNews(NewsViewModel _news)
        {
                allNews.AddNewsPost(_news);
                return RedirectToAction("GetResult");
           
        }

        public IActionResult GetResutCategory()
        {
            return View(allCategories.GetCategories);
        }

        public IActionResult AddCategories()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddCategories(Category category)
        {
            allCategories.AddCategory(category);
            return RedirectToAction("GetResutCategory");
        }

        public IActionResult DetailsNews(int? id)
        {
            if (id != null)
                return View(allNews.GetOneNew(id));
            return NotFound();
        }

        public IActionResult EditNews(int? id)
        {
            if (id != null)
                return View (allNews.EditNewsGet(id));
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditNews(NewsViewModel _news)
        {
            
                allNews.EditNewsPost(_news);
            return RedirectToAction("GetResult");
        }

        public IActionResult DeleteNews(int? id)
        {
            if (id != null)
            {
                allNews.DeleteNews(id);                
                return RedirectToAction("GetResult");
                
            }
            return NotFound();
        }

        public IActionResult EditCategory(int? id)
        {
            if (id != null)
            {
              return View(allCategories.EditCategoryGet(id));
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditCategory (Category category)
        {            
           allCategories.EditCategoryPost(category);
           return RedirectToAction("GetResutCategory");
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id != null)
            {
                allCategories.DeleteCategory(id);
                return RedirectToAction("GetResutCategory");
            }
            return NotFound();
        }

    }
}
