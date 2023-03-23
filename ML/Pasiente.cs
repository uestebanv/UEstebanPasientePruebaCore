namespace ML
{
    public class Pasiente
    {
        public int IdPasiente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public ML.TipoSangre TipoSangre { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Diagnostico { get; set; }
        public List<object> Pasientes { get; set; }
    }
}

