using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormElementsGG
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox img;
        public Form1()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm Elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;


            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("Silt"));

            tn.Nodes.Add(new TreeNode("Markeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));

            tn.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            tn.Nodes.Add(new TreeNode("PictureBox"));

            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));

            //nupp
            btn = new Button();
            btn.Text = "Vajuta siia ";
            btn.Location = new Point(150,30);
            btn.Height = 30;
            btn.Width = 100;
            btn.Click += Btn_Click;
            //pealrikiri
            lbl = new Label();
            lbl.Text="Elementide loomine c# abil";
            lbl.Size = new Size(600,30);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;
            //image
            img = new PictureBox();
            img.Image = Image.FromFile(@"..\..\img\picbox.png");
            img.Location = new Point(150, 150);
            img.Size = new Size(350, 300);
            img.SizeMode = PictureBoxSizeMode.StretchImage;
            //carusel 
            img.DoubleClick += Img_DoubleClick;

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Img_DoubleClick(object sender, EventArgs e)
        {
            int count = 0;
            if (count == 0) { 
            img.Image = Image.FromFile(@"..\..\img\img1.png");
                count++;
            }
            else if (count == 1) { 
            img.Image = Image.FromFile(@"..\..\img\img2.png");
                count++;
            }
            else if (count == 2) { 
            img.Image = Image.FromFile(@"..\..\img\img3.png");
                count ++;
            }
            else if (count == 3) { 
            img.Image = Image.FromFile(@"..\..\img\picbox.png");
                count = 0;
            }
            else
            {

            }

        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.BackColor = Color.Transparent;
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.BackColor = Color.FromArgb(1, 1, 1);
        }

        private void Btn_Click(object sender, EventArgs e)
        {


            this.BackColor = this.BackColor = Color.FromArgb(255, 232, 232);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text=="Nupp")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text== "Silt")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "PictureBox")
            {
                this.Controls.Add(img);
            }

        }
    }
}
