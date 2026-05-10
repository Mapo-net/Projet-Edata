using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Technician_data
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string?  DailyDate { get; set; }
    public string?  HourlyDate { get; set; }
    public float ElectricityKWh { get; set; }

}
