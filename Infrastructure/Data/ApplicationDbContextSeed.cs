using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuneralType>().HasData(
                new FuneralType { Id = new Guid("01dd3472-4837-4934-8f6c-c350af361b8b"), Description = "Burial" },
                new FuneralType { Id = new Guid("7d38792f-e84c-4a19-a1c5-b9047be50885"), Description = "Cremation" }
            );
            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { Id = new Guid("633976ac-1367-42cc-812e-cbfcbbefc789"), Description = "Married" },
                new MaritalStatus { Id = new Guid("f01436ec-ef7b-4ec0-bb58-58c5ce6932d8"), Description = "Civil Partnership" },
                new MaritalStatus { Id = new Guid("b2d98283-9bb5-4fcf-a584-2728c4c7c757"), Description = "Single" },
                new MaritalStatus { Id = new Guid("7cd83800-507f-4160-a216-a6d92fd1edb6"), Description = "Divorced" },
                new MaritalStatus { Id = new Guid("97acd8f0-e48a-4adf-8957-0f869f64a587"), Description = "Separated" },
                new MaritalStatus { Id = new Guid("cfa9cd37-2267-4b9d-ae41-eb88c8e89881"), Description = "Widowed" }
            );
        }
    }
}
