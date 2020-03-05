using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using DSCLC.DataLayer;

namespace DSCLC.DataLayer
{
    public class RenterContentRepository : IRenterContentRepository
    {
        public RenterContentRepository(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetService<DSCLCDBContext>();
        }

        public List<ContentItem> GetAllContentItems()
        {
            var listOfItems = _dbContext.DbContentList.Select(row => row).OrderBy(row => row.CategoryName);

            return listOfItems.ToList();
        }

        public void DeleteItem(int itemId)
        {
            var item = _dbContext.DbContentList.Single(item => item.ContentItemId == itemId);
            if (item != null)
            {
                _dbContext.DbContentList.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public void AddItem(ContentItem contentItem)
        {
            _dbContext.Add(contentItem);
            _dbContext.SaveChanges();
        }

        public List<string> GetCategoryList()
        {
            List<string> categories = new List<string>()
            {
                "Electronics",
                "Kitchen",
                "Light Sabers",
                "Landspeeders",
                "Miscellaneous",
                "Droids"
            };

            return categories;
        }

        DSCLCDBContext _dbContext;
    }
}
