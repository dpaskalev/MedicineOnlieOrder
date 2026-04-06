using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataModels.Data.DataModels;
using DataModels.Data;
using Services.Services.Interfaces;
using Services.Services;
using Microsoft.AspNetCore.Identity;


namespace Tests
{
    [TestFixture]
    public class Test_Medicine_GetAddModel
    {
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Medicine_GetAddModel_2")
                .Options;
            this.context = new ApplicationDbContext(options);

            context.AddRange(
                new MedicineType { Id = 1, MedicineTypeName = "Pill" },
                new MedicineType { Id = 2, MedicineTypeName = "Syringe" },
                new MedicineType { Id = 3, MedicineTypeName = "Syrup" },
                new MedicineType { Id = 4, MedicineTypeName = "Powder" },
                new MedicineType { Id = 5, MedicineTypeName = "Liquid" }
                );
            context.SaveChanges();


        }

        [Test]
        public void Test_GetIndexMethod()
        {
            IMedicineService MedicineService = new MedicineService(this.context);
            var result = MedicineService.GetAddModelAsynk();

            Assert.True(result != null);
        }

        [TearDown]
        public void Cleanup()
        {
            context.Dispose();
        }
    }
}
