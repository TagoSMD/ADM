using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADmv2
{
    public partial class Form1 : Form
    {

        string Str_Obt_Proc;
    
        private IconButton currentBtn;
        public Form1()


        {
            InitializeComponent();
    


            dataGridView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ActualizarTabla();
            // timer1.Enabled = true;
        }


        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 241);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {

                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //left border button

            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
            }
        }

        //DRAG
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void ActualizarTabla()
        {
            //limpieza del datagrid
            dataGridView1.Rows.Clear();
            //creacion columnas con sus respectivos nombres
            dataGridView1.Columns[0].Name = "Num. Procesos";
            dataGridView1.Columns[1].Name = "Procesos";
            dataGridView1.Columns[2].Name = "Prioridad Proceso";
            dataGridView1.Columns[3].Name = "ID";
            dataGridView1.Columns[4].Name = "Memoria Fisica";
            dataGridView1.Columns[5].Name = "Memoria Virtual";


            //Propiedad para autoajustar el tamaño de las celdas segun su contenido
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Propiedad para que el usuario seleccione solamente filas en la tabla y no celdas sueltas
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



            //Declaracion de la variable que sera un contador para el total de procesos
            int Int_Cant_Proc = 1;


            foreach (Process Proc_Proceso in Process.GetProcesses())
            {
                //Ingreso de los datos en el datagrid
                dataGridView1.Rows.Add(Int_Cant_Proc, Proc_Proceso.ProcessName, Proc_Proceso.BasePriority, Proc_Proceso.Id, Proc_Proceso.WorkingSet64,
                    Proc_Proceso.VirtualMemorySize64);
                //aumento en 1 de la variable
                Int_Cant_Proc += 1;
            }



        } 


        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = $"Servicios Activos: {dataGridView1.RowCount}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

            private void dgv_Proceso_MouseClick_1(object sender, MouseEventArgs e)
            {
                //La variable obtiene el Nombre del Proceso de la Tabla al hacerle clic
                Str_Obt_Proc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }


            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                // La variable obtiene el Nombre del Proceso de la Tabla al hacerle clic
                Str_Obt_Proc = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }

            private void panel3_Paint(object sender, PaintEventArgs e)
            {

            }

        Process[] proc;
        void GetAllProcess()
        {

            //Componente Process da acceso a los procesos que estan corriendo actualmente en la computadora
            proc = Process.GetProcesses();

        }
        private void ejecutarNuevoProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //  timer1.Start();
            using (FrmRunTask frm = new FrmRunTask())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    GetAllProcess();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
               
                foreach (Process proceso in Process.GetProcesses())
                {
                    if (proceso.ProcessName == Str_Obt_Proc)
                    {
                        proceso.Kill();
                        ActualizarTabla();

                    }
                }

            }
       
            catch (Exception x)
            {
               
            }
            ActivateButton(sender, RGBColors.color1);
            }
    
        private void iconButton2_Click(object sender, EventArgs e)
        {

            ActualizarTabla();
            ActivateButton(sender, RGBColors.color3);
        }
    }
}
