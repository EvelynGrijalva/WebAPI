using System.Diagnostics.Metrics;

namespace BL
{
    public class Prestamo
    {
                                                   // ADD

        public static bool Add(ML.Prestamo prestamo)
        {
            try
            {
                using (DL.BibliotecaContext context = new DL.BibliotecaContext())
                {
                    context.Prestamos.Add(prestamo);  // Agrega el objeto Prestamo

                    if (prestamo.FechaPrestamo == null) // Valida si la Fecha es nula, de ser asi
                    {
                        prestamo.FechaPrestamo = DateTime.Now;   // le asigna el valor de la fecha de Hoy
                    }
                    if (prestamo.FechaDevolucion == null) // Si la fecha es nula
                    {
                        prestamo.FechaDevolucion = DateTime.Now.AddDays(prestamo.FechaPrestamo.Value.Day + 3);    // Calcula la fecha de Devolucion
                    }
                    context.SaveChanges();
                    return true;
                }
            } catch {
                return false;
            }
        }

                                                  // UPDATE

        public static bool Update(ML.Prestamo prestamo)
        {
            try
            {
                using (DL.BibliotecaContext context = new DL.BibliotecaContext())
                {
                    // Busca el prestamo en la base de datos

                    ML.Prestamo existingPrestamo = context.Prestamos.Find(prestamo.Id);

                    if (existingPrestamo == null)
                    {
                        return false; // No se Encontró el prestamo a Actualizar
                    }

                    // Actualizar las propiedades del prestamo existente con las del nuevo prestamo

                    existingPrestamo.FechaDevolucion = prestamo.FechaDevolucion;
                    existingPrestamo.Estado = prestamo.Estado;

                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

                                 // DELETE 
        public static bool Delete(int prestamoId)
        {
            try
            {
                using (DL.BibliotecaContext context = new DL.BibliotecaContext())
                {
                    // Busca el prestamo en la Base de Datos para Eliminarlo

                    ML.Prestamo prestamoToDelete = context.Prestamos.Find(prestamoId);

                    if (prestamoToDelete == null)
                    {
                        return false; // Cuando NO se encuentra el prestamo a Eliminar
                    }

                    context.Prestamos.Remove(prestamoToDelete);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

                                 // GET ALL

        public static List<ML.Prestamo> GetAll()
        {
            try
            {
                using (DL.BibliotecaContext context = new DL.BibliotecaContext())
                {
                    // Obtener TODOS los prestamos de la base de datos

                    List<ML.Prestamo> prestamos = context.Prestamos.ToList();

                    return prestamos;
                }
            }
            catch
            {
                return null;
            }
        }



    }
}