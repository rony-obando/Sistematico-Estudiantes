using EstudiantesApp.Applications.Interfaces;
using EstudiantesApp.Domain.Entities;
using EstudiantesApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesApp.Applications.Services
{
    public class EstudianteService : IEstudianteService
    {
        private IEstudianteRepository estudiante1;
        public EstudianteService(IEstudianteRepository estudiante)
        {
            estudiante1 = estudiante;
        }
        public void Create(Estudiante t)
        {
            estudiante1.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            return estudiante1.Delete(t);
        }

        public Estudiante FindById(int id)
        {
            return estudiante1.FindById(id);
        }

        public List<Estudiante> GetAll()
        {
            return estudiante1.GetAll();
        }

        public double GetPromedio(Estudiante estudiante)
        {
            return estudiante1.GetPromedio(estudiante);
        }

        public int Update(Estudiante t)
        {
            return estudiante1.Update(t);
        }
    }
}
