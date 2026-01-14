using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace helppls
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Tabulka = textTabuka.Text;
            
            string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};";
            int nummm = (int)numericUpDown1.Value;
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM {Tabulka} WHERE ID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", nummm);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Show each row in a message box
                                //MessageBox.Show($"ID: {reader["ID"]}, Name: {reader["jmeno"]}");
                                label1.Text = $"ID: {reader["ID"]}";
                                label2.Text = $"jmeno: {reader["jmeno"]}";
                                label3.Text = $"prijmeni: {reader["prijmeni"]}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                button1_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            path = textBox1.Text;
        }
    }
}
//hehe