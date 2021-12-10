
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class FilterTool : Tool
    {
        public FilterTool(ToolArgs args)
            : base(args)
        {
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
            MessageBox.Show("I'm your new tool!");
        }

        public override void UnloadTool()
        {
            args.pictureBox.Cursor = Cursors.Default;
            args.pictureBox.MouseUp -= new MouseEventHandler(OnMouseUp);
            args.pictureBox.MouseMove -= new MouseEventHandler(OnMouseMove);
        }
    }
}
