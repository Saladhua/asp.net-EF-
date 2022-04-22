using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace APIDemo.info.Model
{
    /// <summary>
    /// api返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 数据记录总条数 分页查询时获取
        /// </summary>
        public int totalcount { get; set; }

        /// <summary>
        /// 返回结果（true;false）
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 结果代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息代码
        /// </summary>
        public string msgcode { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        public ApiResult()
        {
            success = true;
            code = 200;
        }
    }

    /// <summary>
    /// api返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult
    {
        /// <summary>
        /// 返回结果（true;false）
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 结果代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息代码
        /// </summary>
        public string msgcode { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        public ApiResult()
        {
            success = true;
            code = 200;
        }
    }
}
