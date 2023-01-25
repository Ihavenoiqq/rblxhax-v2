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
using WeAreDevs_API;
namespace rblxhax
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ExploitAPI api = new ExploitAPI();
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = fastColoredTextBox1.Text;
            this.api.SendLuaScript(text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialogfile = new OpenFileDialog();
            opendialogfile.Filter = "Lua File (*.lua)|*.lua|Text File (*.txt)|*.txt";
            opendialogfile.FilterIndex = 2;
            opendialogfile.RestoreDirectory = true;
            if (opendialogfile.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                fastColoredTextBox1.Text = "";
                System.IO.Stream stream;
                if ((stream = opendialogfile.OpenFile()) == null)
                    return;
                using (stream)
                    this.fastColoredTextBox1.Text = System.IO.File.ReadAllText(opendialogfile.FileName);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("An unexpected error has occured", "OOF!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        Point lastPoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) => fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            api.IsUpdated();
            api.LaunchExploit();
        }
    }
}
