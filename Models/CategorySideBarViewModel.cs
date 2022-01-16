using ECommerce.Data.Repositories;
using ECommerce.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CategorySideBarViewModel
    {
        private static readonly CategoryRepository catRepo = new CategoryRepository();
        private static readonly SubCategoryRepository subCatRepo = new SubCategoryRepository();

        public List<CategoryItem> Items { get; set; }

        public CategorySideBarViewModel()
        {
            Items = new List<CategoryItem>();
            foreach (var c in catRepo.ReadAll(x => x.Active & !x.Deleted))
            {
                CategoryItem item = new CategoryItem();
                item.Category = c.Title;
                Dictionary<string, string> list = new Dictionary<string, string>();
                foreach (var s in subCatRepo.ReadAll(x => x.Active & !x.Deleted))
                {
                    list[s.Title] = StringWorkers.toSeoUrl(s.Title);
                }
                item.SubCategories = list;
                Items.Add(item);
            }
        }
    }

    public class CategoryItem
    {
        public string Category { get; set; }
        public Dictionary<string, string> SubCategories { get; set; }
    }
}
