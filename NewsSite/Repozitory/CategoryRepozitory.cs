using System;
using NewsSite.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Models;
using Microsoft.EntityFrameworkCore;

namespace NewsSite.Repozitory
{
    public class CategoryRepozitory : INewsCategories
    {
        public readonly AppDbContent appDbContent;

        public CategoryRepozitory(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Category> GetCategories => appDbContent.Categories;

        public Category AddCategory(Category category)
        {
            appDbContent.Categories.Add(category);
            appDbContent.SaveChanges();
            return category;
        }

        public Category EditCategoryGet(int? id)
        {
            Category category = appDbContent.Categories.FirstOrDefault(p => p.Id == id);
            return category;
        }
        public Category EditCategoryPost(Category category)
        {
            appDbContent.Categories.Update(category);
            appDbContent.SaveChanges();
            return category;
        }

       public  Category DeleteCategory(int? id)
        {
            Category category = appDbContent.Categories.FirstOrDefault(p => p.Id == id);
            if (category != null)
            {
                appDbContent.Remove(category);
                appDbContent.SaveChanges();
            }
            return category;
        }
    }
    
}
