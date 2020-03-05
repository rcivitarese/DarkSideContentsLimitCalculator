using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DSCLC.DataLayer;

namespace DSCLC.DataLayer
{
    public class RenterContentService : IRenterContentService
    {
        public RenterContentService(IServiceProvider serviceProvider)
        {
            _repository = new RenterContentRepository(serviceProvider);
        }

        public List<ContentItem> GetAllContentItems()
        {
            var listOfItems = _repository.GetAllContentItems();

            return listOfItems.ToList();
        }

        public List<string> GetCategoryList()
        {
            return _repository.GetCategoryList();
        }

        public void DeleteItem(int itemId)
        {
            _repository.DeleteItem(itemId);
        }

        public void AddItem(ContentItem contentItem)
        {
            _repository.AddItem(contentItem);
        }

        IRenterContentRepository _repository;
    }
}
