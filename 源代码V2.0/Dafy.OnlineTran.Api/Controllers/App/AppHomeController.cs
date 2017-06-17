using Dafy.OnlineTran.Common.Helpers;
using Dafy.OnlineTran.Common.Request;
using Dafy.OnlineTran.Common.Request.App;
using Dafy.OnlineTran.Common.Response;
using Dafy.OnlineTran.Common.Response.App;
using Dafy.OnlineTran.IService.App;
using QRCoder;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Dafy.OnlineTran.Api.Controllers.App
{
    public class AppHomeController: AuthController
    {
        IHomeService _homeService;
        private readonly string _wxState = ConfigurationManager.AppSettings["WXState"];
        private readonly string _appId = ConfigurationManager.AppSettings["WXAppID"];
        private readonly string _appSecret = ConfigurationManager.AppSettings["WXAppSecret"];
        private readonly string _httpUrl = ConfigurationManager.AppSettings["HttpUrl"];
        private string _shareUrl= ConfigurationManager.AppSettings["ShareUrl"];
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("AppHomeController");
        public AppHomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetUserQrCode()
        {
            using (var ms = new MemoryStream())
            using (var bitmap =GetQrCode())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                ms.Seek(0, SeekOrigin.Begin);

                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.ToArray())
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                return resp;
            }
        }
        private Bitmap GetQrCode()
        {
            var userIdStr = string.IsNullOrEmpty(this.User.Identity.Name) ? DESEncrypt.Encrypt("0") : DESEncrypt.Encrypt(this.User.Identity.Name);
            _shareUrl = string.Format(@_shareUrl, userIdStr).Replace("&amp;", "&");

            using (var qrGen = new QRCodeGenerator())
            using (var qrData = qrGen.CreateQrCode(_shareUrl, QRCodeGenerator.ECCLevel.Q))
            using (var qrCode = new QRCode(qrData))
            {
                return qrCode.GetGraphic(20);
            }
        }
        /// <summary>
        ///  获取分享地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<string> GetShareUrl()
        {
            var userIdStr =string.IsNullOrEmpty(this.User.Identity.Name)?DESEncrypt.Encrypt("0"): DESEncrypt.Encrypt(this.User.Identity.Name);
            var result = new ResultModel<string>
            {
                state =1,
                data = "",
                message = ""
            };
            _shareUrl = string.Format(@_shareUrl, userIdStr).Replace("&amp;", "&");
            result.data = _shareUrl;
            return result;
        }
        /// <summary>
        /// 微信认证
        /// </summary>
        /// <param name="rq"></param>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<AppOAuthRS> OAuth(AppOAuthRQ rq)
        {
            var result = new ResultModel<AppOAuthRS>
            {
                state=0,
                data=null,
                message="认证失败!"
            };

            var appOAuthRS = new AppOAuthRS();


            if (string.IsNullOrEmpty(rq.code))
            {
                result.message = "您拒绝了授权！";
                result.state = 0;
                return result;
            }
            if (string.IsNullOrEmpty(rq.state))
            {
                result.message = "验证失败！请从正规途径进入！";
                result.state = 0;
                return result;
            }

            try
            {

                rq.state = DESEncrypt.Decrypt(rq.state);
                var pId = 0;
                int.TryParse(rq.state, out pId);

                var oAuthResult = OAuthApi.GetAccessToken(_appId, _appSecret, rq.code);

                if (oAuthResult.errcode != ReturnCode.请求成功)
                {
                    result.message = "错误：" + oAuthResult.errmsg;
                    result.state = 0;
                    return result;
                }
                AccessTokenResult tokenResult = CommonApi.GetToken(_appId, _appSecret);
                var userInfo = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Info(tokenResult.access_token, oAuthResult.openid);
                //OAuthUserInfo userInfo = OAuthApi.GetUserInfo(oAuthResult.access_token, oAuthResult.openid);
                if (userInfo != null)
                {
                    var model = new WeixinUserItemRS();
                    model.pId = pId;
                    model.RoleId = 0;
                    model.Headimgurl = userInfo.headimgurl;
                    model.Nickname = userInfo.nickname;
                    model.OpenId = userInfo.openid;

                    var user = _homeService.InsertUser(model);
                    if (user != null)
                    {
                        var accessToken = DesCryptoUtil.Encrypt(user.Id.ToString());
                        appOAuthRS.accessToken = accessToken;
                        appOAuthRS.roleId = user.RoleId;
                        appOAuthRS.headImg = userInfo.headimgurl;
                        appOAuthRS.name = userInfo.nickname;
                        appOAuthRS.accessToken = accessToken;
                        appOAuthRS.uId = user.Id;
                        if (userInfo.subscribe == 0)
                        {
                            appOAuthRS.isFollow = 0;
                        }
                        else
                        {
                            userInfo.subscribe = 1;
                        }

                        result.state = 1;
                        result.message = "认证成功!";
                        result.data = appOAuthRS;
                    }
                    else
                    {
                        result.state = 0;
                        result.message = "认证失败!";
                        result.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                result.message = "认证出现异常,请稍后在试!";
                result.state = 0;
            }
            return result;
        }
        /// <summary>
        /// JS端获取微信签名
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ResultModel<JsSdkSignRS> GetJsSdkSign(GetJsSdkSignRQ rq)
        {
            var resultModel = new ResultModel<JsSdkSignRS>()
            {
                state = 0,
                message = "",
                data = null
            };
            try
            {
                var url = HttpUtility.UrlDecode(rq.url);
                var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(_appId, _appSecret,url);

                if (jssdkUiPackage != null)
                {
                    JsSdkSignRS rs = new JsSdkSignRS();
                    rs.nonceStr = jssdkUiPackage.NonceStr;
                    rs.signature = jssdkUiPackage.Signature;
                    rs.timestamp = jssdkUiPackage.Timestamp;

                    resultModel.state = 1;
                    resultModel.message = "微信JS-SDK签名成功!";
                    resultModel.data = rs;
                }
                else
                {
                    resultModel.message = "微信JS-SDK签名失败!";
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                resultModel.state = 0;
                resultModel.message = "微信JS-SDK签名出现异常!"+ex.Message;
                resultModel.data = null;
                return resultModel;
            }
        }
        /// <summary>
        /// 理财知识
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<KnowledgeRS> GetKnowledges(AppKnowledgeRQ rq)
        {
            return _homeService.GetKnowledges(rq);
        }
        /// <summary>
        /// 行业资讯
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<InformationRS> GetInformations(AppInformationRQ rq)
        {
            return _homeService.GetInformations(rq);
        }
        /// <summary>
        /// 获取Banner
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<GetBannersRS> GetBanners(GetBannersRQ rq)
        {
            return _homeService.GetBanners(rq);
        }
        /// <summary>
        /// 获取热点产品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<List<ProductsItemRS>> GetHotProduct()
        {
            return _homeService.GetHotProduct();
        }
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel<ProductsRS> GetProducts(AppProductsRQ rq)
        {
            return _homeService.GetProducts(rq);
        }
    }
}