
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Paint
{
    public class FilterTool : Tool
    {
        private FilterType toolType;

        public FilterTool(ToolArgs args, FilterType type) : base(args)
        {
            toolType = type;
            args.pictureBox.Cursor = Cursors.Cross;
            args.pictureBox.MouseUp += new MouseEventHandler(OnMouseUp);
            args.pictureBox.MouseMove += new MouseEventHandler(OnMouseMove);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            args.panel1.Text = e.Location.ToString();
            args.panel2.Text = "";
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (toolType == FilterType.Gray)
            {
                byte Grey;
                Color PixelColor;
                for (int i = 0; i < args.bitmap.Height; i++)
                {
                    for (int j = 0; j < args.bitmap.Width; j++)
                    {
                        PixelColor = args.bitmap.GetPixel(j, i);
                        Grey = (byte)(PixelColor.R * 0.3 + PixelColor.G * 0.59 + PixelColor.B * 0.11);
                        args.bitmap.SetPixel(j, i, Color.FromArgb(Grey, Grey, Grey));
                    }
                }
            }
            else if (toolType == FilterType.Sepia)
            {
                int outputRed, outputGreen, outputBlue;
                Color PixelColor;
                for (int i = 0; i < args.bitmap.Height; i++)
                {
                    for (int j = 0; j < args.bitmap.Width; j++)
                    {
                        PixelColor = args.bitmap.GetPixel(j, i);
                        outputRed = (int)((PixelColor.R * 0.393) + (PixelColor.G * 0.769) + (PixelColor.B * 0.189));
                        outputGreen = (int)((PixelColor.R * 0.349) + (PixelColor.G * 0.686) + (PixelColor.B * 0.168));
                        outputBlue = (int)((PixelColor.R * 0.272) + (PixelColor.G * 0.534) + (PixelColor.B * 0.131));
                        if (outputRed > 255) outputRed = 255;
                        if (outputGreen > 255) outputGreen = 255;
                        if (outputBlue > 255) outputBlue = 255;
                        args.bitmap.SetPixel(j, i, Color.FromArgb(outputRed, outputGreen, outputBlue));
                    }
                }
            }

            args.pictureBox.Invalidate();
        }

        public override void UnloadTool()
        {
            args.pictureBox.Cursor = Cursors.Default;
            args.pictureBox.MouseUp -= new MouseEventHandler(OnMouseUp);
            args.pictureBox.MouseMove -= new MouseEventHandler(OnMouseMove);
        }
    }
}
