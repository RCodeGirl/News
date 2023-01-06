using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NewsSite.Models;


namespace NewsSite.Models
{
    public class New
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LongText { get; set; }
        public string shortText { get; set; }
        public bool isFavorite { get; set; }
        public string img { get; set; }
        public DateTime  Time { get; set; }
        public Category Category { get; set; }
        public int  CategoryId { get; set; }
       
    }
}
