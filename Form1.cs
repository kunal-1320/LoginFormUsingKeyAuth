using KeyAuth;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LoginForm;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public static api KeyAuthApp = new api(
            name: "name ",
            ownerid: "ownerid ",
            secret: "secret id ",
            version: "1.0"


        );
        public Form1()
        {
            InitializeComponent();
            // Set the FormBorderStyle property to None
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




        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = SystemColors.HighlightText;
            }
        }





        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = SystemColors.HighlightText;
            }
        }







        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = SystemColors.HighlightText;
            }
        }






        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = SystemColors.HighlightText;
            }
        }






        private void txtUsername_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }





        // Declare a flag to indicate whether dragging is in progress
        private bool isDragging = false;

        // Declare a variable to store the offset between the mouse cursor and the top-left corner of the form
        private Point mouseOffset;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Set the flag to indicate that dragging is in progress
                isDragging = true;
                // Store the location of the mouse cursor relative to the top-left corner of the form
                mouseOffset = new Point(-e.X, -e.Y);
            }
        }






        private void Form1_MouseMove(object sender, MouseEventArgs e)
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




        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the flag to indicate that dragging is no longer in progress
            isDragging = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Create a new instance of Form2
            Form2 form2 = new Form2();

            // Show Form2
            form2.Show();

            // Hide the current form
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
            KeyAuthApp.check();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(txtUsername.Text, txtPassword.Text);
            if(KeyAuthApp.response.success)
            {
                MessageBox.Show("Login Success", "Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                // Create a new instance of Form2
                Form3 form3 = new Form3();

                // Show Form2
                form3.Show();

                // Hide the current form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect !");
            }
        }

        private void lblminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/jfK9fBXD");
        }
    }
}
