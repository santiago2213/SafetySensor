using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class Facility
    {
        [Key]
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }    
        public List<SensorLocation> SensorLocation { get; set; }



        public Facility(string facilityName)
        {
            FacilityName = facilityName;
            SensorLocation = new List<SensorLocation>();
        }

        public Facility()
        {
            SensorLocation = new List<SensorLocation>();
        }
    }




}