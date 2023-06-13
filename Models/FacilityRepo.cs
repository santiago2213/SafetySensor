using LibraryGroup7;
using Microsoft.EntityFrameworkCore;
using MvcGroup7.Data;

namespace MvcGroup7.Models
{
    public class FacilityRepo : IFacilityRepo
    {

        private ApplicationDbContext _database;

        public FacilityRepo(ApplicationDbContext database)
        {
            _database = database;

        }

        public List<Facility> GetAllFacillities()
        {
            List<Facility> facilities = _database.Facility.ToList();
            return facilities;
        }

        //public List<RecordedData> GetAllRecordedData()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Facility> GetAllRecordedData()
        //{
        //    List<Facility> allFacilities = _database.Facility.ToList();
        //    return allFacilities;
        //}

        

    }
}
