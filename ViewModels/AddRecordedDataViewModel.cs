
using System.ComponentModel.DataAnnotations;

namespace MvcGroup7.ViewModels
{
    public class AddRecordedDataViewModel
    {

        [Required(ErrorMessage = "Recorded Date cannot be empty!")]
        public DateTime RecordedDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Recorded Data Type cannot be empty!")]

        public string RecordedDataType { get; set; }
        [Required(ErrorMessage = "Recorded Data Value cannot be empty!")]
        public int RecordedDataValue { get; set; }
        [Required(ErrorMessage = "Time cannot be empty!")]
        public int Time { get; set; }
        [Required(ErrorMessage = "Sensor Location cannot be empty!")]
        public int SensorLocationID { get; set; }
    }


}
