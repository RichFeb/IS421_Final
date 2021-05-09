using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Entities.Configuration
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasData
            (
                new Assignment
                {
                    AssignmentId = 1,
                    AssignmentName = "",
                    Description = "",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now


                }

            ) ;
        }
    }
}