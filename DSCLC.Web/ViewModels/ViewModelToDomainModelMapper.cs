using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSCLC.DataLayer;

namespace DSCLC.Web.ViewModels
{
    public class ViewModelToDomainModelMapper
    {
        public ContentItem MapToModel(AddNewItemViewModel newItem)
        {
            return new ContentItem()
            {
                Value = Convert.ToDecimal(newItem.itemValue),
                Name = newItem.itemName,
                CategoryName = newItem.itemCategory
            };
        }    
    
    }


}
