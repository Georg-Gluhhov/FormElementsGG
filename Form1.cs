using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace FormElementsGG
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox img;
        TabControl tabC;
        CheckBox cb1, cb2, cb3, cb4;
        TextBox txb;
        RadioButton rb, rb2;
        DataGridView dgv;
        MainMenu mm;
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
 
            tn.Nodes.Add(new TreeNode("Kaart"));
            tn.Nodes.Add(new TreeNode("MainMenu"));
            tn.Nodes.Add(new TreeNode("DataGridView"));

            //nupp
            btn = new Button();
            btn.Text = "Vajuta siia ";
            btn.Location = new Point(150,30);
            btn.Height = 30;
            btn.Width = 100;
            btn.Click += Btn_Click;

            //textbox
            txb = new TextBox();
            txb.Location = new Point(450,400);
            txb.Height = 10;
            txb.Width = 100;

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
            img.Size = new Size(150, 150);
            img.SizeMode = PictureBoxSizeMode.StretchImage;

            //checkbox
            cb1 = new CheckBox();
            cb2 = new CheckBox();
            cb3 = new CheckBox();
            cb4 = new CheckBox();

            cb1.Text = "Blue";
            cb1.Location = new Point(500, 70);

            cb2.Text = "Red";
            cb2.Location = new Point(500, 50);

            cb3.Text = "Green";
            cb3.Location = new Point(500, 30);

            cb4.Text = "White";
            cb4.Location = new Point(500, 90);

            cb1.MouseClick += Cb1_MouseClick;
            cb2.MouseClick += Cb2_MouseClick;
            cb3.MouseClick += Cb3_MouseClick;
            cb4.MouseClick += Cb4_MouseClick;
            //MainMenu
            mm = new MainMenu();
            MenuItem menuFile = new MenuItem("File");
            menuFile.MenuItems.Add("Exit", new EventHandler(menuFile_Exit_Select));
            menuFile.MenuItems.Add("Big screen", new EventHandler(menuFiles_Exit_Select));
            menuFile.MenuItems.Add("Small screen", new EventHandler(menuFiless_Exit_Select));
            mm.MenuItems.Add(menuFile);
            //radiobutton
            rb = new RadioButton();
            rb2 = new RadioButton();
            rb.Location = new Point(600, 70);
            rb2.Location = new Point(600, 40);
            rb.Text = "Red";
            rb2.Text = "Gray";
            rb.CheckedChanged += new EventHandler(rbt_Checked);
            rb2.CheckedChanged += new EventHandler(rbt_Checked);
            //DataGridView
            dgv = new DataGridView();
            DataSet ds = new DataSet("XML Fail. Menüü");
            ds.ReadXml("../../xml/xmlexp.xml");
            dgv.Location = new Point(500, 450);
            dgv.Size = new Size(200, 200);
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = ds;
            dgv.DataMember = "note";



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
        void menuFile_Exit_Select(object sender, System.EventArgs e)
        {
            this.Close();
        }
        void menuFiles_Exit_Select(object sender, System.EventArgs e)
        {

            this.Size = new Size(1000, 1000);

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
            this.Height = this.Height + 10;
            this.Width = this.Width + 10;

        }
        private void rbt_Checked(object sender, EventArgs e)
        {
            if (rb2.Checked)
            {
                tree.BackColor = Color.Gray; 
            }
            else if (rb.Checked)
            {
                tree.BackColor = Color.Red; 
            }
        }
        void menuFiless_Exit_Select(object sender, System.EventArgs e)
        {
            this.Size = new Size(800, 500);
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
            else if (e.Node.Text == "Radionupp-Radiobutton") 
            { 
                this.Controls.Add(rb);
                this.Controls.Add(rb2);
            }
            else if (e.Node.Text == "DataGridView")
            {
                this.Controls.Add(dgv);
            }
            else if (e.Node.Text == "Kaart")
            {
                tabC = new TabControl();
                tabC.Location = new Point(450, 150);
                tabC.Size = new Size(300, 200);
                TabPage tabP1 = new TabPage("Esimene");
                WebBrowser wb = new WebBrowser();
                wb.Url = new Uri("https://www.tthk.ee/");
                tabP1.Controls.Add(wb);
                TabPage tabP2 = new TabPage("Teine");
                WebBrowser wb2 = new WebBrowser();
                wb2.Url = new Uri("https://www.tthk.ee/");
                tabP2.Controls.Add(wb2);
                TabPage tabP3 = new TabPage("Kolmas");
                tabC.DoubleClick += TabP3_DoubleClick;
                tabC.MouseWheel += TabC_MouseWheel;

                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
                this.Controls.Add(tabC);


            }            
            else if (e.Node.Text == "Radionupp")
            {
                this.Controls.Add(img);
            }
            else if (e.Node.Text == "Markeruut-CheckBox")
            {
                this.Controls.Add(cb4);
                this.Controls.Add(cb3);
                this.Controls.Add(cb2);
                this.Controls.Add(cb1);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                this.Controls.Add(txb);
            }
            else if (e.Node.Text == "MainMenu")
            {

                this.Menu = mm;
            }


        }


        private void TabC_MouseWheel(object sender, MouseEventArgs e)
        {
            this.tabC.TabPages.Remove(tabC.SelectedTab);
        }


        private void TabP3_DoubleClick(object sender, EventArgs e)
        {
            string title = "tabP" + (tabC.TabCount + 1).ToString();
            TabPage tb = new TabPage(title);
            tabC.TabPages.Add(tb);

        }

         private void Cb1_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = this.BackColor = Color.FromArgb(0, 0, 255);
            
        }
         private void Cb2_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.BackColor = this.BackColor = Color.FromArgb(255, 0, 0);
        }
         private void Cb3_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = this.BackColor = Color.FromArgb(0, 255, 0);     
        }
         private void Cb4_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = this.BackColor = Color.FromArgb(255, 255, 255);       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
