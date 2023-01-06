using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NewsSite.Interface;
using NewsSite.Models;
using NewsSite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Repozitory
{
    public class NewRepozitory : IAllNews
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContent appDbContent;

        public NewRepozitory(AppDbContent appDbContent, IWebHostEnvironment hostingEnvironment)
        {
            this.appDbContent = appDbContent;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IEnumerable<New> GetAllNews => appDbContent.News.Include(c => c.Category);

        public IEnumerable<New> GetFavoriteNews => appDbContent.News.Where(p => p.isFavorite).Include(c => c.Category);

        public New GetOneNew(int? newId)
        {
             New oneNew = appDbContent.News.FirstOrDefault(p => p.Id == newId);
             return oneNew;
                        
        }
                
        public New DeleteNews(int? id)
        {
            New news = appDbContent.News.FirstOrDefault(p => p.Id == id);
            if (news != null)
            {
                appDbContent.Remove(news);
                appDbContent.SaveChanges();
            }
            return news;
        }

         public New AddNewsGet()
        {
            NewsViewModel addNewsGet = new NewsViewModel { Categories = appDbContent.Categories.ToList() };
            return addNewsGet;
        }


      public  New AddNewsPost(NewsViewModel _news)
        {
            if (_news.Photo!=null)
            {
                string filePath = $@"{hostingEnvironment.WebRootPath}\img\{_news.Photo.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    _news.Photo.CopyTo(fs);
                    fs.Flush();
                }

                NewsViewModel news = new NewsViewModel
                {
                    Name = _news.Name,
                    LongText = _news.LongText,
                    shortText = _news.shortText,
                    isFavorite = _news.isFavorite,
                    img = "/img/" + _news.Photo.FileName,
                    Time = _news.Time,
                    Category = _news.Category,
                    CategoryId = _news.CategoryId,
                    Categories = appDbContent.Categories.ToList()

                };
                appDbContent.News.Add(news);
                appDbContent.SaveChanges();
                return news;
            }
            else {
                
                NewsViewModel news = new NewsViewModel
                {
                    Name = _news.Name,
                    LongText = _news.LongText,
                    shortText = _news.shortText,
                    isFavorite = _news.isFavorite,
                    img =  _news.img,
                    Time = _news.Time,
                    Category = _news.Category,
                    CategoryId = _news.CategoryId,
                    Categories = appDbContent.Categories.ToList()

                };
                appDbContent.News.Add(news);
                appDbContent.SaveChanges();
                return news;
            }
            
        }

        public New EditNewsGet(int? id)
        {
            New news = appDbContent.News.FirstOrDefault(p => p.Id == id);
           
               NewsViewModel _news = new NewsViewModel
                {
                    Id = news.Id,
                    Name = news.Name,
                    LongText = news.LongText,
                    shortText = news.shortText,
                    isFavorite = news.isFavorite,
                    img = news.img,
                    Time = news.Time,
                    Category = news.Category,
                    CategoryId = news.CategoryId,
                    Categories = appDbContent.Categories.ToList()

                };
                return _news;            
        }

       public New EditNewsPost(NewsViewModel _news)
        {


            if (_news.Photo!=null)
            {
                string filePath = $@"{hostingEnvironment.WebRootPath}\img\{_news.Photo.FileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    _news.Photo.CopyTo(fs);
                    fs.Flush();
                }
                NewsViewModel news = new NewsViewModel
                {
                    Id = _news.Id,
                    Name = _news.Name,
                    LongText = _news.LongText,
                    shortText = _news.shortText,
                    isFavorite = _news.isFavorite,
                    img = "/img/" + _news.Photo.FileName,
                    Time = _news.Time,
                    Category = _news.Category,
                    CategoryId = _news.CategoryId,
                    Categories = appDbContent.Categories.ToList()

                };

                appDbContent.News.Update(news);
                appDbContent.SaveChanges();
                return news;

            }
            else
            {
                NewsViewModel news = new NewsViewModel
                {
                    Id = _news.Id,
                    Name = _news.Name,
                    LongText = _news.LongText,
                    shortText = _news.shortText,
                    isFavorite = _news.isFavorite,
                    img = _news.img,
                    Time = _news.Time,
                    Category = _news.Category,
                    CategoryId = _news.CategoryId,
                    Categories = appDbContent.Categories.ToList()

                };

                appDbContent.News.Update(news);
                appDbContent.SaveChanges();
                return news;
            }




        }
    }
}
