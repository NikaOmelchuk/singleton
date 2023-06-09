﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SingleLib;

namespace Singleton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Singlet db = Singlet.Instance();

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
                db.SelAll(textBox1.Text, dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (db.execute(textBox3.Text))
                MessageBox.Show("Ура! Все успешно выполнено!!");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (db.execute("DROP TABLE " + textBox1.Text + ";"))
                MessageBox.Show("Ура! Все успешно удалено!!");
        }
    }
}
