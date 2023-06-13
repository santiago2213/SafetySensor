using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class SensorLocation
    {
        [Key]
        public int SensorLocationID { get; set; }
        public string LocationName { get; set; }
        public List<SensorRepairRequest> SensorRepairRequests { get; set; }
        public List<RecordedData> RecordedData { get; set; }
        public int FacilityID { get; set; }
        [ForeignKey ("FacilityID")]
        public Facility Facility { get; set; }


        public SensorLocation(string locationName, int facilityID)
        {
            LocationName = locationName;
            FacilityID = facilityID;
            SensorRepairRequests = new List<SensorRepairRequest>();
            RecordedData = new List<RecordedData>();
        }

        public SensorLocation()
        {
            SensorRepairRequests = new List<SensorRepairRequest>();
            RecordedData = new List<RecordedData>();
        }
    }
}