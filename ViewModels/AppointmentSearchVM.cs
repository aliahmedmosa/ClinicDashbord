using System.ComponentModel.DataAnnotations;

namespace AliMosaclinicTask.ViewModels
{
    public class AppointmentSearchVM
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Patient Appointment")]
        public DateTime AppointmentStartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Patient Appointment")]
        public DateTime AppointmentEndDate { get; set; }
    }
}
