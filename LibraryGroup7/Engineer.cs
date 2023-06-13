using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup7
{
    public class Engineer : AppUser
    {
        public List<SensorRepairRequest> SensorRepairRequestCreated { get; set; }

        public Engineer(string fullname, string email, string phone, string password)
            : base(fullname, email, phone, password)
        {
            SensorRepairRequestCreated = new List<SensorRepairRequest>();

        }
        public Engineer()
        {

            SensorRepairRequestCreated = new List<SensorRepairRequest>();
        }
    }
}