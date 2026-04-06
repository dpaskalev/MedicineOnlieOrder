using NUnit.Framework;
using DataModels;
using Services;
using Microsoft.EntityFrameworkCore;
using DataModels.Data.DataModels;
using DataModels.Data;
using Services.Services.Interfaces;
using Services.Services;
using Microsoft.AspNetCore.Identity;

namespace Tests
{
    [TestFixture]
    public class Test_MedicineGetIndexFunction
    {
        private IEnumerable<Medicine> medicines;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            this.medicines = new List<Medicine>()
            {
                new Medicine() { Id = 1, MedicineName = "TestMedicine_1", ExperationDate = DateTime.Now, Price = 10, Description = "TestMedicine_1", MedicineTypeId = 1, ImageURL = null, UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", IsDeleted = false },
                new Medicine() { Id = 2, MedicineName = "TestMedicine_2", ExperationDate = DateTime.Now, Price = 20, Description = "TestMedicine_1", MedicineTypeId = 2, ImageURL = null, UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", IsDeleted = false },
                new Medicine() { Id = 3, MedicineName = "TestMedicine_3", ExperationDate = DateTime.Now, Price = 30, Description = "TestMedicine_1", MedicineTypeId = 3, ImageURL = null, UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", IsDeleted = false }
            };

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

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Medicine")
                .Options;
            this.context = new ApplicationDbContext(options);
            context.AddRange(medicines);
            context.SaveChanges();

            context.AddRange(
                new MedicineType { Id = 1, MedicineTypeName = "Pill" },
                new MedicineType { Id = 2, MedicineTypeName = "Syringe" },
                new MedicineType { Id = 3, MedicineTypeName = "Syrup" },
                new MedicineType { Id = 4, MedicineTypeName = "Powder" },
                new MedicineType { Id = 5, MedicineTypeName = "Liquid" }
                );
            context.SaveChanges();

            context.AddRange(TestUser);
            context.SaveChanges();
        }

        [Test]
        public void Test_GetIndexMethod()
        {
            IMedicineService MedicineService = new MedicineService(this.context);
            var result = MedicineService.GetIndex("df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");

            Assert.True(result != null);
            Assert.True(result.Result.Count() == 3);
        }

        [TearDown]
        public void Cleanup()
        {
            context.Dispose();
        }
    }
}