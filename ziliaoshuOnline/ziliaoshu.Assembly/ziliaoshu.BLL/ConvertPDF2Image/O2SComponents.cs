using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using O2S.Components.PDFRender4NET;
using System.Collections.Generic;
using ZiLiaoShu.Entity;

namespace ziliaoshu.BLL
{
    public class O2SComponents
    {
        public enum Definition
        {
            One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
        }

        /// <summary>
        /// 将PDF文档转换为图片的方法
        /// </summary>
        /// <param name="pdfInputPath">PDF文件路径</param>
        /// <param name="imageNamePath">生成图片的名字路径</param>
        /// <param name="imageFormat">设置所需图片格式</param>
        /// <param name="startPageNum">从PDF文档的第几页开始转换</param>
        /// <param name="endPageNum">从PDF文档的第几页开始停止转换</param>
        /// <param name="definition">设置图片的清晰度，数字越大越清晰</param>
        public static void ConvertPDF2Image(string pdfInputPath, ref PDFFileEntityDOT fileInfo, ImageFormat imageFormat, int startPageNum = 1, int endPageNum = 1, Definition definition = Definition.One)
        {

            PDFFile pdfFile = PDFFile.Open(pdfInputPath);

            try
            {
                //if (!Directory.Exists(imageNamePath))
                //{
                //    Directory.CreateDirectory(imageNamePath);
                //}

                // validate pageNum
                if (startPageNum <= 0)
                {
                    startPageNum = 1;
                }

                if (endPageNum > pdfFile.PageCount)
                {
                    endPageNum = pdfFile.PageCount;
                }

                if (startPageNum > endPageNum)
                {
                    throw new Exception("错误");
                }
                var list = new List<string>();
                // start to convert each page
                for (int i = startPageNum; i <= endPageNum; i++)
                {
                    Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
                    fileInfo.ImgNamePath.Add(fileInfo.ImgPath + "_" + i.ToString() + "." + imageFormat.ToString());
                    string imgNameFullPath = (fileInfo.ImgFullPath + "_" + i.ToString() + "." + imageFormat.ToString());
                    pageImage.Save(imgNameFullPath, imageFormat);
                    fileInfo.ImgNameFullPath.Add(imgNameFullPath);
                    pageImage.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                pdfFile.Dispose();
            }
            


        }
    }
}
