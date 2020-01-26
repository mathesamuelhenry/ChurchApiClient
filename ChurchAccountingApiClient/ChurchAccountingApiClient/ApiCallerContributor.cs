using ChurchLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChurchAccountingApiClient
{
    public class ApiCallerContributor : ApiCallerBase
    {
        public ApiCallerContributor(string uri) :
            base(uri)
        {
        }

        public List<Contributor> GetContributors()
        {
            string url = $"api/Contributor";
            
            var contributorList = ApiHelper.CallGetWebApi<List<Contributor>>(url);

            return contributorList;
        }

        public Contributor GetContributorById(int id = 0)
        {
            if (id == default(int))
            {
                throw new Exception("Please pass a valid id");
            }

            string url = $"api/Contributor/{id}";

            var contributor = ApiHelper.CallGetWebApi<Contributor>(url);

            return contributor;
        }

        public List<string> GetAllFullNames()
        {
            string url = $"api/Contributor/GetFullNames";

            var contributorList = ApiHelper.CallGetWebApi<List<string>>(url);

            return contributorList;
        }

        public void AddContributor(Contributor contributor)
        {
            string url = $"api/Contributor";
            
            ApiHelper.CallPostWebApi(url, contributor);
        }

        public void UpdateContributor(Contributor contributor)
        {
            string url = $"api/Contributor/{contributor.Id}";

            var ctbr = ApiHelper.CallPutWebApi(url, contributor);
        }
    }
}
