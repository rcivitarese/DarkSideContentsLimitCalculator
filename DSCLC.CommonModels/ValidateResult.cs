using System;
using System.Collections.Generic;
using System.Text;

namespace DSCLC.CommonModels
{
    public class ValidateResult
    {
        public virtual bool Success { get { return (_errorList.Count == 0); } }
        protected List<ValidationError> _errorList = new List<ValidationError>();
    }
}
