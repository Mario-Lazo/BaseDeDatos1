namespace BaseDeDatos1.Models
{
    public class EmpleadosModel
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public DateTime? FechaContratacion { get; set; }
    }
}