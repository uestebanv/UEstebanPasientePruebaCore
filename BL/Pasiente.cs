using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BL
{
    public class Pasiente
    {
        public static ML.Result Add(ML.Pasiente pasiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.UestebanPruebaPasienteContext context = new DL.UestebanPruebaPasienteContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"PasienteAdd '{pasiente.Nombre}'," +
                                                                           $"'{pasiente.ApellidoPaterno}'," +
                                                                           $"'{pasiente.ApellidoMaterno}'," +
                                                                           $"'{pasiente.TipoSangre.IdTipoSangre}'," +
                                                                           $"'{pasiente.FechaNacimiento}'," +
                                                                           $"'{pasiente.Sexo}'," +
                                                                           $"'{pasiente.Diagnostico}'");
                    if (query >= 1)
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
            }
            return result;
        }

        public static ML.Result Update(ML.Pasiente pasiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.UestebanPruebaPasienteContext context = new DL.UestebanPruebaPasienteContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"PasienteUpdate '{pasiente.IdPasiente}'," +
                                                                              $"'{pasiente.Nombre}'," +
                                                                              $"'{pasiente.ApellidoPaterno}'," +
                                                                              $"'{pasiente.ApellidoMaterno}'," +
                                                                              $"'{pasiente.TipoSangre.IdTipoSangre}'," +
                                                                              $"'{pasiente.FechaNacimiento}'," +
                                                                              $"'{pasiente.Sexo}'," +
                                                                              $"'{pasiente.Diagnostico}'");
                    if (query >= 1)
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
            }
            return result;
        }

        public static ML.Result Delete(int idPasiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.UestebanPruebaPasienteContext context = new DL.UestebanPruebaPasienteContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"PasienteDelete '{idPasiente}'");

                    if (query >= 1)
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
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.UestebanPruebaPasienteContext context = new DL.UestebanPruebaPasienteContext())
                {
                    var query = context.Pasientes.FromSqlRaw("PasienteGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Pasiente pasiente = new ML.Pasiente();

                            pasiente.IdPasiente = item.IdPasiente;
                            pasiente.Nombre = item.Nombre;
                            pasiente.ApellidoPaterno = item.ApellidoPaterno;
                            pasiente.ApellidoMaterno = item.ApellidoMaterno;
                            pasiente.TipoSangre = new ML.TipoSangre();
                            pasiente.TipoSangre.IdTipoSangre = item.IdTipoSangre.Value;
                            pasiente.TipoSangre.Nombre = item.NombreTipoSangre;
                            pasiente.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            pasiente.Sexo = item.Sexo;
                            pasiente.Diagnostico = item.Diagnostico;

                            result.Objects.Add(pasiente);
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

        public static ML.Result GetById(int idPasiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.UestebanPruebaPasienteContext context = new DL.UestebanPruebaPasienteContext())
                {
                    var query = context.Pasientes.FromSqlRaw($"PasienteGetById '{idPasiente}'").AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Pasiente pasiente = new ML.Pasiente();

                        pasiente.IdPasiente = query.IdPasiente;
                        pasiente.Nombre = query.Nombre;
                        pasiente.ApellidoPaterno = query.ApellidoPaterno;
                        pasiente.ApellidoMaterno = query.ApellidoMaterno;
                        pasiente.TipoSangre = new ML.TipoSangre();
                        pasiente.TipoSangre.IdTipoSangre = query.IdTipoSangre.Value;
                        pasiente.TipoSangre.Nombre = query.NombreTipoSangre.ToString(); //IdTipoSangre.Value;
                        pasiente.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        pasiente.Sexo = query.Sexo;
                        pasiente.Diagnostico = query.Diagnostico;

                        result.Object = pasiente;

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