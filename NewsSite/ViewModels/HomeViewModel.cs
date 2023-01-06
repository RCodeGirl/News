using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<New> GetFavoriteNews { get; set; }
    }
}
