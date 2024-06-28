using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a GraphicsPath object with rounded edges
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(0, 0, 20, 20, 180, 90);
            graphicsPath.AddLine(20, 0, this.Width - 20, 0);
            graphicsPath.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            graphicsPath.AddLine(this.Width, 20, this.Width, this.Height - 20);
            graphicsPath.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            graphicsPath.AddLine(this.Width - 20, this.Height, 20, this.Height);
            graphicsPath.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            graphicsPath.AddLine(0, this.Height - 20, 0, 20);
            graphicsPath.CloseFigure();

            // Set the Region property of the form to the GraphicsPath object
            this.Region = new Region(graphicsPath);
        }

        private void lblminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        // Declare a flag to indicate whether dragging is in progress
        private bool isDragging = false;

        // Declare a variable to store the offset between the mouse cursor and the top-left corner of the form
        private Point mouseOffset;

        private void f3movedown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Set the flag to indicate that dragging is in progress
                isDragging = true;
                // Store the location of the mouse cursor relative to the top-left corner of the form
                mouseOffset = new Point(-e.X, -e.Y);
            }
        }

        private void f3moveup(object sender, MouseEventArgs e)
        {
            // Reset the flag to indicate that dragging is no longer in progress
            isDragging = false;
        }

        private void f3mousemove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the new position of the form based on the current location of the mouse cursor and the mouseOffset value
                Point newLocation = Point.Add(e.Location, (Size)mouseOffset);
                newLocation = Point.Add(newLocation, (Size)this.Location);
                // Set the new position of the form
                this.Location = newLocation;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/jfK9fBXD");
        }

        private void labelmain_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        { 
        }
    }
}
