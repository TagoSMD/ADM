using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ADmv2
{
    public partial class FrmRunTask : Form
    {
        public FrmRunTask()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              if(!String.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = textBox1.Text;
                    proc.Start();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }
    }
}
