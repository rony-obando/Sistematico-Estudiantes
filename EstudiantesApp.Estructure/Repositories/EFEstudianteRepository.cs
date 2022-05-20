using EstudiantesApp.Domain.Entities;
using EstudiantesApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesApp.Estructure.Repositories
{
    public class EFEstudianteRepository : IEstudianteRepository
    {
        public IEstudianteDBContext Estudiante;
        public EFEstudianteRepository(IEstudianteDBContext estudiante)
        {

            Estudiante = estudiante;
        }
        public void Create(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Estudiante es nulo");
                }
                
                Estudiante.Estudiantes.Add(t);
                Estudiante.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Estudiante es nulo");
                }
                Estudiante.Estudiantes.Remove(t);
                Estudiante.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante FindById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"El id: {id} no puede ser menor o igual a 0");
                }
                return Estudiante.Estudiantes.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Estudiante> GetAll()
        {
            try
            {

                List<Estudiante> estudiante=Estudiante.Estudiantes.ToList();
                return estudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double GetPromedio(Estudiante estudiante)
        {
            try
            {
                if (estudiante == null)
                {
                    throw new ArgumentNullException("El objeto Estudiante es nulo");
                }
                int suma = estudiante.Matematica + estudiante.Programacion + estudiante.Estadistica + estudiante.Contabilidad;
                return suma / 4;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Estudiante es nulo");
                }
               
                Estudiante.Estudiantes.Update(t);
                Estudiante.SaveChanges();
                return t.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
