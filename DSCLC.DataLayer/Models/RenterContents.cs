using System;
using System.Collections.Generic;
using System.Text;
using DSCLC.CommonModels;


namespace DSCLC.DataLayer
{
    public class RenterContents : IModelValidate
    {
        public int ContentListId { get; set; }
        public string Name { get; set; }

        public ValidateResult Validate()
        {
            throw new NotImplementedException();
        }
    }
}
