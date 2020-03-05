using System;
using System.Collections.Generic;
using System.Text;
using DSCLC.CommonModels;

namespace DSCLC.DataLayer
{
    public partial class RenterContents : IModelValidate
    {
        public string CategoryName { get; set; }

        public List<ContentItem> ContentItemList;

        //public int ContentItemId { get; set; }
        //public string Name { get; set; }
        //public Decimal Value { get; set; }
        public ValidateResult Validate()
        {
            throw new NotImplementedException();
        }
    }
}
