using Microsoft.AspNetCore.Http;
using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class NewsViewModel:New
    {
        public List<Category> Categories { get; set; }
        public IFormFile Photo { get; set; }
    }
}
