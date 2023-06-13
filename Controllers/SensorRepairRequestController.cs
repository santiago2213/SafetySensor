using LibraryGroup7;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcGroup7.Migrations;
using MvcGroup7.Models;
using MvcGroup7.ViewModels;
using System.Runtime.CompilerServices;

namespace MvcGroup7.Controllers
{
    public class SensorRepairRequestController : Controller
    {
        private ISensorRepairRequestRepo _sensorRepairRequestRepo;
        private IAppUserRepo _appUserRepo;
        //private IFacilityRepo _facilityRepo;
        

        public SensorRepairRequestController(ISensorRepairRequestRepo sensorRepairRequestRepo, IAppUserRepo appUserRepo)
        {
            _sensorRepairRequestRepo = sensorRepairRequestRepo;
            _appUserRepo = appUserRepo;
            //_facilityRepo = facilityRepo;
            
        }
        /*
        public void CreateDropDownLists()
        {

            List<Facility> allFacilities = _facilityRepo.GetAllFacillities();

           
            ViewData["AllFacilities"] = new SelectList(allFacilities, "FacilityID", "FacilityName");
        }
        */
        public void CreateDropDownLists()
        {
            ViewData["allEngineers"] = new SelectList(_appUserRepo.GetAllEngineers(), "Id", "Fullname");
            ViewData["allSensorLocations"] = new SelectList(_sensorRepairRequestRepo.GetAllLocations(), "SensorLocationID", "LocationName");
        }

        [HttpGet]
        public IActionResult AddSensorRepairRequest()
        {
            CreateDropDownLists();

           

            /*
            List<SensorLocation> allSensorLocations = _sensorRepairRequestRepo.GetAllSensorLocations();

            ViewData["AllSensorLocations"] = new SelectList(allSensorLocations, "SensorLocationID", "LocationName");
            */
            return View();
        }

        [HttpPost]

        
        public IActionResult AddSensorRepairRequest(AddSensorRepairRequestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SensorRepairRequest sensorRepairRequest = new SensorRepairRequest(viewModel.DateSensorRepairRequested.Value, viewModel.Description,viewModel.EngineerId, viewModel.SensorLocationID.Value);

                int SensorRepairRequestId = _sensorRepairRequestRepo.AddSensorRepairRequest(sensorRepairRequest);



                return RedirectToAction("SearchSensorRepairRequest");
            }

            else 
            {
                CreateDropDownLists();
                return View(viewModel); 
            }

        }
        [HttpGet]

        public IActionResult SearchSensorRepairRequest()
        {
            CreateDropDownLists();
            SearchSensorRepairRequestsViewModel vm = new SearchSensorRepairRequestsViewModel();
            return View(vm);

        }

        [HttpPost]

        public IActionResult SearchSensorRepairRequest(SearchSensorRepairRequestsViewModel viewModel)
        {
            List<SensorRepairRequest> allSensorRepairRequests = _sensorRepairRequestRepo.GetAllSensorRepairRequests();
            CreateDropDownLists();
            //a = a + b

            if (viewModel.SearchDate != null)
            {
                allSensorRepairRequests = allSensorRepairRequests.Where(sr => sr.DateSensorRepairRequested <= viewModel.SearchDate).ToList();
            }
            if (viewModel.SearchEngineerFullName != null)
            {
                allSensorRepairRequests = allSensorRepairRequests.Where(a => a.Engineer.Id == viewModel.SearchEngineerFullName).ToList();
            }
            //if (searchSensorLocation != null)
            //{
            //    allSensorRepairRequests = allSensorRepairRequests.Where(sr => sr.SensorLocation.LocationName == searchSensorLocation && sr.DateSensorRepaired != null).ToList();
            //}
            //if (!string.IsNullOrEmpty(searchIT))
            //{
            //    allSensorRepairRequests = allSensorRepairRequests.Where(a => a.SensorRepairRequestNotes.Any(srn => srn.IT != null && srn.IT.Fullname == searchIT)).ToList();
            //}
            viewModel.SensorRepairRequests = allSensorRepairRequests;
            return View(viewModel);
        }





    }
}
