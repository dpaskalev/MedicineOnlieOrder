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
    public class Test_MedicineGetSearchViewModel
    {
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Medicine_GetAddModel")
                .Options;
            this.context = new ApplicationDbContext(options);
        }

        [Test]
        public void Test_GetSearchViewModel()
        {
            IMedicineService MedicineService = new MedicineService(this.context);

            Assert.IsNotNull(MedicineService.GetSearchViewModel().Result);
        }

        [TearDown]
        public void Cleanup()
        {
            context.Dispose();
        }
    }
}
