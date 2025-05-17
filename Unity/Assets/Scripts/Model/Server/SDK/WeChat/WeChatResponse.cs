using System.Collections.Generic;

namespace ET.Server
{
    public class AccessTokenResponse
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒。目前是7200秒之内的值。
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 错误码
        /// -1	系统繁忙，此时请开发者稍候再试	
        /// 0	请求成功	
        /// 40001	AppSecret 错误或者 AppSecret 不属于这个小程序，请开发者确认 AppSecret 的正确性	
        /// 40002	请确保 grant_type 字段值为 client_credential	
        /// 40013	不合法的 AppID，请开发者检查 AppID 的正确性，避免异常字符，注意大小写
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
    }

    public class WeChatSessionResponse
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 会话密钥
        /// </summary>
        public string SessionKey { get; set; }

        /// <summary>
        /// 用户在开放平台的唯一标识符
        /// 若当前小程序已绑定到微信开放平台账号下会返回
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 错误码
        /// -1	系统繁忙，此时请开发者稍候再试	
        /// 0	请求成功	
        /// 40029	code 无效	
        /// 45011	频率限制，每个用户每分钟100次	
        /// 40226	高风险等级用户，小程序登录拦截 。风险等级详见用户安全解方案
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
    }

    public class ResponseData
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 唯一请求标识，标记单次请求
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 综合结果
        /// </summary>
        public ResultData Result { get; set; }
    }

    public class ResultData
    {
        /// <summary>
        /// 有risky(拦截)、pass(通过)、review(可疑)三种值
        /// </summary>
        public string Suggest { get; set; }

        /// <summary>
        /// 命中标签枚举值
        /// 100: 正常;
        /// 10001: 营销广告;
        /// 20001: 时政;
        /// 20002: 色情;
        /// 20003: 辱骂;
        /// 20006: 违法犯罪;
        /// 20012: 低俗;
        /// 21000: 其他
        /// </summary>
        public int Label { get; set; }

        /// <summary>
        /// 将关键词替换成 `*` 之后得到文本，如果未命中关键词而是命中模型则全文替换成 `*`，通过则为原文
        /// </summary>
        public string ReplacedContent { get; set; }

        /// <summary>
        /// 详细检测结果
        /// </summary>
        public List<DetailData> Detail { get; set; }
    }

    public class DetailData
    {
        /// <summary>
        /// 策略类型
        /// </summary>
        public string Strategy { get; set; }

        /// <summary>
        /// 错误码，仅当该值为0时，该项结果有效
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 有risky(拦截)、pass(通过)、review(可疑)三种值
        /// </summary>
        public string Suggest { get; set; }

        /// <summary>
        /// 命中标签枚举值
        /// 100: 正常;
        /// 10001: 营销广告;
        /// 20001: 时政;
        /// 20002: 色情;
        /// 20003: 辱骂;
        /// 20006: 违法犯罪;
        /// 20012: 低俗;
        /// 21000: 其他
        /// </summary>
        public int Label { get; set; }

        /// <summary>
        /// 命中的自定义关键词
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 0-100，代表置信度，越高代表越有可能属于当前返回的标签（label）
        /// </summary>
        public int Prob { get; set; }
    }

    public class UrlLinkResponse
    {
        /// <summary>
        /// 生成的小程序 URL Link
        /// </summary>
        public string UrlLink { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
    }
}