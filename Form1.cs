using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

namespace howto_get_part_of_screen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The image of the whole screen.
        private Bitmap ScreenBm, VisibleBm;

        // The area we are selecting.
        private int X0, Y0, X1, Y1;

        // Minimize.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.Cursor = Cursors.Cross;
            
        }

        // Close the program.
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Capture the whole screen.
        private void mnuWholeScreen_Click(object sender, EventArgs e)
        {
            // Get the whole screen's image.
            using (Bitmap bm = GetScreenImage())
            {
                // Save it.
                SavePicture(bm);
            }
        }

        // Let the user select a part of the screen.
        private void mnuCaptureArea_Click(object sender, EventArgs e)
        {
            // Get the whole screen's image.
            ScreenBm = GetScreenImage();

            // Display a copy.
            VisibleBm = (Bitmap)ScreenBm.Clone();

            // Display it.
            this.BackgroundImage = VisibleBm;
            this.Location = new Point(0, 0);
            this.ClientSize = VisibleBm.Size;
            this.MouseDown += Form1_MouseDown;
            this.Show();
        }

        // Start selecting an area.
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            X0 = e.X;
            Y0 = e.Y;
            X1 = e.X;
            Y1 = e.Y;

            this.MouseDown -= Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        // Continue selecting an area.
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            X1 = e.X;
            Y1 = e.Y;

            using (Graphics gr = Graphics.FromImage(VisibleBm))
            {
                // Copy the original image.
                gr.DrawImage(ScreenBm, 0, 0);

                // Draw the selected area.
                Rectangle rect = new Rectangle(
                    Math.Min(X0, X1),
                    Math.Min(Y0, Y1),
                    Math.Abs(X1 - X0),
                    Math.Abs(Y1 - Y0));
                gr.DrawRectangle(Pens.Yellow, rect);
            }
            this.Refresh();
        }

        // Finish selecting an area.
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Visible = false;
            this.MouseMove -= Form1_MouseMove;
            this.MouseUp -= Form1_MouseUp;

            // Save the selected part of the image.
            int wid = Math.Abs(X1 - X0);
            int hgt = Math.Abs(Y1 - Y0);
            Rectangle dest_rect = new Rectangle(0, 0, wid, hgt);
            Rectangle source_rect = new Rectangle(
                Math.Min(X0, X1),
                Math.Min(Y0, Y1),
                Math.Abs(X1 - X0),
                Math.Abs(Y1 - Y0));
            using (Bitmap selection = new Bitmap(wid, hgt))
            {
                // Copy the selected area.
                using (Graphics gr = Graphics.FromImage(selection))
                {
                    gr.DrawImage(ScreenBm, dest_rect, source_rect, GraphicsUnit.Pixel);
                }

                // Save the selected area.
                SavePicture(selection);
            }

            // Dispose of the other bitmaps.
            this.BackgroundImage = null;
            ScreenBm.Dispose();
            VisibleBm.Dispose();
            ScreenBm = null;
            VisibleBm = null;
        }

        // Grab the screen's image.
        private Bitmap GetScreenImage()
        {
            // Make a bitmap to hold the result.
            Bitmap bm = new Bitmap(
                Screen.PrimaryScreen.Bounds.Width, 
                Screen.PrimaryScreen.Bounds.Height, 
                PixelFormat.Format24bppRgb);

            // Copy the image into the bitmap.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.CopyFromScreen(
                    Screen.PrimaryScreen.Bounds.X,
                    Screen.PrimaryScreen.Bounds.Y,
                    0, 0,
                    Screen.PrimaryScreen.Bounds.Size,
                    CopyPixelOperation.SourceCopy);
            }

            // Return the result.
            return bm;
        }

        // Save the picture in a file selected by the user.
        private void SavePicture(Bitmap bm)
        {
            // Let the user pick a file to hold the image.
            if (sfdScreenImage.ShowDialog() == DialogResult.OK)
            {
                // Save the bitmap in the selected file.
                string filename = sfdScreenImage.FileName;
                FileInfo file_info = new FileInfo(filename);
                switch (file_info.Extension.ToLower())
                {
                    case ".bmp":
                        bm.Save(filename, ImageFormat.Bmp);
                        break;
                    case ".gif":
                        bm.Save(filename, ImageFormat.Gif);
                        break;
                    case ".jpg":
                    case ".jpeg":
                        bm.Save(filename, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        bm.Save(filename, ImageFormat.Png);
                        break;
                    default:
                        MessageBox.Show("Unknown file type " +
                            file_info.Extension, "Unknown Extension",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
