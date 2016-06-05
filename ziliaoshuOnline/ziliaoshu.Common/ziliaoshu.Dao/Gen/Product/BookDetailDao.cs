using Entity;
using ZiLiaoShu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ziliaoshu.IDao;
using MySql.Data.MySqlClient;
using ziliaoshu.Common;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Reflection;

namespace ziliaoshu.Dao
{
    public partial class BookDetailDao :  IBookDetailDao
    {
        //public static ziliaoshudbEntities entity = new ziliaoshudbEntities();
        //public List<BookDetail> Query()
        //{ 
        //    ziliaoshudbEntities entity1 = new ziliaoshudbEntities();
        //    var data = entity1.bookdetail
        //   return

        //}
        /// <summary>
        /// 获取所有的书单
        /// </summary>
        /// <returns></returns>
        public List<BookDetail> GetAll()
        {
            string sbSql = "select * from bookdetail";
            List<BookDetail> bookDetailList = new List<BookDetail>();
            using(MySqlConnection con = new MySqlConnection(ConfigString.configString))
            { 
           // MySqlParameter[] para = {new MySqlParameter()};
                con.Open();
                MySqlCommand command = new MySqlCommand(sbSql, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                        BookDetail entity = new BookDetail();
                        entity.BookName = reader["BookName"].ToString();
                        entity.FileSize = reader["FileSize"].ToInt32();
                        entity.Author = reader["Author"].ToString();
                        entity.SecAuthor = reader["SecAuthor"].ToString();
                        entity.Press = reader["Press"].ToString();
                        entity.DataChange_CreateTime = reader["DataChange_CreateTime"].ToString().ToDateTime();
                        entity.DataChange_CreateUser = reader["DataChange_CreateUser"].ToString();
                        entity.DataChange_LastTime = reader["DataChange_LastTime"].ToString().ToDateTime();
                        entity.DataChange_LastUser = reader["DataChange_LastUser"].ToString();
                        entity.Type = byte.Parse(reader["Type"].ToString());
                        entity.Status = byte.Parse(reader["Status"].ToString());
                        entity.IsActive = byte.Parse(reader["IsActive"].ToString());
                        entity.icon = reader["icon"].ToString();
                        entity.Adress = reader["Adress"].ToString();
                        entity.Detail = reader["Detail"].ToString();
                        bookDetailList.Add(entity);
                }
            }
            return bookDetailList;
        }
        /// <summary>
        /// 获取所有的书单
        /// </summary>
        /// <returns></returns>
        public List<BookDetail> GetAllByIcon()
        {
            string sbSql = "select * from bookdetail where icon is not null";
            List<BookDetail> bookDetailList = new List<BookDetail>();
            using (MySqlConnection con = new MySqlConnection(ConfigString.configString))
            {
                // MySqlParameter[] para = {new MySqlParameter()};
                con.Open();
                MySqlCommand command = new MySqlCommand(sbSql, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookDetail entity = new BookDetail();
                    entity.BookName = reader["BookName"].ToString();
                    entity.FileSize = reader["FileSize"].ToInt32();
                    entity.Author = reader["Author"].ToString();
                    entity.SecAuthor = reader["SecAuthor"].ToString();
                    entity.Press = reader["Press"].ToString();
                    entity.DataChange_CreateTime = reader["DataChange_CreateTime"].ToString().ToDateTime();
                    entity.DataChange_CreateUser = reader["DataChange_CreateUser"].ToString();
                    entity.DataChange_LastTime = reader["DataChange_LastTime"].ToString().ToDateTime();
                    entity.DataChange_LastUser = reader["DataChange_LastUser"].ToString();
                    entity.Type = byte.Parse(reader["Type"].ToString());
                    entity.Status = byte.Parse(reader["Status"].ToString());
                    entity.IsActive = byte.Parse(reader["IsActive"].ToString());
                    entity.icon = reader["icon"].ToString();
                    entity.Adress = reader["Adress"].ToString();
                    entity.Detail = reader["Detail"].ToString();
                    bookDetailList.Add(entity);
                }
            }
            return bookDetailList;
        }
        public int Insert(BookDetail bookDetail)
        {
            string sqlstr = @" INSERT INTO BookDetail(BookName,FileSize, Author, SecAuthor, Press, Type, Status, IsActive, icon, Adress,Detail, DataChange_CreateUser,DataChange_CreateTime, DataChange_LastUser, DataChange_LastTime)
                              VALUES(?BookName,?FileSize,?Author,?SecAuthor,?Press,IFNULL(?Type,0), IFNULL(?Status,0), IFNULL(?IsActive,0),?icon, ?Adress,?Detail,?DataChange_CreateUser,IFNULL(?DataChange_CreateTime,now()),?DataChange_LastUser,IFNULL(?DataChange_LastTime,now()))";
            try
            {
                using(MySqlConnection con = new MySqlConnection(ConfigString.configString))
                {
                    con.Open();
                    MySqlCommand comm = new MySqlCommand(sqlstr, con);
                    //comm.Parameters.Add(new MySqlParameter( "?BookId", DbType.Int64 ));
                    Type bookType = typeof(BookDetail);
                   // var fields = bookType.GetFields();
                    var member = bookType.GetMembers();
                   // var member1 = bookType.GetMethods();
                    //var member2 = bookType.GetProperties();
                   // var _bookDetail = bookDetail.AsEnumerable();
                    for(int item=0;item< member.Length;item++)
                    {
                        if(member[item].MemberType== MemberTypes.Property)
                        {
                            var propertys = bookDetail.GetType().GetProperty(member[item].Name);
                           
                            var val = propertys.GetValue(bookDetail,null);

                            comm.Parameters.Add(new MySqlParameter("?" + member[item].Name, val));
                        }
                    }
                    return comm.ExecuteNonQuery();
                }
                
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("调用spA_M_Product_i时，访问Insert时出错", ex);
            }
        }


    }
}
