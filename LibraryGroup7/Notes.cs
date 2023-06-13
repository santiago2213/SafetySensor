using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class Notes
    {
        [Key]
        public string NoteID { get; set; }
        public string Description { get; set; }
        public DateTime NoteCreated { get; set; }
        public int SensorRepairRequestID { get; set; }
        [ForeignKey("SensorRepairRequestID")]
        public SensorRepairRequest SensorRepairRequest { get; set; }
        public string ITId { get; set; }
        [ForeignKey("ITId")]
        public IT? IT { get; set; }
        public string SupervisorId { get; set; }
        [ForeignKey("SupervisorId")]
        public Supervisor? Supervisor { get; set; }

        public string EngineerId { get; set;}
        [ForeignKey("SupervisorId")]
        public Engineer? Engineer { get; set; }

        public Notes(SensorRepairRequest sensorRepairRequest, string description, DateTime noteCreated, IT? it, Supervisor? supervisor, Engineer? engineer)
        {
            SensorRepairRequest = sensorRepairRequest;
            Description = description;
            NoteCreated = noteCreated;
            IT = it;
            Supervisor = supervisor;
            Engineer = engineer;
        }

        public Notes()
        {

        }

    }
}