
using System;
using System.Drawing;

namespace Paint
{
    public class ImageFile
    {
        private string fileName;
        private Bitmap bitmap;

        public ImageFile(Size size, Color backColor)
        {
            fileName = null;
            bitmap?.Dispose();
            bitmap = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            // fill by background color
            Graphics g = Graphics.FromImage(Bitmap);
            g.Clear(backColor);
            g.Dispose();
        }

        ~ImageFile()
        {
            bitmap.Dispose();
        }

        public bool Open(string file)
        {
            try
            {
                bitmap?.Dispose();

                Bitmap tempBitmap = new Bitmap(file, true);
                bitmap = new Bitmap(tempBitmap.Width, tempBitmap.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(tempBitmap, 0, 0);
                }
                tempBitmap.Dispose();

                fileName = file;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(string file)
        {
            try
            {
                bitmap.Save(file);
                fileName = file;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string FileName
        {
            get { return fileName; }
        }

        public Bitmap Bitmap
        {
            get { return bitmap; }
        }
    }
}
