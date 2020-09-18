using System;
using System.Linq;
using Ejercicio1_3_2020.DAL;
using Ejercicio1_3_2020.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Ejercicio1_3_2020.BLL
{
    public class EstudiantesBll
    {
        private Contexto _contexto;

        public EstudiantesBll(Contexto contexto){
            _contexto = contexto;
        }

        public bool Guardar(Estudiantes estudiante)
        {
            if (!Existe(estudiante.EstudianteId))
                return Insertar(estudiante);
            else
                return Modificar(estudiante);
        }

         private bool Insertar(Estudiantes estudiante)
        {
            bool paso = false;
            

            try
            {
                
                _contexto.Estudiantes.Add(estudiante);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return paso;
        }

         public bool Modificar(Estudiantes estudiante)
        {
            bool paso = false;

            try
            {
                
               
                _contexto.Entry(estudiante).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return paso;
        }

        public bool Existe(int id)
        {
            bool encontrado = false;

            try
            {
                encontrado =_contexto.Estudiantes.Any(e => e.EstudianteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return encontrado;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            try 
            {
                var eliminar=_contexto.Estudiantes.Find(id);
                _contexto.Entry(eliminar).State= EntityState.Deleted;

                paso=(_contexto.SaveChanges()>0);

            }catch(Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return paso;
        }

        public Estudiantes Buscar(int id)
        {
            Estudiantes estudiantes= new Estudiantes();

            try
            {
                estudiantes=_contexto.Estudiantes.Find(id); 
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return estudiantes;
        }

        public List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> estudiantes)
        {
            List<Estudiantes> Lista= new List<Estudiantes>();

            try
            {
                Lista = _contexto.Estudiantes.Where(estudiantes).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return Lista;
        }


    }

}