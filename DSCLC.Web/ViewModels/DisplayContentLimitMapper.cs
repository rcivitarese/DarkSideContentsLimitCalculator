using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSCLC.DataLayer;

namespace DSCLC.Web.ViewModels
{
    public class DisplayContentLimitMapper
    {
        public DisplayContentLimitViewModel MapToModel(List<ContentItem> contents, List<string> categoryList)
        {
            IEnumerable<string> categories = contents.Select(c => c.CategoryName).Distinct();

            int numberOfCategories = categories.Count() + 1;  // number of distinct categories for this content list
                                                              // add one more to accomodate for the 'Total'

            DisplayContentLimitViewModel model = new DisplayContentLimitViewModel(numberOfCategories, categoryList.Count());

            int index = 0;
            decimal totalContentValue = 0.0m;

            foreach (var category in categories)
            {
                IEnumerable<ContentItem> domainContentItemList = contents.Where(c => c.CategoryName == category);
                List<ContentDetailsViewModel> contentDetailsViewList = new List<ContentDetailsViewModel>();
                decimal categoryValue = 0.0m;

                foreach (var item in domainContentItemList)
                {
                    contentDetailsViewList.Add(new ContentDetailsViewModel()
                    {
                        ContentItemId = item.ContentItemId,
                        Name = item.Name,
                        Value = item.Value,
                        CategoryName = item.CategoryName
                    }
                    );
                    categoryValue += item.Value;
                }

                model.ContentsList[index] = new CategoryContentsViewModel()
                {
                    CategoryName = category,
                    TotalValue = categoryValue,
                    Contents = contentDetailsViewList.ToArray()
                };

                index++;
                totalContentValue += categoryValue;
            }

            model.ContentsList[index] = new CategoryContentsViewModel()
            {
                CategoryName = "Total",
                TotalValue = totalContentValue,
                Contents = null
            };

            index = 0;
            foreach (string category in categoryList)
            {
                model.CategoryList[index] = new CategoryViewModel
                {
                    CategoryId = index,
                    CategoryName = category
                };
                index++;
            }

            return model;
        }
    }
}
