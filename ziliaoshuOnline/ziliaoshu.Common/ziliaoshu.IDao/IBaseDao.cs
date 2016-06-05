using System;
using System.Collections.Generic;
namespace ziliaoshu.IDao
{
    /// <summary>
    /// 接口层Channel
    /// </summary>
    public partial interface IBaseDAO<T>
    {

        /// <summary>
        /// 插入一条数据
        /// </summary>
        int Insert(T model);

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //int Update(T model);

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //int Delete(T model);

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //int Delete(long ID);

        ///// <summary>
        ///// 根据主键获取ESNEvent信息
        ///// </summary>
        //T FindByPk(long pkID);

        ///// <summary>
        ///// 获取所有ESNEvent信息
        ///// </summary>
        ///// <returns>ESNEvent列表</returns>
        //IList<T> GetAll();

        ///// <summary>
        /////  批量插入
        ///// </summary>
        ///// <param name="eSNEvent">实体对象列表</param>
        ///// <returns>状态代码</returns>
        //int BulkInsert(IList<T> itemList);

        ///// <summary>
        /////  批量更新
        ///// </summary>
        ///// <param name="eSNEvent">实体对象列表</param>
        ///// <returns>状态代码</returns>
        //int BulkUpdate(IList<T> itemList);

        ///// <summary>
        /////  批量删除
        ///// </summary>
        ///// <param name="eSNEvent">实体对象列表</param>
        ///// <returns>状态代码</returns>
        //int BulkDelete(IList<T> itemList);

        ///// <summary>
        ///// 取得总记录数
        ///// </summary>
        ///// <returns>记录数</returns>
        //long Count();

        ///// <summary>
        /////  检索ESNEvent，带翻页
        ///// </summary>
        ///// <param name="obj">ESNEvent实体对象检索条件</param>
        ///// <param name="pagesize">每页记录数</param>
        ///// <param name="pageNo">页码</param>
        ///// <returns>检索结果</returns>
        //IList<T> GetListByPage(T obj, int pagesize, int pageNo);
    }
}

