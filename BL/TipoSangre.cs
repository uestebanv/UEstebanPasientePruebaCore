using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoSangre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UestebanPruebaPasienteContext context = new DL.UestebanPruebaPasienteContext())
                {
                    var query = context.TipoSangres.FromSqlRaw("TipoSangreGetAll").ToList();


                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.TipoSangre tipoSangre = new ML.TipoSangre();

                            tipoSangre.IdTipoSangre = item.IdTipoSangre;
                            tipoSangre.Nombre = item.Nombre;

                            result.Objects.Add(tipoSangre);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
