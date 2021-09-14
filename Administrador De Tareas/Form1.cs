using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrador_De_Tareas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateProcessList();
          //  timer1.Enabled = true;

        }
        private void UpdateProcessList()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
 
            int id = 1;
            foreach (Process p in Process.GetProcesses())
            {
                listBox1.Items.Add(id + ":" + p.ProcessName); // nombre del proceso
                listBox2.Items.Add(id + ": " + p.Id);// id del proceso
  

                id = id + 1;
            }
   
        }

        Process[] proc;

        void GetAllProcess()
        {

        //Componente Process da acceso a los procesos que estan corriendo actualmente en la computadora
            proc = Process.GetProcesses();
            listBox1.Items.Clear();
            foreach (Process p in proc)
                listBox1.Items.Add(p.ProcessName);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            GetAllProcess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process pro in Process.GetProcesses())
                {
                   string strSelec = listBox1.SelectedItem.ToString(); // proceso seleccionado en el list box
                   string[] strProceso = strSelec.Split(':');// divido el contenido del listbox


                    {

                        try
                        {
                            foreach (Process Programa in Process.GetProcesses())
                            {
                                String seleccion = listBox1.SelectedItem.ToString();
                              String[] proceso = seleccion.Split(':');
                                if (Programa.ProcessName == proceso[1])
                                {
                                    Programa.Kill();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }


                    if (pro.ProcessName == strProceso[1])
                    {
                        pro.Kill(); // elimina el proceso
                    }
                }
              
            }
            catch (Exception ex)
            {
             
            }
        
    }

        private void runNewTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(FrmRunTask frm=new FrmRunTask())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    GetAllProcess();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           UpdateProcessList();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("firefox"))
                foreach (Process pro1 in Process.GetProcessesByName("Spotify"))
                {
                    proc.Kill();
                    pro1.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
