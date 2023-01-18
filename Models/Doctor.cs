using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliMosaclinicTask.Models
{
    [Table("Doctors")]
    public class Doctor
    {
        public int ID { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        [Display(Name = "Doctor Schedule")]
        public string DoctorSchedule { get; set; } = string.Empty;
        public virtual List<Appointment>? Appointments { get; set; }
    }
}
