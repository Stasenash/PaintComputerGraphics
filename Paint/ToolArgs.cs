
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class ToolArgs
    {
        public ImageFile imageFile;
        public Bitmap bitmap;
        public PictureBox pictureBox;
        public StatusBarPanel panel1;
        public StatusBarPanel panel2;
        public IPaintSettings settings;

        public ToolArgs(ImageFile imageFile, Bitmap bitmap, PictureBox pictureBox, StatusBarPanel panel1, StatusBarPanel panel2, IPaintSettings settings)
        {
            this.imageFile = imageFile;
            this.bitmap = bitmap;
            this.pictureBox = pictureBox;
            this.panel1 = panel1;
            this.panel2 = panel2;
            this.settings = settings;
        }
    }
}
