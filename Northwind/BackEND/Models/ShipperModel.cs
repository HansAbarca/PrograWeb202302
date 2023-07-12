namespace BackEND.Models
{
    /// <summary>
    /// Contiene ShipperID y Company Name
    /// </summary>
    public class ShipperModel
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;

        public byte[]? Picture { get; set; }
    }
}
