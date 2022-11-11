using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class XuLyAnh
    {
        private static XuLyAnh instance;

        public static XuLyAnh Instance 
        { 
            get { if (instance == null) instance = new XuLyAnh(); return instance; }
            private set => instance = value; 
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }
    }
}
