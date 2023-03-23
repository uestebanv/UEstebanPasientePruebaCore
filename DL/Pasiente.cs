using System;
using System.Collections.Generic;

namespace DL;

public partial class Pasiente
{
    public int IdPasiente { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public byte? IdTipoSangre { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? Diagnostico { get; set; }

    public virtual TipoSangre? IdTipoSangreNavigation { get; set; }

    public string NombreTipoSangre { get; set; }
}
