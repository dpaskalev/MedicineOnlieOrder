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
using MedicineOnlieOrder.VewModels;


namespace Tests
{
    [TestFixture]
    public class Test_MEdicineGetSearchResult
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

            context.AddRange(
                new Medicine
                {
                    Id = 1,
                    MedicineName = "TestMed_1",
                    ExperationDate = DateTime.Today,
                    Price = 100,
                    Description = "Caution",
                    MedicineTypeId = 1,
                    UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    IsDeleted = false
                },

                new Medicine
                {
                    Id = 2,
                    MedicineName = "TestMed_2",
                    ExperationDate = DateTime.Today,
                    Price = 200,
                    Description = "Caution",
                    MedicineTypeId = 2,
                    UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    IsDeleted = false
                },

                new Medicine
                {
                    Id = 3,
                    MedicineName = "TestMed_3",
                    ExperationDate = DateTime.Today,
                    Price = 100,
                    Description = "Caution",
                    MedicineTypeId = 3,
                    UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    IsDeleted = false
                }
            );
            context.SaveChanges();

            context.AddRange(
            new IdentityUser
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
            });
            context.SaveChanges();
        }

        [Test]
        public void Test_GetSearchResult()
        {
            IMedicineService MedicineService = new MedicineService(this.context);

            MedicineSearchViewModel SearchViewModel = new MedicineSearchViewModel
            {
                Name = "TestMed_3"
            };

            var result = MedicineService.GetSearchResultAsync(SearchViewModel, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd").Result;

            Assert.IsNotNull(result);
            Assert.True(result.First().Name == "TestMed_3");
        }

        [TearDown]
        public void Cleanup()
        {
            context.Dispose();
        }
    }
}
