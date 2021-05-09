using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasData
            (
                new Organization
                {
                    OrgId = 1,
                    OrgName = "NJIT",
                    OrgType = "Public",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                }

            ) ;
        }
    }
}