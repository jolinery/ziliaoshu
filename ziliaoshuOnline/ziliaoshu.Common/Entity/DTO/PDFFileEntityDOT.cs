using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiLiaoShu.Entity
{
    public  class PDFFileEntityDOT
    {
        /// <summary>
        /// PDF的书名名
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// PDF文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// PDF文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// PDF文件带后缀名的路径
        /// </summary>
        public string FileNamePath { get; set; }

        /// <summary>
        /// DF文件带后缀名的全路径
        /// </summary>
        public string FileFullPath { get; set; }
        /// <summary>
        /// PDF图片带的路径
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// PDF图片的路径
        /// </summary>
        public string ImgFullPath { get; set; }
        /// <summary>
        /// DF图片后缀名的路径
        /// </summary>
        public List<string> ImgNamePath { get; set; }
        /// <summary>
        /// DF图片后缀名的全路径
        /// </summary>
        public List<string> ImgNameFullPath { get; set; }
    }
}
