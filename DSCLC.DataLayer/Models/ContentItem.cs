using System;
using System.Collections.Generic;
using System.Text;
using DSCLC.CommonModels;

namespace DSCLC.DataLayer
{
    public partial class ContentItem : IModelValidate
    {
        public int ContentItemId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int ContentListId { get; set; }
        public int CategoryId { get; set; }
        public ValidateResult Validate()
        {
            throw new NotImplementedException();
        }
    }
}
