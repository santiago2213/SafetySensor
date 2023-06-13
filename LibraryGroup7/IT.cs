using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class IT : AppUser
    {
        public List<SensorRepairRequest> SensorWorkedOn { get; set; }

        public IT(string fullname, string email, string phone, string password)
            : base(fullname, email, phone, password)
        {
            SensorWorkedOn = new List<SensorRepairRequest>();
        }

        public IT()
        {
            SensorWorkedOn = new List<SensorRepairRequest>();

        }
        
    }
}