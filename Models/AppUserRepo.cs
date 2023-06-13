using LibraryGroup7;
using MvcGroup7.Data;
using System.Security.Claims;

namespace MvcGroup7.Models
{
    public class AppUserRepo : IAppUserRepo
    {
        private ApplicationDbContext _database;
        private IHttpContextAccessor _contextAccessor;

        public AppUserRepo(ApplicationDbContext database)
        {
            _database = database;

        }
        public List<Engineer> GetAllEngineers()
        {
            List<Engineer> allEngineers = _database.Engineer.ToList();
            return allEngineers;
        }

        //public string GetUserId()
        //{
        //    string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    return userId;
        //}
    }
}
