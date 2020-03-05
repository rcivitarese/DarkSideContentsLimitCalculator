using System;
using System.Collections.Generic;
using System.Text;
using DSCLC.DataLayer;

namespace DSCLC.DataLayer
{
    public interface IRenterContentService
    {
        List<ContentItem> GetAllContentItems();

        public List<string> GetCategoryList();

        void DeleteItem(int itemId);

        void AddItem(ContentItem contentItem);
    }
}
