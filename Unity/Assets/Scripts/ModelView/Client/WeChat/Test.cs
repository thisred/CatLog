using UnityEngine;
using WeChatWASM;

namespace ET.Hotfix.Client.FunsGame.WeChat
{
    public class Test
    {
        public void Test1()
        {
            var bannerAd = WX.CreateBannerAd(new WXCreateBannerAdParam()
            {
                adUnitId = "xxxx",
                adIntervals = 30,
                style = new Style()
                {
                    left = 0,
                    top = 0,
                    width = 600,
                    height = 200
                }
            });
            bannerAd.OnLoad(o=> {
                bannerAd.Show();
            });
            bannerAd.OnError((WXADErrorResponse res)=>
            {
                Debug.Log(res.errCode);
            });
            
            WX.OnShareMessageToFriend(result => {});
        }
    }
}