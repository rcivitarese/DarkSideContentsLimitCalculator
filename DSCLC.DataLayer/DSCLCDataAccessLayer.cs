using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DSCLC.DataLayer;

namespace DSCLC.DataLayer
{
    public class DSCLCDataAccessLayer
    {

        public IEnumerable<ContentList> GetRenterContents(int renterContentsId)
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

        DSCLCDBContext _dbContext;

    }
}
