namespace PickerFont.Models
{
    public class Monitos
    {
        public string Nombre { get; set; }

        public string NombreCorto =>
            Nombre.Length > 30 ? $"{Nombre.Substring(0, 30)}..." : Nombre;
    }
}
