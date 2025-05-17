using System.Threading.Tasks;

namespace ET.Server
{
    public static class WeChatHelper
    {
        /// <summary>
        /// 获取通过Token
        /// https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/access-token/auth.getAccessToken.html
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static async Task<AccessTokenResponse> GetAccessToken(string code)
        {
            string appId = "";
            string secret = "";
            string respStr =
                    await HttpHelper.Get($"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appId}&secret={secret}");
            return JsonHelper.Deserialize<AccessTokenResponse>(respStr);
        }

        /// <summary>
        /// 获取微信登录信息
        /// https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/login/auth.code2Session.html
        /// </summary>
        /// <returns></returns>
        public static async Task<WeChatSessionResponse> GetWeChatSession(string code)
        {
            string appId = "";
            string secret = "";
            string jsCode = "";
            string respStr =
                    await HttpHelper.Get(
                        $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={jsCode}&grant_type=authorization_code");
            var weChatSessionResponse = JsonHelper.Deserialize<WeChatSessionResponse>(respStr);
            return weChatSessionResponse;
        }

        /// <summary>
        /// 文本内容安全识别
        /// https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/wxa-sec-check/gamesecurity.msgSecCheck.html
        /// </summary>
        /// <param name="openId">用户的openid</param>
        /// <param name="scene">场景枚举值: 1资料;2评论;3论坛;4社交日志;5聊天;</param>
        /// <param name="content">需检测的文本内容，文本字数的上限为2500字，需使用UTF-8编码</param>
        /// <returns></returns>
        public static async Task<ResponseData> GetWeChatMsgSecCheck(string openId, int scene, string content)
        {
            string accessToken = "";
            string url = $"https://api.weixin.qq.com/wxa/game/content_spam/msg_sec_check?access_token={accessToken}";
            var request = new WeChatSecCheckRequest();
            request.scene = scene;
            request.content = content;
            request.openid = openId;
            request.version = 2;
            string serialize = JsonHelper.Serialize(request);
            string post = await HttpHelper.Post(url, serialize);
            return JsonHelper.Deserialize<ResponseData>(post);
        }

        /// <summary>
        /// 获取小程序 URL Link，适用于短信、邮件、网页、微信内等拉起小程序的业务场景。
        /// </summary>
        public static async Task<UrlLinkResponse> GetUrllink()
        {
            string accessToken = "";
            string url = $"https://api.weixin.qq.com/wxa/generate_urllink?access_token={accessToken}";
            var request = new UrlLinkRequest() { };
            string serialize = JsonHelper.Serialize(request);
            string post = await HttpHelper.Post(url, serialize);
            return JsonHelper.Deserialize<UrlLinkResponse>(post);
        }
    }
}