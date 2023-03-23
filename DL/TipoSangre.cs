using System;
using System.Collections.Generic;

namespace DL;

public partial class TipoSangre
{
    public byte IdTipoSangre { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Pasiente> Pasientes { get; } = new List<Pasiente>();
}
