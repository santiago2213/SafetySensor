using LibraryGroup7;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace MvcGroup7.Models
{
    public interface ISensorRepairRequestRepo   
    {
            List<SensorRepairRequest> GetAllSensorRepairRequests();

            //List<SensorLocation> GetAllSensorLocations();
            public int AddSensorRepairRequest(SensorRepairRequest data);

        public List<SensorLocation> GetAllLocations();

    }
}
