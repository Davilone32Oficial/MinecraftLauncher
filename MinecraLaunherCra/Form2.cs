using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraLaunherCra
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = hScrollBar1.Value.ToString();
        }

        public HScrollBar RamScroll
        {
            get { return hScrollBar1; }
        }

        public TextBox IpServer
        {
            get { return ServerBox; }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = $"MB Ram: {hScrollBar1.Value.ToString()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();  
        }
    }
}
