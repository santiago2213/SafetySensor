using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryGroup7
{
    public class RecordedData
    {
        [Key]
        public int RecordedDataID { get; set; }
        public DateTime RecordedDataDate { get; set; }
        public string RecordedDataType { get; set; }
        public int RecordedDataValue { get; set; }   
        public int Time { get; set; }
        public int SensorLocationID { get; set; }
        [ForeignKey("SensorLocationID")]
        public SensorLocation SensorLocation { get; set; }
       

        public RecordedData(string recordedDataType, int recordedDataValue, int time, int sensorLocationId, DateTime recordedDataDate)
        {
            RecordedDataDate = recordedDataDate;
            RecordedDataType= recordedDataType;
            RecordedDataValue = recordedDataValue;
            Time = time;
            SensorLocationID = sensorLocationId;
           
        }

        public RecordedData()
        {

        }

    }

}