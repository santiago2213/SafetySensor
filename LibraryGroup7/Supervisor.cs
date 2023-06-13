using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class Supervisor : AppUser
    {
        public List<SensorRepairRequest> SensorRepairRequestApproved { get; set; }

        public Supervisor(string fullname, string email, string phone, string password)
            : base(fullname, email, phone, password)
        {
            SensorRepairRequestApproved = new List<SensorRepairRequest>();

        }
        public Supervisor() 
        { 
            SensorRepairRequestApproved = new List<SensorRepairRequest>(); 
        }
    }
}