using GatewayTether.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Apis
{
    public abstract class BaseApi
    {
        protected const string tronUrl = "https://apilist.tronscan.org/api/";
        protected async Task<HttpResponseMessage> Get(string url)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                return await client.GetAsync(url);
            }
        }
        protected async Task<HttpResponseMessage> Post(string url, string parameters)
        {
            using (var client = new HttpClient())
            {
                var data = new StringContent(parameters, Encoding.UTF8, "application/json");
                return await client.PostAsync(url, data);
            }
        }
    }
}
