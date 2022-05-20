using EstudiantesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EstudiantesApp.Domain.Interfaces
{
    public interface IEstudianteDBContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
