using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ziliaoshuOffline
{
    public struct Class1
    {
        private string str;
         public string this[string a]
         {
             get { return str ;}
             set { str = a;}
             
         }


    }
    public class testclass
    {
        public void testmethod()
        {
            Class1 cla = new Class1();
            string aa = cla["dd"];
        }
        
       
    }
    public class testclass1
    {
        private string ss;

        public string Ss1
        {
            get { return ss; }
            set { ss = value; }
        }

        public string Ss
        {
            get { return ss; }
            set { ss = value; }
        }


    }
}