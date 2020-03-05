using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSCLC.DataLayer;

namespace DSCLC.DataLayer
{
    public class DSCLCDataAccessLayer
    {

        public IEnumerable<RenterContents> GetRenterContents(int renterContentsId)
        {
            try
            {
                return null;
            }
            catch
            {
                throw;
            }

        }

        DSCLCDBContext _db = new DSCLCDBContext();
    }
}
