using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ziliaoshu.Common;
using ziliaoshu.IDao;
using ZiLiaoShu.Entity;

namespace ziliaoshu.Dao
{
    public partial class FeedBackDao :IFeedBackDao
    {
        public int Insert(FeedBack FeedBack)
        {
            string sqlstr = @" INSERT INTO FeedBack(UserId,UserName, Content, DataChange_CreateUser,DataChange_CreateTime, DataChange_LastUser, DataChange_LastTime)
                              VALUES(?UserId,?UserName,?Content,?DataChange_CreateUser,IFNULL(?DataChange_CreateTime,now()),?DataChange_LastUser,IFNULL(?DataChange_LastTime,now()))";
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConfigString.configString))
                {
                    con.Open();
                    MySqlCommand comm = new MySqlCommand(sqlstr, con);
                    //comm.Parameters.Add(new MySqlParameter( "?BookId", DbType.Int64 ));
                    Type bookType = typeof(FeedBack);
                    // var fields = bookType.GetFields();
                    var member = bookType.GetMembers();
                    // var member1 = bookType.GetMethods();
                    //var member2 = bookType.GetProperties();
                    // var _bookDetail = bookDetail.AsEnumerable();
                    for (int item = 0; item < member.Length; item++)
                    {
                        if (member[item].MemberType == MemberTypes.Property)
                        {
                            var propertys = FeedBack.GetType().GetProperty(member[item].Name);

                            var val = propertys.GetValue(FeedBack, null);

                            comm.Parameters.Add(new MySqlParameter("?" + member[item].Name, val));
                        }
                    }
                    return comm.ExecuteNonQuery();
                }

            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("调用spA_M_FeedBack_i时，访问Insert时出错", ex);
            }
        }
    }
}
