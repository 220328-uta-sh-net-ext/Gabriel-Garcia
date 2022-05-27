using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
    [Table("plants")]
    public class Plants
    {
        [Key]
        [Column("Id")]
        public string PlantsId { get; set; }
        [Required]
        public string PlantsName { get; set; }
        [Required]
        public string PlantsType { get; set; }
        [Required]
        public string SunExposure { get; set; }
        [Required]
        public string SoilMoisture { get; set; }
        [Required]
        public string SeasonOfInterest { get; set; }
        [Required]
        public string ZoneId { get; set; }
    }
}
