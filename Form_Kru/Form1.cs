﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Kru
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox boxlbl,boxbtn;
        RadioButton r1, r2;
        TextBox txtbox;
        PictureBox picture;
        TabControl tabcontrol;
        TabPage page1, page2, page3;
        ListBox lbox;
        DataSet dataset;
        public Form1()
        {
            this.Height= 500;
            this.Width = 1000;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            tn.Nodes.Add(new TreeNode("Silt-Button"));
            tn.Nodes.Add(new TreeNode("CheckBox-Button"));
            tn.Nodes.Add(new TreeNode("Radio-Button"));
            tn.Nodes.Add(new TreeNode("TextBox"));
            tn.Nodes.Add(new TreeNode("PictureBox"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("TabControl"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
            btn = new Button();
            btn.Text = "Vajuta siia!";
            btn.Location = new Point(150, 125);
            btn.Height = 60;
            btn.Width = 150;
            btn.Click += Btn_Click;
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(50, 20);
            lbl.Location = new Point(150, 200);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            } else if (e.Node.Text == "Silt-Button") {
                this.Controls.Add(lbl);
            } else if (e.Node.Text == "CheckBox-Button")
            {
                boxbtn = new CheckBox();
                boxbtn.Text = "Näita nupp";
                boxbtn.Location = new Point(200, 30);
                this.Controls.Add(boxbtn);
                boxlbl = new CheckBox();
                boxlbl.Text = "Näita  silt";
                boxlbl.Location = new Point(200, 60);
                this.Controls.Add(boxlbl);
                boxbtn.CheckedChanged += Boxbtn_CheckedChanged;
                boxlbl.CheckedChanged += Boxlbl_CheckedChanged;
            } else if (e.Node.Text == "Radio-Button")
            {
                r1 = new RadioButton();
                r1.Text = "Nupp Vasakule";
                r1.Location = new Point(300, 30);
                r2 = new RadioButton();
                r2.Text = "Nupp Paremale";
                r2.Location = new Point(300, 70);
                this.Controls.Add(r1);
                this.Controls.Add(r2);
                r1.CheckedChanged += new EventHandler(R1_CheckedChanged);
                r2.CheckedChanged += new EventHandler(R1_CheckedChanged);
            } else if (e.Node.Text == "TextBox") {
                string text;
                try
                {
                    text = File.ReadAllText("tekst.txt");
                }
                catch (FileNotFoundException)
                {
                    text = "Tekst puudub";
                }
                txtbox = new TextBox();
                txtbox.Multiline = true;
                txtbox.Text = text;
                txtbox.Size = new Size(200, 100);
                txtbox.Location = new Point(150, 300);
                this.Controls.Add(txtbox);

            } else if (e.Node.Text == "PictureBox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("smile.jpg");
                picture.Location = new Point(450, 250);
                picture.Size = new Size(200, 200);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            } else if (e.Node.Text == "TabControl")
            {
                tabcontrol = new TabControl();
                tabcontrol.Location = new Point(450, 10);
                tabcontrol.Size = new Size(200, 100);
                page1 = new TabPage("Esimene");
                page2 = new TabPage("Teine");
                page3 = new TabPage("Kolmas");
                tabcontrol.Controls.Add(page1);//0
                tabcontrol.Controls.Add(page2);//1
                tabcontrol.Controls.Add(page3);//2
                Controls.Add(tabcontrol);
                Label lbl2 = new Label() { Text = "Esimene" };
                page1.Controls.Add(lbl2);
                Label lbl3 = new Label() { Text = "Teine" };
                page2.Controls.Add(lbl3);
                Label lbl4 = new Label() { Text = "Kolmas" };
                page3.Controls.Add(lbl4);

            } else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad inputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    var answer2 = MessageBox.Show("Tahad salevesta tekst?", "Teksti salvestamine", MessageBoxButtons.OKCancel);
                    if (answer2 == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                }

            } else if (e.Node.Text == "ListBox")
            {
                lbox = new ListBox();
                string[] C = new string[] { "Kollane", "Punane", "Sinine", "Roheline" };
                foreach (var item in C)
                {
                    lbox.Items.Add(item);
                }
                lbox.Location = new Point(700, 10);
                lbox.Height = C.Length*15;
                lbox.Width = C[3].Length*10;
                Controls.Add(lbox);
            } else if(e.Node.Text == "DataGridView") {
                dataset = new DataSet("Näide");
                dataset.ReadXml("..//File//excample.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(450,125);
                dgv.Width = 250;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "note";
                dgv.DataSource = dataset;
                Controls.Add(dgv);

            } else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuitem1 = new MenuItem("File");
                MenuItem menuitem2 = new MenuItem("My");
                menuitem1.MenuItems.Add("Exit", new EventHandler(menuitem1_Exit));
                menuitem2.MenuItems.Add("Clear all", new EventHandler(menuitem2_Clear_All));
                menu.MenuItems.Add(menuitem1);
                menu.MenuItems.Add(menuitem2);
                this.Menu = menu;
            }
        }

        private void menuitem2_Clear_All(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas tahad kustutada kõik?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Controls.Clear();
            }
        }

        private void menuitem1_Exit(object sender, EventArgs e)
        {
            if(MessageBox.Show("Kas oled kindel?","Küsimus",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void R1_CheckedChanged(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 125);
            }    else if (r2.Checked)
            {
                btn.Location = new Point(400,125);
            }
        }

        private void Boxlbl_CheckedChanged(object sender, EventArgs e)
        {
            if (boxlbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Boxbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (boxbtn.Checked)
            {
                Controls.Add(btn);
            } else
            {
                Controls.Remove(btn);
            }
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Red;
                lbl.Text = "Red";
            } else
            {
                lbl.BackColor = Color.Blue;
                lbl.Text = "Blue";
                btn.BackColor = Color.Blue;
            }
            
        }
    }
}
