
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class SensorRepairRequest
    {
        [Key]
        public int SensorRepairRequestId { get; set; }
        public int SensorLocationID { get; set; }
        [ForeignKey("SensorLocationID")]
        public SensorLocation SensorLocation { get; set; }
        public string? ITid { get; set; }
        [ForeignKey("ITid")]
        public IT? IT { get; set; }
        public string? SupervisorID { get; set; }
        [ForeignKey("SupervisorID")]
        public Supervisor? Supervisor { get; set; }
        public DateTime DateSensorRepairRequested { get; set; }
        public DateTime? DateSensorRepaired { get; set; }
        public List<Notes> SensorRepairRequestNotes { get; set; }
        public string EngineerID { get; set; }
        [ForeignKey("EngineerID")]
        public Engineer Engineer { get; set; }

        public string Description {get; set;}


        public SensorRepairRequest(DateTime dateSensorRepairRequested, string description, string engineerId, int sensorLocationID)
        {
            DateSensorRepairRequested = dateSensorRepairRequested;
            Description = description;
            EngineerID = engineerId;
            SensorLocationID = sensorLocationID;
            SensorRepairRequestNotes = new List<Notes>();
        }

        public SensorRepairRequest()
        {
            SensorRepairRequestNotes = new List<Notes>();
        }

       


    }
}