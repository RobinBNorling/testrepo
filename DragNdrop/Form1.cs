using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragNdrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // hue

        bool dragging = false;
        Point dragStart = new Point(0, 0);

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragStart = e.Location;
            dragging = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            if(((Control)sender).Bounds.IntersectsWith(trash.Bounds))
            {
                Controls.Remove((Control)sender);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(dragging)
            {
                ((Control)sender).Location = new Point(PointToClient(Cursor.Position).X - dragStart.X, PointToClient(Cursor.Position).Y - dragStart.Y);
                Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control newControl = null;

            if (listBox1.SelectedIndex == 0)
            {
                newControl = new Button();
                newControl.Size = new Size(100, 25);
                newControl.Text = "Button";
            }
            else if (listBox1.SelectedIndex == 1)
            {
                newControl = new PictureBox();
                newControl.Size = new Size(128, 128);
                newControl.BackColor = Color.DarkCyan;
            }
            else if (listBox1.SelectedIndex == 2)
            {
                newControl = new CheckBox();
                newControl.Size = new Size(100, 25);
                newControl.Text = "CheckBox";
                newControl.BackColor = Color.Lime;
            }
            else if (listBox1.SelectedIndex == 3)
            {
                newControl = new Label();
                newControl.Size = new Size(100, 25);
                newControl.Text = "Label";
                newControl.BackColor = Color.Lime;
            }

            newControl.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            newControl.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            newControl.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);

            newControl.Location = new Point(15, 15);
            Controls.Add(newControl);
            newControl.BringToFront();
        }
    }
}
