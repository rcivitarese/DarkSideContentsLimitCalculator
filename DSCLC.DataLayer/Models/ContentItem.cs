﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DSCLC.DataLayer
{
    public class ContentItem
    {
        public int ContentItemId { get; set; }
        public string Name { get; set; }
        public Decimal Value { get; set; }
        public string CategoryName { get; set; }
    }
}
