using LibraryGroup7;
using Microsoft.EntityFrameworkCore;
using MvcGroup7.Data;

namespace MvcGroup7.Models
{
    public class RecordedDataRepo : IRecordedDataRepo
    {
        private ApplicationDbContext _database;

        public RecordedDataRepo(ApplicationDbContext database)
        {
            _database = database;

        }

        public int AddRecordedData(RecordedData data)
        {
            _database.RecordedData.Add(data);
            _database.SaveChanges();
            int recordedDataId = data.RecordedDataID;
            return (recordedDataId);
        }

        //public List<RecordedData> GetAllRecordedData()
        //{
        //    throw new NotImplementedException();
        //}

        public List<RecordedData> GetAllRecordedData()
        {
            List<RecordedData> allRecordedData = _database.RecordedData.Include(v => v.SensorLocation).ThenInclude(v => v.Facility).ToList();
            return allRecordedData;
        }

        public List<SensorLocation> GetSensorLocations()
        {
            List<SensorLocation> sensorLocations = _database.SensorLocation.ToList();
            return sensorLocations;
        }

        public int AddSensorLocation(SensorLocation sensorLocation)
        {
            int sensorLocationID = 0;
            _database.SensorLocation.Add(sensorLocation);
            try
            {
                _database.SaveChanges();
                sensorLocationID = sensorLocation.SensorLocationID;
            }
            catch (DbUpdateException dbUpdateException)
            {
                string errorMessage = dbUpdateException.Message;
                sensorLocationID = -1;
            }

            return sensorLocationID;
        }
    }
}
