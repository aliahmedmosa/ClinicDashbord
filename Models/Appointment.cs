using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliMosaclinicTask.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        public int ID { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Patient BirthDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MMMM/yyy}")]
        public DateTime PatientBirthDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Patient Appointment")]
        public DateTime AppointmentDate { get; set; }

        public int DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        public Doctor? Doctor { get; set; }

    }
}
