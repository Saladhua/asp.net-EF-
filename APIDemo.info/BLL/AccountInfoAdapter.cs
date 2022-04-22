using APIDemo.info.Context;
using APIModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.info.BLL
{
    public class AccountInfoAdapter : BaseModelAdapter<AccountInfo>
    {
        public AccountInfoAdapter()
        {
            apiDbContext = new APIDbContext();
        }

        public AccountInfoAdapter(APIDbContext aPIDbContext)
        {
            apiDbContext = aPIDbContext;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Save(AccountInfo item)
        {
            var model = GetByID(item.ID);
            if (model == null)
            {
                return Add(item);
            }
            else
            {
                return Update(item);
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<AccountInfo> GetListByWhere(Hashtable parameters)
        {
            Expression<Func<AccountInfo, bool>> whereSearch = x => x.IsDelete == false;
            if (parameters != null)
            {
                if (parameters["UserTrueName"] != null && !string.IsNullOrWhiteSpace(parameters["UserTrueName"].ToString()))
                {

                }
            }
            return GetListByWhere(whereSearch);
        }

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<AccountInfo> GetPageListByWhere(Hashtable parameters, int pageIndex, int pageSize, out int totalCount)
        {
            Expression<Func<AccountInfo, bool>> whereSearch = x => x.IsDelete == false;
            if (parameters != null)
            {
                if (parameters["UserTrueName"] != null && !string.IsNullOrWhiteSpace(parameters["UserTrueName"].ToString()))
                {

                }
            }
            return GetPageListByWhere(whereSearch, pageIndex, pageSize, out totalCount);
        }
    }
}
