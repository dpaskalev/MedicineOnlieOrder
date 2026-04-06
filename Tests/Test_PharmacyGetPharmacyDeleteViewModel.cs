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
    public class Test_PharmacyGetPharmacyDeleteViewModel
    {
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB_Pharmacy_1")
                .Options;
            this.context = new ApplicationDbContext(options);

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

            context.AddRange(
                new Pharmacy
                {
                    Id = 1,
                    Name = "TestPharmacy_1",
                    Loctaion = "Suhata_Reka",
                    UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    IsDeleted = false
                },

                new Pharmacy
                {
                    Id = 2,
                    Name = "TestPharmacy_2",
                    Loctaion = "Suhata_Reka",
                    UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    IsDeleted = false
                },

                new Pharmacy
                {
                    Id = 3,
                    Name = "TestPharmacy_3",
                    Loctaion = "Suhata_Reka",
                    UserId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    IsDeleted = false
                }
            );
            context.SaveChanges();
        }

        [Test]
        public void Test_GetPharmacyDeleteViewModel()
        {
            IPharmacyService service = new PharmacyService(this.context);

            int id = 3;
            var result = service.GetPharmacyDeleteViewModel(id, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd").Result;

            Assert.NotNull(result);

            Cleanup();
        }

        [TearDown]
        public void Cleanup()
        {
            context.Dispose();
        }
    }
}
