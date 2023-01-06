using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class NewListViewModel
    {
        public IEnumerable<New> getAllNews { get; set; }
         
        public string currCategory { get; set; }
    }
}
