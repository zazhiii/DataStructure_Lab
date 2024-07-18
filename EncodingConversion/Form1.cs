using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncodingConversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            byte[] bytes = Encoding.Default.GetBytes(txt);
            string newTxt = Encoding.GetEncoding(comboBox1.Text).GetString(bytes);
            textBox2.Text = newTxt;
        }
    }
}
