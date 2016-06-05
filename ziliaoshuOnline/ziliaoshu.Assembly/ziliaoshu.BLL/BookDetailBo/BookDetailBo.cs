using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ziliaoshu.IDao;
using ziliaoshu.Dao;
using ZiLiaoShu.Entity;
using ziliaoshu.Common;

namespace ziliaoshu.BLL
{
    public partial class BookDetailBo
    {
        IBookDetailDao dao = _DALFactory.BookDetailDao;
        public List<BookDetail> GetAll()
        {
            return dao.GetAll();
        }
        public BookDetailDVO GetBookSearchIndex(string searchKey = null)
        {
            BookDetailDVO list = GetBookSearchAll(searchKey);
            if (list != null && list.List != null && list.List.Any())
                return list;
        }
        public BookDetailDVO GetBookSearchAll(string searchKey =null)
        {
            BookDetailDVO List = new BookDetailDVO() {  searchKey = searchKey};
            List.List = GetAll();
            return List;
        }
        public bool AddBookBo(BookDetail bookDetail)
        {
            bookDetail.DataChange_CreateTime = DateTime.Now;
            bookDetail.DataChange_CreateUser = "joy";
            bookDetail.DataChange_LastTime = DateTime.Now;
            bookDetail.DataChange_LastUser = "joy";
            return dao.Insert(bookDetail)<=0;
        }



    }
}
