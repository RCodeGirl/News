using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsSite.Interface;
using NewsSite.Models;
using NewsSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IAllNews allNews;
       
        public HomeController(IAllNews _allNews)
        {
            allNews = _allNews;
            
        }

        public ViewResult Index()
        {
            var homeNews = new HomeViewModel { 
                GetFavoriteNews = allNews.GetFavoriteNews
            } ;
            return View(homeNews);
        }


        
    }
}
