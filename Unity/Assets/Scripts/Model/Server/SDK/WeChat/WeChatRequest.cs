namespace ET.Server
{
    public class WeChatSecCheckRequest
    {
        /// <summary>
        /// 用户的openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 场景枚举值: 1资料;2评论;3论坛;4社交日志;5聊天;
        /// </summary>
        public int scene { get; set; }

        /// <summary>
        /// 接口版本号，固定值2
        /// </summary>
        public int version { get; set; }

        /// <summary>
        /// 需检测的文本内容，文本字数的上限为2500字，需使用UTF-8编码
        /// </summary>
        public string content { get; set; }
    }

    public class UrlLinkRequest
    {
        /// <summary>
        /// 通过 URL Link 进入的小程序页面路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 通过 URL Link 进入小程序时的query，最大1024个字符
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// 要打开的小程序版本。"release", "trial", "develop"
        /// </summary>
        public string EnvVersion { get; set; } = "release";

        /// <summary>
        /// 小程序 URL Link 失效类型，失效时间：0，失效间隔天数：1
        /// </summary>
        public int ExpireType { get; set; }

        /// <summary>
        /// 到期失效的 URL Link 的失效时间，为 Unix 时间戳。生成的到期失效 URL Link 在该时间前有效。
        /// </summary>
        public long? ExpireTime { get; set; }

        /// <summary>
        /// 到期失效的URL Link的失效间隔天数。生成的到期失效URL Link在该间隔时间到达前有效。
        /// </summary>
        public int? ExpireInterval { get; set; }

        /// <summary>
        /// 云开发静态网站自定义 H5 配置参数
        /// </summary>
        public CloudBaseConfig CloudBase { get; set; }
    }

    public class CloudBaseConfig
    {
        /// <summary>
        /// 云开发环境
        /// </summary>
        public string Env { get; set; }

        /// <summary>
        /// 静态网站自定义域名，不填则使用默认域名
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 云开发静态网站 H5 页面路径，不可携带 query
        /// </summary>
        public string Path { get; set; } = "/";

        /// <summary>
        /// 云开发静态网站 H5 页面 query 参数，最大 1024 个字符
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// 第三方批量代云开发时必填，表示创建该 env 的 appid
        /// </summary>
        public string ResourceAppId { get; set; }
    }
}
