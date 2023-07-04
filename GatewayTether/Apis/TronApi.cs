using GatewayTether.Models;
using GatewayTether.XmlDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GatewayTether.Apis
{
    public class TronApi : BaseApi
    {
        string url = "";
        TransferTronModel result;
        HttpResponseMessage response;
        public async Task<TransferTronModel> CallTransfer_Trc20(string walletAddress)
        {
            url = tronUrl + $"token_trc20/transfers?limit=20&start=0&sort=-timestamp&count=true&toAddress={walletAddress}&relatedAddress={walletAddress}";
            result = new TransferTronModel();
            try
            {
                response = await Get(url);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = Newtonsoft.Json.JsonConvert.DeserializeObject<TransferTronModel>(await response.Content.ReadAsStringAsync());
                        result.Result = true;
                        result.Message = "call success api transfer";
                    }
                    else
                    {
                        result.Result = false;
                        result.Message = "error in call api transfer walletAddress=" + walletAddress + " . response.IsSuccessStatusCode is false. error message: " + await response.Content.ReadAsStringAsync();
                    }
                }
                else
                {
                    result.Result = false;
                    result.Message = "error in call api transfer walletAddress=" + walletAddress + " . response is null";
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = "error in call api transfer walletAddress=" + walletAddress + ". exception message: " + ex.Message ?? "";
                WriteXmlDocument.AddException(MethodBase.GetCurrentMethod().DeclaringType.FullName, ex);
            }
            return result;
        }
    }
}
