using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSCLC.DataLayer;

namespace DSCLC.Web.ViewModels
{
    public class DisplayContentLimitViewModel
    {
        public DisplayContentLimitViewModel()
        {

        }

        public DisplayContentLimitViewModel(int contentCategories, int totalCategories)
        {
            ContentsList = new CategoryContentsViewModel[contentCategories];
            CategoryList = new CategoryViewModel[totalCategories];
        }

        public CategoryContentsViewModel[] ContentsList { get; set; }
        public CategoryViewModel[] CategoryList { get; set; }
    }
}
