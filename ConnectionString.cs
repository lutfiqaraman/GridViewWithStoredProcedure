using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CRUDWithSPDataGrid
{
    public static class ConnectionString
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString;
        }
    }
}