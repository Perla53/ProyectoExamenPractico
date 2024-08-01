using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CatEntidadFederativa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PSanchezExamenEntities context = new DL.PSanchezExamenEntities())
                {
                    var query = (from catEntidadFederativa in context.CatEntidadFederativa
                                 select new
                                 {
                                     catEntidadFederativa.Id,
                                     catEntidadFederativa.Estado,
                                 }).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in query)
                        {
                            ML.CatEntidadFederativa catEntidadFederativa = new ML.CatEntidadFederativa();
                            catEntidadFederativa.Id = fila.Id;
                            catEntidadFederativa.Estado = fila.Estado;

                            result.Objects.Add(catEntidadFederativa);
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
    }
}
