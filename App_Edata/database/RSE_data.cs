using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RSE_data
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? MonthlyDate { get; set; }
    public float TotalKWh { get; set; }
    public float HeatingKWh { get; set; }
    public float WaterHeatingKWh { get; set; }
    public float AppliancesKWh { get; set; }
    public float LightingKWh { get; set; }
    public float OtherKWh { get; set; }

}
