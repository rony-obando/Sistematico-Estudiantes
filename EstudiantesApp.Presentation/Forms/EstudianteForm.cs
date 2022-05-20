using EstudiantesApp.Applications.Interfaces;
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
    public partial class EstudianteForm : Form
    {
        IEstudianteService estudiante;
        public EstudianteForm(IEstudianteService estudiante)
        {
            this.estudiante = estudiante;
            InitializeComponent();
        }
    }
}
