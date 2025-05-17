using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ET.Server
{
    public static partial class HttpHelper
    {
        public static void Response(HttpListenerContext context, object response)
        {
            byte[] bytes = MongoHelper.ToJson(response).ToUtf8();
            context.Response.StatusCode = 200;
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.ContentLength64 = bytes.Length;
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }

        public static async Task<string> Get(string link)
        {
            try
            {
                using HttpClient httpClient = new();
                HttpResponseMessage response = await httpClient.GetAsync(link);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"http request fail: {link.Substring(0, link.IndexOf('?'))}\n{e}");
            }
        }

        public static async Task<string> Post(string link, string jsonContent = null)
        {
            // 使用HttpClient进行POST请求
            using var client = new HttpClient();
            try
            {
                // 如果提供了内容，将其作为POST请求的正文
                HttpContent content = null;
                if (!string.IsNullOrEmpty(jsonContent))
                {
                    content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                // 发送POST请求
                HttpResponseMessage response = await client.PostAsync(link, content);

                // 确保请求成功
                response.EnsureSuccessStatusCode();

                // 读取响应内容
                string responseBody = await response.Content.ReadAsStringAsync();

                // 返回响应内容
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                // 捕获请求异常并返回错误消息
                Console.WriteLine($"Request error: {e.Message}");
                return $"Error: {e.Message}";
            }
            catch (Exception e)
            {
                // 捕获其他异常并返回错误消息
                Console.WriteLine($"Unexpected error: {e.Message}");
                return $"Error: {e.Message}";
            }
        }
    }
}