using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ziliaoshu.IDao;
using ziliaoshu.Common;

namespace ziliaoshu.Dao
{
    public partial class _DALFactory
    {

              //public static readonly IBookDetailDao BookDetailDao = new BookDetailDao();
       // public static readonly string configStr = ConfigString.
        /// <summary>
        /// Property MMeetingRoomDecorateTagDao
        /// </summary>
        private static readonly IBookDetailDao bookDetailDao = new BookDetailDao();
        public static IBookDetailDao BookDetailDao
        {
            get
            {
                return bookDetailDao;
            }
        }
        private static readonly IFeedBackDao feedBackDao = new FeedBackDao();
        public static IFeedBackDao FeedBackDao
        {
            get
            {
                return feedBackDao;
            }
        }
    }
}
