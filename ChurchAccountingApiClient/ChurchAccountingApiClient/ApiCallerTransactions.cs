using ChurchLibrary.Model;
using ChurchLibrary.Model.Base.Request;
using ChurchLibrary.Model.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchAccountingApiClient
{
    public class ApiCallerTransactions : ApiCallerBase
    {
        public ApiCallerTransactions(string uri) : base(uri)
        {
            
        }

        public SearchBaseResponse<List<Transaction>> SearchTransactions(SearchLimiters searchLimiter)
        {
            string url = $"api/Transactions";

            var transactionsList = ApiHelper.CallPostSearchWebApi<SearchBaseResponse<List<Transaction>>>(url, searchLimiter);

            // var transactionsList = ApiHelper.CallPutWebApi<SearchLimiters>(url, searchLimiter);

            return transactionsList;
        }

        public Transaction GetTransaction(int id = 0)
        {
            string url = $"api/Transactions/{id}";

            var transaction = ApiHelper.CallGetWebApi<Transaction>(url);

            return transaction;
        }
    }
}
