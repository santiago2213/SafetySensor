using Microsoft.AspNetCore.Mvc;
using LibraryGroup7;
using MvcGroup7.Models;
using MvcGroup7.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcGroup7.Controllers
{
    public class RecordedDataController : Controller
    {

            //Injecting IVehicleRepo into VehicleController
            //Instance Variable
            private IRecordedDataRepo _recordedDataRepo;
            private IFacilityRepo _facilityRepo;
            private IAppUserRepo _appUserRepo;
            
            


        public RecordedDataController(IRecordedDataRepo recordedDataRepo, IFacilityRepo facilityRepo, IAppUserRepo appUserRepo)
        {
            _recordedDataRepo = recordedDataRepo;
            _facilityRepo = facilityRepo;
            _appUserRepo = appUserRepo;
        }
       

        public void CreateDropDownLists()
        {
            List<RecordedData> allRecordedData = _recordedDataRepo.GetAllRecordedData();

            List<Facility> allFacilities = _facilityRepo.GetAllFacillities();

            //var allFacilities = allFacilities.Select(v => v.SensorLocation.Facility.FacilityName).Distinct().ToList();

            var allDataTypes = allRecordedData.Select(v => v.RecordedDataType).Distinct().ToList();

            //List<SelectListItem> listOfAllFacilities =
            //.Where(eachFacility => eachFacility != null)
            //.Select(eachFacility => new SelectListItem { Text = eachFacility.ToString(), Value = eachFacility.ToString() })
            //.ToList();

            ViewData["AllFacilities"] = new SelectList(allFacilities, "FacilityID", "FacilityName");
            ViewData["AllDataTypes"] = new SelectList(allDataTypes, "RecordedDataType");

        }
        [HttpGet]
        public IActionResult AddRecordedData()
        {
            List<RecordedData> allRecordedData = _recordedDataRepo.GetAllRecordedData();
            List<SensorLocation> allSensorLocations = _recordedDataRepo.GetSensorLocations();
            ViewData["AllSensorLocations"] = new SelectList(allSensorLocations, "SensorLocationID", "LocationName");
            var allDataTypes = allRecordedData.Select(v => v.RecordedDataType).Distinct().ToList();
            ViewData["AllDataTypes"] = new SelectList(allDataTypes, "RecordedDataType");
            return View();

        }
        [HttpPost]
        public IActionResult AddRecordedData(AddRecordedDataViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                RecordedData recordedData = new RecordedData(viewModel.RecordedDataType, viewModel.RecordedDataValue, viewModel.Time, viewModel.SensorLocationID, viewModel.RecordedDate);
                int recordedDataId = _recordedDataRepo.AddRecordedData(recordedData);

                return RedirectToAction ("SearchRecordedData");
            }
            else{ return View(viewModel); }
            
        }


        [HttpGet]
        public IActionResult SearchRecordedData()
        {
            CreateDropDownLists();
            SearchRecordedDataViewModel viewModel = new SearchRecordedDataViewModel();
            return View(viewModel);


        }

        [HttpPost]
           
            public IActionResult SearchRecordedData(SearchRecordedDataViewModel viewModel)
            {
            /*
             public IActionResult SearchRecordedData(int? searchTemperature = null, int? searchPressure = null, DateTime? recordedDataDate = null, int? searchFacilityId = null)   //parameters
            */
                CreateDropDownLists();
                List<RecordedData> allRecordedData = _recordedDataRepo.GetAllRecordedData();
            //a = a + b

                if (viewModel.SearchDataType != null)
                {
                    allRecordedData = allRecordedData.Where(a => a.RecordedDataType == viewModel.SearchDataType).ToList();
                }

                if (viewModel.SearchRecordedDataDate != null)
                {
                    allRecordedData = allRecordedData.Where(a => a.RecordedDataDate == viewModel.SearchRecordedDataDate).ToList();
                }

                if (viewModel.SearchDataValue != null)
                {
                    allRecordedData = allRecordedData.Where(a => a.RecordedDataValue == viewModel.SearchDataValue).ToList();
                }

                if (viewModel.FacilityID != null)
                {
                    allRecordedData = allRecordedData.Where(a => a.SensorLocation.Facility.FacilityID == viewModel.FacilityID).ToList();
                }

                if (viewModel.SearchRecordedDataStartDate != null && viewModel.SearchRecordedDataEndDate != null)
                {
                     allRecordedData = allRecordedData.Where(a => a.RecordedDataDate >= viewModel.SearchRecordedDataStartDate && a.RecordedDataDate <= viewModel.SearchRecordedDataEndDate).ToList();
                }

            /*
            if (viewModel.SearchFacilityId != null)
            {
                allRecordedData = allRecordedData.Where(a => a.FacilityId >= searchFacilityId).ToList();
            }
            */
                viewModel.SearchResult = allRecordedData;
                return View(viewModel);


            }


        [HttpGet]
        public IActionResult AddSensorLocation()
        {
            CreateDropDownLists();
            return View();
        }

        [HttpPost]
        public IActionResult AddSensorLocation(AddSensorLocationViewModel viewModel)
        {
            //string engineerId = _appUserRepo.GetUserId();

            if (ModelState.IsValid)
            {
                SensorLocation sensorLocation = new SensorLocation(viewModel.LocationName, viewModel.FacilityID);

                int sensorLocationID = _recordedDataRepo.AddSensorLocation(sensorLocation);
                if (sensorLocationID == -1)
                {
                    ModelState.AddModelError("Sensor Location Repeated Error", "Sensor Location Can Not Be Repeated");
                    CreateDropDownLists();
                    return View(viewModel);
                }

                return RedirectToAction("SearchRecordedData");
            }
            else
            {
                CreateDropDownLists();
                return View(viewModel);
            }

            
        }

         


    }
}
