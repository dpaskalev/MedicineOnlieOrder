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
using Services.VewModels;


namespace Tests
{
    [TestFixture]
    public class Tes_MEdicine_AddMedicine
    {
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Medicine_GetAddModel")
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

            var TestUser = new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@gmail.com" },
                    "123456!")
            };
            context.SaveChanges();

            context.AddRange(
                new Medicine
                {
                    Id = 1,
                    MedicineName = "Med_1",
                    ExperationDate = DateTime.Today,
                    Price = 100,
                    Description = "Caution",
                    MedicineTypeId = 1,
                    UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    IsDeleted = false
                });

            context.SaveChanges();
        }

        [Test]
        public void Test_GetIndexMethod()
        {
            IMedicineService MedicineService = new MedicineService(this.context);

            MedicineViewModel viewModel = new MedicineViewModel
            {
                Name = "MEd_1",
                ExperationDate = DateTime.Today,
                Price = 100,
                Description = "TestMedicine_1",
                ImageURL = null,
                Type = 1
            };

            MedicineService.AddMedicineAsync(viewModel, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");

            var result = MedicineService.GetIndex("df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");

            Assert.True(result.Result.Count() == 2);
        }

        [TearDown]
        public void Cleanup()
        {
            context.Dispose();
        }
    }
}
