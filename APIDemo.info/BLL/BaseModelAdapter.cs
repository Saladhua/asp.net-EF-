using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using APIModel;
using APIDemo.info.Context;

namespace APIDemo.info.BLL
{
    /// <summary>
    /// 基本BLL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseModelAdapter<T> where T : BaseModel
    {
        protected APIDbContext apiDbContext;

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            try
            {
                apiDbContext.Entry<T>(entity).State = EntityState.Added;
                int rowsAffected = apiDbContext.SaveChanges();
                return (rowsAffected > 0) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            try
            {
                apiDbContext.Set<T>().Attach(entity);
                apiDbContext.Entry<T>(entity).State = EntityState.Modified;
                int rowsAffected = apiDbContext.SaveChanges();
                return (rowsAffected > 0) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id, bool IsDelete = false)
        {
            var model = GetByID(id);
            if (model != null)
            {
                try
                {
                    apiDbContext.Set<T>().Attach(model);
                    if (IsDelete)
                    {
                        apiDbContext.Entry<T>(model).State = EntityState.Deleted;
                    }
                    else
                    {
                        model.IsDelete = true;
                        apiDbContext.Entry<T>(model).State = EntityState.Modified;
                    }
                    int rowsAffected = apiDbContext.SaveChanges();
                    return (rowsAffected > 0) ? true : false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByID(Guid id)
        {
            try
            {
                Expression<Func<T, bool>> whereLambda = x => x.ID.Equals(id);
                var modelList = apiDbContext.Set<T>().Where<T>(whereLambda).AsQueryable().ToList();
                return (modelList.Any()) ? modelList.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public List<T> GetListByWhere(Expression<Func<T, bool>> whereLambda)
        {
            try
            {
                var list = apiDbContext.Set<T>().Where<T>(whereLambda).OrderByDescending(x => x.CreateTime).AsQueryable().ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<T> GetPageListByWhere(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount)
        {
            try
            {
                int skipCount = (pageIndex - 1) * pageSize;
                totalCount = apiDbContext.Set<T>().Where<T>(whereLambda).Count();
                var list = apiDbContext.Set<T>().Where<T>(whereLambda).OrderByDescending(x => x.CreateTime).Skip(skipCount).Take(pageSize).AsQueryable().ToList();
                return list;
            }
            catch (Exception ex)
            {
                totalCount = 0;
                return null;
            }
        }
    }
}
