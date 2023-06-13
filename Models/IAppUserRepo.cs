using LibraryGroup7;

namespace MvcGroup7.Models
{
    public interface IAppUserRepo
    {
        public List<Engineer> GetAllEngineers();
        //public string GetUserId();
    }
}
