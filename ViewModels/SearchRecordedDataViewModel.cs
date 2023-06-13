using LibraryGroup7;
using System.ComponentModel.DataAnnotations;

namespace MvcGroup7.ViewModels
{
    public class SearchRecordedDataViewModel
    {
        [DataType(DataType.Date)]           //Creates calendar in UI
        public DateTime? SearchRecordedDataDate { get; set; }
        public string? SearchDataType { get; set; }
        public int? SearchDataValue { get; set; }
        public int? FacilityID { get; set; }
        public DateTime? SearchRecordedDataStartDate { get; set; }
        public DateTime? SearchRecordedDataEndDate { get; set; }

        //public int? SearchTime { get; set; }


        public List<RecordedData> SearchResult { get; set; }

    }
}
