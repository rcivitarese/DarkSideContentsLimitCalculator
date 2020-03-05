using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCLC.Web.ViewModels
{
    public class CategoryContentsViewModel
    {
        public CategoryContentsViewModel()
        {

        }

        public CategoryContentsViewModel(int size)
        {
            Contents = new ContentDetailsViewModel[size];
        }
        public string CategoryName { get; set; }

        public decimal TotalValue { get; set; }

        public ContentDetailsViewModel[] Contents { get; set; }
    }
}
