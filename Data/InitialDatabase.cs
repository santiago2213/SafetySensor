using LibraryGroup7;
using Microsoft.AspNetCore.Identity;

namespace MvcGroup7.Data
{
    public class InitialDatabase
    {

        public static void SeedDatabase(IServiceProvider services)
        {
            //1. Database service
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            //2 User manager service
            UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();

            //3 Roles service
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            string engineerRole = "Engineer";
            string itRole = "IT";
            string supervisorRole = "Supervisor";
          

            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(engineerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(itRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(supervisorRole);
                roleManager.CreateAsync(role).Wait();
            }


            if (!database.AppUser.Any())
            {
                AppUser appUser = new AppUser("Test Admin 1", "TestAdmin1@test.com", "3040000004", "Test.Admin1");
                userManager.CreateAsync(appUser).Wait();
                List<string> allRoles = new List<string>();
                allRoles.Add(engineerRole);
                allRoles.Add(supervisorRole);
                allRoles.Add(itRole);
                userManager.AddToRolesAsync(appUser, allRoles).Wait();
            }



            if (!database.Engineer.Any())
            {
                Engineer engineer =
                    new Engineer("Test Engineer 1", "Test.Engineer1@test.com", "3040000001", "Test.Engineer1");
                userManager.CreateAsync(engineer).Wait();
                userManager.AddToRoleAsync(engineer, engineerRole).Wait();

                Engineer engineer2 = new Engineer("Test Engineer 2", "Test.Engineer2@test.com", "3040000002", "Test.Engineer2");
                userManager.CreateAsync(engineer2).Wait();
                userManager.AddToRoleAsync(engineer2, engineerRole).Wait();

                Engineer engineer3 = new Engineer("Test Engineer 3", "Test.Engineer3@test.com", "3040000003", "Test.Engineer3");
                userManager.CreateAsync(engineer3).Wait();
                userManager.AddToRoleAsync(engineer3, engineerRole).Wait();

                Engineer engineer4 = new Engineer("Test Engineer 4", "Test.Engineer4@test.com", "3040000004", "Test.Engineer4");
                userManager.CreateAsync(engineer4).Wait();
                userManager.AddToRoleAsync(engineer4, engineerRole).Wait();

                Engineer engineer5 = new Engineer("Test Engineer 5", "Test.Engineer5@test.com", "3040000005", "Test.Engineer5");
                userManager.CreateAsync(engineer5).Wait();
                userManager.AddToRoleAsync(engineer5, engineerRole).Wait();

                Engineer engineer6 = new Engineer("Test Engineer 6", "Test.Engineer6@test.com", "3040000006", "Test.Engineer6");
                userManager.CreateAsync(engineer6).Wait();
                userManager.AddToRoleAsync(engineer6, engineerRole).Wait();

                Engineer engineer7 = new Engineer("Test Engineer 7", "Test.Engineer7@test.com", "3040000007", "Test.Engineer7");
                userManager.CreateAsync(engineer7).Wait();
                userManager.AddToRoleAsync(engineer7, engineerRole).Wait();

                Engineer engineer8 = new Engineer("Test Engineer 8", "Test.Engineer8@test.com", "3040000008", "Test.Engineer8");
                userManager.CreateAsync(engineer8).Wait();
                userManager.AddToRoleAsync(engineer8, engineerRole).Wait();

                Engineer engineer9 = new Engineer("Test Engineer 9", "Test.Engineer9@test.com", "3040000009", "Test.Engineer9");
                userManager.CreateAsync(engineer9).Wait();
                userManager.AddToRoleAsync(engineer9, engineerRole).Wait();

                Engineer engineer10 = new Engineer("Test Engineer 10", "Test.Engineer10@test.com", "3040000010", "Test.Engineer10");
                userManager.CreateAsync(engineer10).Wait();
                userManager.AddToRoleAsync(engineer10, engineerRole).Wait();

            }
            if (!database.Supervisor.Any())
            {
                Supervisor supervisor =
                    new Supervisor("Test Supervisor 1", "Test.Supervisor1@test.com", "3040000002", "Test.Supervisor1");
                userManager.CreateAsync(supervisor).Wait();
                userManager.AddToRoleAsync(supervisor, supervisorRole).Wait();

                Supervisor supervisor2 = new Supervisor("Test Supervisor 2", "Test.Supervisor2@test.com", "3040000003", "Test.Supervisor2");
                userManager.CreateAsync(supervisor2).Wait();
                userManager.AddToRoleAsync(supervisor2, supervisorRole).Wait();

                Supervisor supervisor3 = new Supervisor("Test Supervisor 3", "Test.Supervisor3@test.com", "3040000004", "Test.Supervisor3");
                userManager.CreateAsync(supervisor3).Wait();
                userManager.AddToRoleAsync(supervisor3, supervisorRole).Wait();

                Supervisor supervisor4 = new Supervisor("Test Supervisor 4", "Test.Supervisor4@test.com", "3040000005", "Test.Supervisor4");
                userManager.CreateAsync(supervisor4).Wait();
                userManager.AddToRoleAsync(supervisor4, supervisorRole).Wait();

                Supervisor supervisor5 = new Supervisor("Test Supervisor 5", "Test.Supervisor5@test.com", "3040000006", "Test.Supervisor5");
                userManager.CreateAsync(supervisor5).Wait();
                userManager.AddToRoleAsync(supervisor5, supervisorRole).Wait();

            }
            if (!database.IT.Any())
            {
                IT it = new IT("Test IT 1", "Test.IT1@test.com", "3040000003", "Test.IT1");
                userManager.CreateAsync(it).Wait();
                userManager.AddToRoleAsync(it, itRole).Wait();

                IT it2 = new IT("Test IT 2", "Test.IT2@test.com", "3040000004", "Test.IT2");
                userManager.CreateAsync(it2).Wait();
                userManager.AddToRoleAsync(it2, itRole).Wait();

                IT it3 = new IT("Test IT 3", "Test.IT3@test.com", "3040000005", "Test.IT3");
                userManager.CreateAsync(it3).Wait();
                userManager.AddToRoleAsync(it3, itRole).Wait();

                IT it4 = new IT("Test IT 4", "Test.IT4@test.com", "3040000006", "Test.IT4");
                userManager.CreateAsync(it4).Wait();
                userManager.AddToRoleAsync(it4, itRole).Wait();

                IT it5 = new IT("Test IT 5", "Test.IT5@test.com", "3040000007", "Test.IT5");
                userManager.CreateAsync(it5).Wait();
                userManager.AddToRoleAsync(it5, itRole).Wait();

            }
            if (!database.AppUser.Any())
            {
                AppUser appUser = new AppUser("Test Admin", "Test.Admin1@Test.com", "3045555555", "Test.Admin1");
                userManager.CreateAsync(appUser).Wait();

                List<string> allRoles = new List<string>();
                allRoles.Add(engineerRole);
                allRoles.Add(supervisorRole);
                allRoles.Add(itRole);
                userManager.AddToRolesAsync(appUser, allRoles).Wait();
            }

            if(!database.Facility.Any()) 
            {
                Facility facility = new Facility("Dupont");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("Chemours");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("Exxon");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("Chevron");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("ConocoPhillips");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("BP");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("Shell");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("Total");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("Eni");
                database.Facility.Add(facility);
                database.SaveChanges();

                facility = new Facility("Petrobras");
                database.Facility.Add(facility);
                database.SaveChanges();

            }

            if (!database.SensorLocation.Any())
            {
                SensorLocation sensorLocation = new SensorLocation("Lab A5", 1);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab A1", 1);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab A2", 2);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab A3", 3);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab A4", 4);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab B1", 5);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab B2", 6);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab B3", 7);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab B4", 8);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();

                sensorLocation = new SensorLocation("Lab B5", 9);
                database.SensorLocation.Add(sensorLocation);
                database.SaveChanges();


                //Talk to group members about if we now want to remove this since we now are only on a 1 factory scale isntead of multiple locations. Or leave it in reference of multiple Sensors in the same factory.
            }

            if (!database.RecordedData.Any()) //Is there any vehicle in this table? No!
            {
                DateTime recordedDataDate = new DateTime(2022, 12, 3);
                RecordedData recordedData = new RecordedData("Temperature", 95, 5, 1, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 4);
                recordedData = new RecordedData("Pressure", 95, 5, 1, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 5);
                recordedData = new RecordedData("Pressure", 35, 1, 1, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 6);
                recordedData = new RecordedData("Temperature", 75, 2, 2, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 7);
                recordedData = new RecordedData("Humidity", 95, 3, 3, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 8);
                recordedData = new RecordedData("Voltage", 12, 4, 4, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 9);
                recordedData = new RecordedData("Pressure", 30, 5, 5, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 10);
                recordedData = new RecordedData("Temperature", 80, 6, 6, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 11);
                recordedData = new RecordedData("Humidity", 60, 7, 7, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 12);
                recordedData = new RecordedData("Voltage", 13, 8, 8, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 13);
                recordedData = new RecordedData("Pressure", 40, 9, 9, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();

                recordedDataDate = new DateTime(2022, 12, 14);
                recordedData = new RecordedData("Temperature", 70, 10, 10, recordedDataDate);
                database.RecordedData.Add(recordedData);
                database.SaveChanges();


                
            }

            if (!database.SensorRepairRequest.Any())
            {

                DateTime dateServiceRequested = new DateTime(2022, 10, 5);
                DateTime dateServiced = new DateTime(2022, 10, 5);
                Engineer engineer = database.Engineer.Where(o => o.UserName == "Test.Engineer1@test.com").First();
                string engineerId = engineer.Id;
                SensorRepairRequest sensorRepairRequest = new SensorRepairRequest(dateServiceRequested, "Check sensor", engineerId, 1);
                database.SensorRepairRequest.Add(sensorRepairRequest);
                database.SaveChanges();

                DateTime dateServiceRequested1 = new DateTime(2022, 11, 6);
                DateTime dateServiced1 = new DateTime(2022, 11, 6);
                Engineer engineer1 = database.Engineer.Where(o => o.UserName == "Test.Engineer2@test.com").First();
                string engineerId1 = engineer1.Id;
                SensorRepairRequest sensorRepairRequest1 = new SensorRepairRequest(dateServiceRequested1, "Needs to be replaced", engineerId1, 1);
                database.SensorRepairRequest.Add(sensorRepairRequest1);
                database.SaveChanges();

                DateTime dateServiceRequested2 = new DateTime(2022, 12, 7);
                DateTime dateServiced2 = new DateTime(2022, 12, 7);
                Engineer engineer2 = database.Engineer.Where(o => o.UserName == "Test.Engineer3@test.com").First();
                string engineerId2 = engineer2.Id;
                SensorRepairRequest sensorRepairRequest2 = new SensorRepairRequest(dateServiceRequested2, "Damaged", engineerId, 1);
                database.SensorRepairRequest.Add(sensorRepairRequest2);
                database.SaveChanges();

                DateTime dateServiceRequested3 = new DateTime(2022, 01, 08);
                DateTime dateServiced3 = new DateTime(2022, 01, 08);
                Engineer engineer3 = database.Engineer.Where(o => o.UserName == "Test.Engineer4@test.com").First();
                string engineerId3 = engineer3.Id;
                SensorRepairRequest sensorRepairRequest3 = new SensorRepairRequest(dateServiceRequested3, "Not Responding", engineerId, 1);
                database.SensorRepairRequest.Add(sensorRepairRequest3);
                database.SaveChanges();

                DateTime dateServiceRequested4 = new DateTime(2022, 02, 09);
                DateTime dateServiced4 = new DateTime(2022, 02, 09);
                Engineer engineer4 = database.Engineer.Where(o => o.UserName == "Test.Engineer5@test.com").First();
                string engineerId4 = engineer4.Id;
                SensorRepairRequest sensorRepairRequest4 = new SensorRepairRequest(dateServiceRequested4, "Inaccurate readings", engineerId, 1 );
                database.SensorRepairRequest.Add(sensorRepairRequest4);
                database.SaveChanges();

                DateTime dateServiceRequested5 = new DateTime(2022, 03, 10);
                DateTime dateServiced5 = new DateTime(2022, 03, 10);
                Engineer engineer5 = database.Engineer.Where(o => o.UserName == "Test.Engineer6@test.com").First();
                string engineerId5 = engineer5.Id;
                SensorRepairRequest sensorRepairRequest5 = new SensorRepairRequest(dateServiceRequested5, "No readings", engineerId, 1);
                database.SensorRepairRequest.Add(sensorRepairRequest5);
                database.SaveChanges();

            }

            

            

        }
    }

}
