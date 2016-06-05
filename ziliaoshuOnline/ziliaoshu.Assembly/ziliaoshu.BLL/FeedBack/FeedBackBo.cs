using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ziliaoshu.Dao;
using ziliaoshu.IDao;
using ZiLiaoShu.Entity;

namespace ziliaoshu.BLL
{
    public partial class FeedBackBo
    {
        IFeedBackDao dao = _DALFactory.FeedBackDao;
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="bookDetail"></param>
        /// <returns></returns>
        public bool AddFeedBack(FeedBack FeedBack)
        {
            FeedBack.DataChange_CreateTime = DateTime.Now;
            FeedBack.DataChange_CreateUser = "sys";
            FeedBack.DataChange_LastTime = DateTime.Now;
            FeedBack.DataChange_LastUser = "sys";
            return dao.Insert(FeedBack) <= 0;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="bookDetail"></param>
        /// <returns></returns>
        public bool AddFeedBack(string content)
        {
            var feedBack = new FeedBack() {Content = content };
            return AddFeedBack(feedBack);
        }
    }
}
