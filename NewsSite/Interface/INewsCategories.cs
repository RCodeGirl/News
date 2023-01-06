using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Interface
{
    public interface INewsCategories
    {
        IEnumerable<Category> GetCategories { get; }

        Category AddCategory(Category category);

        Category EditCategoryGet(int? id);
        Category EditCategoryPost(Category category);
        Category DeleteCategory(int? id);

    }
}
