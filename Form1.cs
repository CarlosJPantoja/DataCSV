using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCSV
{
    public partial class Form1 : Form
    {
        private string[] data;
        private string[] abc = { "A","B","C","D","E","F","G","H","I","J","K","L","M",
            "N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                DataCSV(label1.Text);
               
                
                foreach (string word in abc)
                {
                    comboBox1.Items.Add(word);
                }
            }
        }

        private void DataCSV(string path)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(path);
            data = lines;
            if (lines.Length > 0)
            {
                string line = lines[0];
                string[] headers = line.Split(',');
                foreach (string word in headers)
                {
                    dt.Columns.Add(new DataColumn(word));
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dtword = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int index = 0;
                    foreach (string word in headers)
                    {
                        dr[word] = dtword[index++];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.Text;
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();
            string[] lines = data;
            
            if (lines.Length > 0)
            {
                string line = lines[0];
                string[] headers = line.Split(',');
                foreach (string word in headers)
                {
                    dt.Columns.Add(new DataColumn(word));
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dtword = lines[i].Split(',');
                    if (dtword[3].Substring(0,1).Equals(comboBox1.Text)) {
                        label1.Text = "Yeahhhhh";
                        DataRow dr = dt.NewRow();
                        int index = 0;
                        foreach (string word in headers)
                        {
                            dr[word] = dtword[index++];
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
