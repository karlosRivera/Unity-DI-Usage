using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Factory.initialize("OrcsWeb").GetConnection().State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Connection open");
            }
            else
            {
                MessageBox.Show("Connection close");
            }
        }
    }
}
