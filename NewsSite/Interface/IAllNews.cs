using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using NewsSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Interface
{
    public interface IAllNews
    {
        IEnumerable<New> GetAllNews { get; }

        IEnumerable<New> GetFavoriteNews { get; }

        New DeleteNews(int? id);

        New GetOneNew(int? newId);

        New AddNewsGet();
        New AddNewsPost(NewsViewModel _news);

        New EditNewsGet(int? id);
        New EditNewsPost(NewsViewModel _news);

       


    }
}
