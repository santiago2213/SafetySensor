using LibraryGroup7;
using System.ComponentModel.DataAnnotations;

namespace MvcGroup7.ViewModels
{
    public class AddSensorRepairRequestViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sensor request date required")]
        public DateTime? DateSensorRepairRequested { get; set; }


        [Required(ErrorMessage = "EngineerId required")]
        public string? EngineerId { get; set; }


        [Required(ErrorMessage = "Description required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Sensor location required")]
      public int? SensorLocationID { get; set; }
    }

}
