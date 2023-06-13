using LibraryGroup7;

namespace MvcGroup7.ViewModels
{
    public class SearchSensorRepairRequestsViewModel
    {
        
          public DateTime? SearchDate { get; set; }
          public string? SearchEngineerFullName { get; set; }
          public List<SensorRepairRequest> SensorRepairRequests { get; set; }

           public string SearchLocation { get; set; }


    }

}
