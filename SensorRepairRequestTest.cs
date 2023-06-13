using LibraryGroup7;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcGroup7.Controllers;
using MvcGroup7.Models;
using MvcGroup7.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGroup7
{
    public class SensorRepairRequestTest
    {
        [Fact]
        public void ShouldSearchForCompletedSensorRepairRequestsByLocation()
        {
            Mock<ISensorRepairRequestRepo> mockSensorRepairRequestRepo = new Mock<ISensorRepairRequestRepo>();
            Mock<IAppUserRepo> mockAppUserRepo = new Mock<IAppUserRepo>();

            List<SensorRepairRequest> mockSensorRepairRequestData = CreateMockData();
            mockSensorRepairRequestRepo.Setup(m => m.GetAllSensorRepairRequests()).Returns(mockSensorRepairRequestData);

            int expectedNumberOfServiceRequests = 1;

            SensorRepairRequestController sensorRepairRequestController = new SensorRepairRequestController(mockSensorRepairRequestRepo.Object, mockAppUserRepo.Object);

            string inputSearchLocation = "Lab 1";
            SearchSensorRepairRequestsViewModel viewModel = new SearchSensorRepairRequestsViewModel { SearchDate = null, SearchEngineerFullName = null };

            ViewResult viewResult = sensorRepairRequestController.SearchSensorRepairRequest(viewModel) as ViewResult;

            List<SensorRepairRequest> actualResultList = viewResult.Model as List<SensorRepairRequest>;

            int actualNumberOfServiceRequests = actualResultList.Count;

            Assert.Equal(expectedNumberOfServiceRequests, actualNumberOfServiceRequests);
        }

        [Fact]
        public void ShouldSearchForRepairRequestWithNotes()
        {
            Mock<ISensorRepairRequestRepo> mockSensorRepairRequestRepo = new Mock<ISensorRepairRequestRepo>();
            Mock<IAppUserRepo> mockAppUserRepo = new Mock<IAppUserRepo>();

            List<SensorRepairRequest> mockSensorRepairRequestData = CreateMockData();
            mockSensorRepairRequestRepo.Setup(m => m.GetAllSensorRepairRequests()).Returns(mockSensorRepairRequestData);

            int expectedNumberOfReapirRequests = 1;

            SensorRepairRequestController sensorRepairRequestController = new SensorRepairRequestController(mockSensorRepairRequestRepo.Object, mockAppUserRepo.Object);

            string inputITFullName = "IT 1";
            SearchSensorRepairRequestsViewModel viewModel = new SearchSensorRepairRequestsViewModel { SearchDate = null, SearchEngineerFullName = null };

            ViewResult viewResult = sensorRepairRequestController.SearchSensorRepairRequest(viewModel) as ViewResult;

            List<SensorRepairRequest> actualResultList = viewResult.Model as List<SensorRepairRequest>;

            int actualNumberOfServiceRequests = actualResultList.Count;

            Assert.Equal(expectedNumberOfReapirRequests, actualNumberOfServiceRequests);


        }









        public List<SensorRepairRequest> CreateMockData()
        {
            List<SensorRepairRequest> mockData = new List<SensorRepairRequest>();

            List<Notes> mockNotes = new List<Notes>();
            string description = "Check fuse";
            string locationName = "Lab 1";
            string engineerName = "Engineer 1";
            DateTime dateSensorRepairRequested = new DateTime(2022, 10, 31);
            string supervisorName = "Supervisor 1";
            DateTime dateDecided = new DateTime(2022, 10, 31);
            string itName = "IT 1";
            DateTime dateSensorRepaired = new DateTime(2022, 11, 1);
            SensorLocation sensorLocation = new SensorLocation { LocationName = locationName};
            Engineer engineer = new Engineer { Fullname = engineerName};
            IT it = new IT { Fullname = itName};
            Supervisor supervisor = new Supervisor { Fullname = supervisorName };
            SensorRepairRequest sensorRepairRequest = new SensorRepairRequest { DateSensorRepairRequested = dateSensorRepairRequested, DateSensorRepaired = dateSensorRepaired, Engineer = engineer, IT = it, Supervisor = supervisor, SensorLocation = sensorLocation };

            Notes notes = new Notes{SensorRepairRequest = sensorRepairRequest, Description="Needs new fuse", NoteCreated = new DateTime(2022, 11, 1), IT=it };
            mockNotes.Add(notes);

            notes = new Notes{SensorRepairRequest = sensorRepairRequest, Description = "Change fuse", NoteCreated = new DateTime(2022, 11, 2), Supervisor = supervisor };
            mockNotes.Add(notes);

            sensorRepairRequest.SensorRepairRequestNotes = mockNotes;

            mockData.Add(sensorRepairRequest);


            description = "Check wires";
            locationName = "Lab 1";
            engineerName = "Engineer 1";
            dateSensorRepairRequested = new DateTime(2022, 11, 3);
            supervisorName = "Supervisor 1";
            dateDecided = new DateTime(2022, 11, 4);
            sensorLocation = new SensorLocation { LocationName = locationName };
            engineer = new Engineer { Fullname = engineerName };
            it = new IT { Fullname = itName };
            supervisor = new Supervisor { Fullname = supervisorName };
            sensorRepairRequest = new SensorRepairRequest { DateSensorRepairRequested = dateSensorRepairRequested, Engineer = engineer, Supervisor = supervisor, SensorLocation = sensorLocation };
            mockData.Add(sensorRepairRequest);

            description = "Replace Sensor";
            locationName = "Lab 2";
            engineerName = "Engineer 2";
            dateSensorRepairRequested = new DateTime(2022, 11, 5);
            supervisorName = "Supervisor 2";
            itName = "IT 1";
            dateDecided = new DateTime(2022, 11, 6);
            sensorLocation = new SensorLocation { LocationName = locationName };
            engineer = new Engineer { Fullname = engineerName };
            it = new IT { Fullname = itName };
            supervisor = new Supervisor { Fullname = supervisorName };
            sensorRepairRequest = new SensorRepairRequest { DateSensorRepairRequested = dateSensorRepairRequested, Engineer = engineer, Supervisor = supervisor, IT = it, SensorLocation = sensorLocation };
            mockData.Add(sensorRepairRequest);


            return mockData;

        }

    }
}
