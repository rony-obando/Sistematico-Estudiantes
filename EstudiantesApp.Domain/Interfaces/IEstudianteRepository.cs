using EstudiantesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesApp.Domain.Interfaces
{
    public interface IEstudianteRepository:IRepository<Estudiante>
    {
        Estudiante FindById(int id);
        double GetPromedio(Estudiante estudiante);
    }
}
