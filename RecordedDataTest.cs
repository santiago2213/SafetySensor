using Moq;
using LibraryGroup7;
using MvcGroup7.Controllers;
using MvcGroup7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics;
using MvcGroup7.ViewModels;

namespace TestGroup7
{
    public class RecordedDataTest
    {
        [Fact]
        public void ShouldSearchForRecordedDataByTemperatureandDate()
        {
            Mock<IRecordedDataRepo> mockRecordedDataRepo = new Mock<IRecordedDataRepo>();

            Mock<IFacilityRepo> mockIFacilityRepo = new Mock<IFacilityRepo>();

            Mock<IAppUserRepo> mockIAppUserRepo = new Mock<IAppUserRepo>(); 

            List<RecordedData> mockRecordedData = CreateMockData();

            mockRecordedDataRepo.Setup(m => m.GetAllRecordedData()).Returns(mockRecordedData);
            List<Facility> mockFacility = CreateMockFacility();
            mockIFacilityRepo.Setup(a => a.GetAllFacillities()).Returns(mockFacility);

            int expectedNumberOfRecordedData = 1;

            RecordedDataController recordedDataController = new RecordedDataController(mockRecordedDataRepo.Object, mockIFacilityRepo.Object, mockIAppUserRepo.Object);

            // int? inputSearchTemperature = 95;
            //int? inputSearchPressure = 20;
            // ViewResult viewResult = recordedDataController.SearchRecordedData(inputSearchTemperature, inputSearchPressure) as ViewResult; // "=" assignment operator

            SearchRecordedDataViewModel viewModel = new SearchRecordedDataViewModel
            {
                SearchDataType = "Temperature",
                SearchDataValue = 90,
                
                SearchRecordedDataDate = new DateTime(2022, 7, 10)

            };

            ViewResult viewResult = recordedDataController.SearchRecordedData(viewModel) as ViewResult;
            SearchRecordedDataViewModel resultModel = viewResult.Model as SearchRecordedDataViewModel;

            List<RecordedData> actualResultList = resultModel.SearchResult;

            int actualNumberOfRecordedData = actualResultList.Count;

            Assert.Equal(expectedNumberOfRecordedData, actualNumberOfRecordedData);
        }

        [Fact]
        public void ShouldSearchForRecordedDataByTemperature()
        {
            Mock<IRecordedDataRepo> mockRecordedDataRepo = new Mock<IRecordedDataRepo>();
            Mock<IFacilityRepo> mockIFacilityRepo = new Mock<IFacilityRepo>();
            Mock<IAppUserRepo> mockIAppUserRepo = new Mock<IAppUserRepo>();
            List<RecordedData> mockRecordedData = CreateMockData();
            mockRecordedDataRepo.Setup(m => m.GetAllRecordedData()).Returns(mockRecordedData);
            List<Facility> mockFacility = CreateMockFacility();
            mockIFacilityRepo.Setup(a => a.GetAllFacillities()).Returns(mockFacility);

            int expectedNumberOfRecordedData = 1;

            RecordedDataController recordedDataController = new RecordedDataController(mockRecordedDataRepo.Object, mockIFacilityRepo.Object, mockIAppUserRepo.Object);

            SearchRecordedDataViewModel viewModel = new SearchRecordedDataViewModel
            {
                SearchDataType = "Temperature",
                SearchDataValue = 90,
                SearchRecordedDataDate = null
              

            };

            ViewResult viewResult = recordedDataController.SearchRecordedData(viewModel) as ViewResult;
            SearchRecordedDataViewModel resultModel = viewResult.Model as SearchRecordedDataViewModel;

            List<RecordedData> actualResultList = resultModel.SearchResult;

            int actualNumberOfRecordedData = actualResultList.Count;

            Assert.Equal(expectedNumberOfRecordedData, actualNumberOfRecordedData);
        }

        [Fact]
        public void ShouldSearchForRecordedDataByPressure()
        {
            Mock<IRecordedDataRepo> mockRecordedDataRepo = new Mock<IRecordedDataRepo>();
            Mock<IFacilityRepo> mockIFacilityRepo = new Mock<IFacilityRepo>();
            Mock<IAppUserRepo> mockIAppUserRepo = new Mock<IAppUserRepo>();
            List<RecordedData> mockRecordedData = CreateMockData();
            mockRecordedDataRepo.Setup(m => m.GetAllRecordedData()).Returns(mockRecordedData);
            List<Facility> mockFacility = CreateMockFacility();
            mockIFacilityRepo.Setup(a => a.GetAllFacillities()).Returns(mockFacility);
            int expectedNumberOfRecordedData = 3;

            RecordedDataController recordedDataController = new RecordedDataController(mockRecordedDataRepo.Object, mockIFacilityRepo.Object, mockIAppUserRepo.Object);

            SearchRecordedDataViewModel viewModel = new SearchRecordedDataViewModel
            {
                SearchDataType = "Pressure",
                SearchDataValue = null,
                SearchRecordedDataDate = null,
               FacilityID = null
                
               


            };

            ViewResult viewResult = recordedDataController.SearchRecordedData(viewModel) as ViewResult;
            SearchRecordedDataViewModel resultModel = viewResult.Model as SearchRecordedDataViewModel;

            List<RecordedData> actualResultList = resultModel.SearchResult;

            int actualNumberOfRecordedData = actualResultList.Count;

            Assert.Equal(expectedNumberOfRecordedData, actualNumberOfRecordedData);


        }



        [Fact]
        public void ShouldSearchForRecordedDateByTime()
        {
            Mock<IRecordedDataRepo> mockRecordedDataRepo = new Mock<IRecordedDataRepo>();
            Mock<IFacilityRepo> mockIFacilityRepo = new Mock<IFacilityRepo>();
            Mock<IAppUserRepo> mockIAppUserRepo = new Mock<IAppUserRepo>();
            List<Facility> mockFacility = CreateMockFacility();
            mockIFacilityRepo.Setup(a => a.GetAllFacillities()).Returns(mockFacility);

            List<RecordedData> mockRecordedData = CreateMockData();
            mockRecordedDataRepo.Setup(m => m.GetAllRecordedData()).Returns(mockRecordedData);

            int expectedNumberOfRecordedData = 2;

            RecordedDataController recordedDataController = new RecordedDataController(mockRecordedDataRepo.Object, mockIFacilityRepo.Object, mockIAppUserRepo.Object);

            SearchRecordedDataViewModel viewModel = new SearchRecordedDataViewModel
            {
                SearchDataType = null,
                SearchDataValue = null,
                SearchRecordedDataDate = new DateTime(2019, 7, 9)

            };

            ViewResult viewResult = recordedDataController.SearchRecordedData(viewModel) as ViewResult;
            SearchRecordedDataViewModel resultModel = viewResult.Model as SearchRecordedDataViewModel;

            List<RecordedData> actualResultList = resultModel.SearchResult;

            int actualNumberOfRecordedData = actualResultList.Count;

            Assert.Equal(expectedNumberOfRecordedData, actualNumberOfRecordedData);
        }

        public List<Facility> CreateMockFacility()
        {
            List<Facility> mockFacility = new List<Facility>();
            Facility facility = new Facility { FacilityID = 1, FacilityName= "Test1" };
            mockFacility.Add(facility);
            facility = new Facility { FacilityID = 2, FacilityName = "Test2" };
            mockFacility.Add(facility);

            return mockFacility;
        }
   

        public List<RecordedData> CreateMockData()
        {
            List<RecordedData> mockData = new List<RecordedData>();
            RecordedData recordedData = new RecordedData { RecordedDataID = 1,RecordedDataType = "Temperature", RecordedDataValue = 90, RecordedDataDate = new DateTime(2022, 7, 10) };
            mockData.Add(recordedData);

            recordedData = new RecordedData { RecordedDataID = 2, RecordedDataType = "Temperature", RecordedDataValue = 98, RecordedDataDate = new DateTime(2022, 8, 15) };
            mockData.Add(recordedData);

            recordedData = new RecordedData { RecordedDataID = 3, RecordedDataType = "Temperature" , RecordedDataValue = 101, RecordedDataDate = new DateTime(2019, 7, 9) };
            mockData.Add(recordedData);

            recordedData = new RecordedData { RecordedDataID = 4, RecordedDataType = "Pressure", RecordedDataValue = 20, RecordedDataDate = new DateTime(2019, 7, 9) };
            mockData.Add(recordedData);

            recordedData = new RecordedData { RecordedDataID = 5, RecordedDataType = "Pressure", RecordedDataValue = 25, RecordedDataDate = new DateTime(2019, 5, 17) };
            mockData.Add(recordedData);

            recordedData = new RecordedData { RecordedDataID = 6, RecordedDataType = "Pressure", RecordedDataValue = 15, RecordedDataDate = new DateTime(2019, 1, 19) };
            mockData.Add(recordedData);

            return mockData;
        }



    }
}