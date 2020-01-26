using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchAccountingApiClient
{
    public class ApiCallerBase
    {
        public ApiCallerBase(string uri)
        {
            ApiHelper.InitializeClient(uri);
        }
    }
}
