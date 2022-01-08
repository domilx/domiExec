using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KrnlAPI;

namespace JerryExecutor
{
    public partial class MainForm : Form
    {
        bool visible = false;

        public MainForm()
        {
            InitializeComponent();
            MainAPI.Load();

            vghub.Visible = false;
            yeild.Visible = false;
            button7.Text = "→ Script Hub";

        }

        Point lastPoint;
        
        
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainAPI.Execute(fastColoredTextBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainAPI.Inject();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("DO NOT PUT SPECIAL CHARACTERS IN THE NAME OF THE FILE YOU OPEN.");
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("DO NOT PUT SPECIAL CHARACTERS IN THE NAME OF THE FILE YOU SAVE.");
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //ScriptHub openform = new ScriptHub();
            //openform.Show();

            visible = !visible;
            if (visible)
            {
                yeild.Visible = true;
                vghub.Visible = true;

                button7.Text = "↓ Script Hub";
            }
            else
            {
                yeild.Visible = false;
                vghub.Visible = false;

                button7.Text = "→ Script Hub";
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("DO NOT PUT SPECIAL CHARACTERS IN THE NAME OF THE FILE YOU OPEN.");
            object Item = listBox1.SelectedItem;
            if (listBox1.SelectedItem == null)
            {
            } else
            {
                fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{Item}");
            }
        }

        private void JerryExecutor_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MainAPI.IsAttached() == true)
            {
                label3.Text = "Attached!";
                label3.ForeColor = Color.Green;
            }
            else
            {
                label3.Text = "Not Attached!";
                label3.ForeColor = Color.Red;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Help openform = new Help();
            //openform.Show();
           
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            MainAPI.Inject();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void vghub_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string Script = wb.DownloadString("https://raw.githubusercontent.com/1201for/V.G-Hub/main/V.Ghub");
            MainAPI.Execute(Script);
        }

        private void yeild_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string Script = wb.DownloadString("https://raw.githubusercontent.com/EdgeIY/infiniteyield/master/source");
            MainAPI.Execute(Script);
        }
    }
}
