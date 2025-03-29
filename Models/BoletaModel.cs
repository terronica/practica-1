// Models/BoletaModel.cs
using System.ComponentModel.DataAnnotations;

public class BoletaModel
{
    public string MonedaOrigen { get; set; }
    public string MonedaDestino { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Resultado { get; set; }
    
    [Required]
    public string Nombre { get; set; }
    
    [Required]
    public string Apellido { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string DNI { get; set; }
    
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string NumeroBoleta { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
}