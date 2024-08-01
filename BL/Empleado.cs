using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PSanchezExamenEntities context = new DL.PSanchezExamenEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.Id = fila.IdEmpleado;
                            empleado.NumeroNomina = fila.NumeroNomina;
                            empleado.Nombre = fila.Nombre;
                            empleado.ApellidoPaterno = fila.ApellidoPaterno;
                            empleado.ApellidoMaterno = fila.ApellidoMaterno;
                            empleado.CatEntidadFederativa = new ML.CatEntidadFederativa();
                            empleado.CatEntidadFederativa.Id = fila.IdEstado;
                            empleado.CatEntidadFederativa.Estado = fila.Estado;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int id)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PSanchezExamenEntities context = new DL.PSanchezExamenEntities())
                {
                    var query = context.EmpleadoGetById(id).FirstOrDefault();

                    if (query != null)
                    {
                        var fila = query;

                        ML.Empleado empleado = new ML.Empleado();

                        empleado.Id = fila.IdEmpleado;
                        empleado.NumeroNomina = fila.NumeroNomina;
                        empleado.Nombre = fila.Nombre;
                        empleado.ApellidoPaterno = fila.ApellidoPaterno;
                        empleado.ApellidoMaterno = fila.ApellidoMaterno;
                        empleado.CatEntidadFederativa = new ML.CatEntidadFederativa();

                        empleado.CatEntidadFederativa.Id = fila.IdEstado;
                        empleado.CatEntidadFederativa.Estado = fila.Estado;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PSanchezExamenEntities context = new DL.PSanchezExamenEntities())
                {
                    var query = context.EmpleadoAdd(empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.CatEntidadFederativa.Id);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PSanchezExamenEntities context = new DL.PSanchezExamenEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.Id,empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.CatEntidadFederativa.Id);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PSanchezExamenEntities context = new DL.PSanchezExamenEntities())
                {
                    var query = context.EmpleadoDelete(empleado.Id);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
