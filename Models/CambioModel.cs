public class CambioModel
{
    public string MonedaOrigen { get; set; }
    public string MonedaDestino { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Resultado { get; set; }
    
    public static readonly Dictionary<string, decimal> TasasDeCambio = new()
    {
        {"BRL_PEN", 0.75m},
        {"PEN_BRL", 1.33m}   
    };
}