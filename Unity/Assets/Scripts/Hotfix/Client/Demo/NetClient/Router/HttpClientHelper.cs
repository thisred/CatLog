using System;
using System.Net.Http;

namespace ET.Client
{
    public static partial class HttpClientHelper
    {
        public static async ETTask<string> Get(string link)
        {
            try
            {
                using HttpClient httpClient = new();
                var response =  await httpClient.GetAsync(link);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"http request fail: {link.Substring(0,link.IndexOf('?'))}\n{e}");
            }
        }
    }
}