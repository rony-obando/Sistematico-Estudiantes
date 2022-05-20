using EstudiantesApp.Applications.Interfaces;
using EstudiantesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudiantesApp.Presentation.Forms
{
    public partial class AñadirForm : Form
    {
        IEstudianteService estudianteService;
        //Estudiante estudiante1;
        public AñadirForm(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
            InitializeComponent();
        }
       
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Verificar())
            {
                MessageBox.Show("Rellene todo el formulario.");
                return;
            }
            Estudiante estudiante = new Estudiante()
            {
                
                Nombres=txtNombre.Text,
                Apellidos=txtApellido.Text,
                Carnet=txtCarnet.Text,
                Correo=txtCorreo.Text,
                Direccion=txtDireccion.Text,
                Matematica=(int)nudMatematica.Value,
                Estadistica=(int)nudEstadistica.Value,
                Programacion=(int)nudProgramacion.Value,
                Phone=txtPhone.Text,
                Contabilidad=(int)nudContabilidad.Value
                
            };
            estudianteService.Create(estudiante);
            dataGridView1.DataSource = estudianteService.GetAll();
            //Close();
        }
        private bool Verificar()
        {
            if (string.IsNullOrEmpty(txtApellido.Text) && string.IsNullOrEmpty(txtCarnet.Text) &&
              string.IsNullOrEmpty(txtCorreo.Text) && string.IsNullOrEmpty(txtDireccion.Text) &&
              string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtPhone.Text))
            {
                return false;
            }
            return true;
        }
        private void AñadirForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = estudianteService.GetAll();
        }
        Estudiante estudiante1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            textBox1.Text = estudianteService.GetPromedio(estudianteService.FindById(id)).ToString();
            Estudiante estudiante = estudianteService.FindById(id);
            estudiante1 = estudiante;
            txtApellido.Text = estudiante.Apellidos;
            txtCarnet.Text = estudiante.Carnet;
            txtCorreo.Text = estudiante.Correo;
            txtDireccion.Text = estudiante.Direccion;
            txtNombre.Text = estudiante.Nombres;
            txtPhone.Text = estudiante.Phone;
            nudContabilidad.Value = estudiante.Contabilidad;
            nudEstadistica.Value = estudiante.Estadistica;
            nudMatematica.Value = estudiante.Matematica;
            nudProgramacion.Value = estudiante.Programacion;
            textBox2.Text = id.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            estudiante1.Nombres = txtNombre.Text;
            estudiante1.Apellidos = txtApellido.Text;
            estudiante1.Carnet = txtCarnet.Text;
            estudiante1.Correo = txtCorreo.Text;
            estudiante1.Direccion = txtDireccion.Text;
            estudiante1.Matematica = (int)nudMatematica.Value;
            estudiante1.Estadistica = (int)nudEstadistica.Value;
            estudiante1.Programacion = (int)nudProgramacion.Value;
            estudiante1.Phone = txtPhone.Text;
            estudiante1.Contabilidad = (int)nudContabilidad.Value;
            estudianteService.Delete(estudiante1);
            dataGridView1.DataSource = estudianteService.GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            //Id = int.Parse(textBox2.Text);
            estudiante1.Nombres = txtNombre.Text;
            estudiante1.Apellidos = txtApellido.Text;
            estudiante1.Carnet = txtCarnet.Text;
            estudiante1.Correo = txtCorreo.Text;
            estudiante1.Direccion = txtDireccion.Text;
            estudiante1.Matematica = (int)nudMatematica.Value;
            estudiante1.Estadistica = (int)nudEstadistica.Value;
            estudiante1.Programacion = (int)nudProgramacion.Value;
            estudiante1.Phone = txtPhone.Text;
            estudiante1.Contabilidad = (int)nudContabilidad.Value;
            estudianteService.Update(estudiante1);
            dataGridView1.DataSource = estudianteService.GetAll();
        }
    }
}
