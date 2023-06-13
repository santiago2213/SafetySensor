using LibraryGroup7;
using Microsoft.CodeAnalysis;
using MvcGroup7.Data;

namespace MvcGroup7.Models
{
    public class SensorRepairRequestRepo : ISensorRepairRequestRepo
    {
        private ApplicationDbContext _database;

        public SensorRepairRequestRepo(ApplicationDbContext database)
        {
            _database = database;
        }

        public int AddSensorRepairRequest(SensorRepairRequest data)
        {
            _database.SensorRepairRequest.Add(data);
            _database.SaveChanges();
            int sensorRepairRequestId = data.SensorRepairRequestId;
            return (sensorRepairRequestId);
        }

        public List<SensorLocation> GetAllLocations()
        {
            List<SensorLocation> locations = _database.SensorLocation.ToList();
            return locations;
            
        }

        public List<SensorRepairRequest> GetAllSensorRepairRequests()
        {
            List<SensorRepairRequest> allSensorRepairRequests = _database.SensorRepairRequest.ToList();
            return allSensorRepairRequests;
        }

        /*
        public List<SensorLocation> GetAllSensorLocations()
        {
            List<SensorLocation> allSensorLocations = _database.SensorLocation.ToList();
            return allSensorLocations;
        }
        */

    }

}
