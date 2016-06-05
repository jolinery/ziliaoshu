using ZiLiaoShu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ziliaoshu.IDao;

namespace ziliaoshu.IDao
{
    //详细书
    public partial interface IBookDetailDao : IBaseDAO<BookDetail>
    {
         ///<summary>
         ///获取全部书单 
         ///</summary>
         ///<returns></returns>
         List<BookDetail> GetAll();
                /// <summary>
        /// 获取所有的书单
        /// </summary>
        /// <returns></returns>
         List<BookDetail> GetAllByIcon();
    }
}
