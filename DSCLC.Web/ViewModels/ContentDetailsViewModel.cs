using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCLC.Web.ViewModels
{
    public class ContentDetailsViewModel
    {
        public int ContentItemId { get; set; }
        public string Name { get; set; }
        public Decimal Value { get; set; }
        public string CategoryName { get; set; }
    }
}
