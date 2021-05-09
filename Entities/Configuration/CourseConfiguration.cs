using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Entities.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData
            (
                new Course
                {
                    CourseId = 1,
                    Description = "",
                    Type = "Core",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now

                }

            );
        }
    }
}