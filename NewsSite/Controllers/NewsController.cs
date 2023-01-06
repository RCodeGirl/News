using Microsoft.AspNetCore.Mvc;
using NewsSite.Interface;
using NewsSite.Models;
using NewsSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly IAllNews allNews;
        private readonly INewsCategories newsCategories;
        public NewsController(IAllNews _allNews, INewsCategories _newsCategories)
        {
            allNews = _allNews;
            newsCategories = _newsCategories;
        }

        
        [Route("News/ListNews")]
        [Route("News/ListNews/{id}")]
        public ViewResult ListNews (int? id)
        {

            IEnumerable<New> news= allNews.GetAllNews.Where(_ => _.CategoryId == id).ToList();
            
            string currCategory = news.FirstOrDefault()?.Category.CategoryName;             
            var newObj = new NewListViewModel
            {
                getAllNews = news,
                currCategory = currCategory
            };
           
            ViewBag.Title = "Страница с Новостями";
           
            return View(newObj);
        }
    }
}
