using System;
using System.Collections.Generic;
using System.Text;
using DSCLC.DataLayer;

namespace DSCLC.DataLayer
{
    public interface IRenterContentRepository
    {
        List<RenterContents> GetRenterContentLists();
        RenterContents GetRenterContentsById(int RenterContentId);
    }
}
