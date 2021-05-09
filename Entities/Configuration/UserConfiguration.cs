using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    UserId = 1,
                    UserName = "rfebres",
                    Email = "rf57@njit.edu",
                    FirstName = "Richard",
                    LastName = "Febres",
                    PhoneNumber = "201-923-3911",
                    OrganizationId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                }
            ) ;
        }
    }
}