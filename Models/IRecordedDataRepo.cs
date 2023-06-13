using LibraryGroup7;

namespace MvcGroup7.Models
{
    public interface IRecordedDataRepo   //What should be done, Not HOW
    {

        public List<RecordedData> GetAllRecordedData();
        public int AddRecordedData(RecordedData data);
        public List<SensorLocation> GetSensorLocations();
        public int AddSensorLocation(SensorLocation sensorLocation);
    }

 
}
