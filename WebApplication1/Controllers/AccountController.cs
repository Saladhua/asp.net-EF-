using APIDemo.info.BLL;
using APIDemo.info.Model;
using APIModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 登录账户信息
    /// </summary>
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly AccountInfoAdapter accountInfoAdapter;

        public AccountController()
        {
            accountInfoAdapter = new AccountInfoAdapter();
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="accountSaveRequest"></param>
        /// <returns></returns>
        [HttpPost, Route("SaveAccount")]
        public ApiResult SaveAccount([FromBody] AccountSaveRequest accountSaveRequest)
        {
            ApiResult apiResult = new ApiResult();
            if (accountSaveRequest != null)
            {
                var model = accountInfoAdapter.GetByID(accountSaveRequest.ID);
                if (model == null)
                {
                    model = new AccountInfo();
                    model.CreatedBy = "";
                }
                else
                {
                    model.ModifyTime = DateTime.Now;
                }
                model.LoginID = accountSaveRequest.LoginID;
                model.PassWord = accountSaveRequest.PassWord;
                model.UserTrueName = accountSaveRequest.UserTrueName;
                model.MobileNumber = accountSaveRequest.MobileNumber;
                model.DepartmentName = accountSaveRequest.DepartmentName;
                model.RoleName = accountSaveRequest.RoleName;
                if (accountInfoAdapter.Save(model))
                {
                    apiResult.success = true;
                    apiResult.message = "保存成功";
                }
            }
            else
            {
                apiResult.success = false;
                apiResult.message = "参数错误";
            }
            return apiResult;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetAccountList")]
        public ApiResult<List<AccountInfo>> GetAccountList()
        {
            ApiResult<List<AccountInfo>> apiResult = new ApiResult<List<AccountInfo>>();
            var list = accountInfoAdapter.GetListByWhere(new Hashtable());
            apiResult.data = list;
            return apiResult;
        }
    }
}