using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasData
            (
                new Submission
                {
                    SubmissionId = 1,
                    SubmissionName = "",
                    Comments = "",
                    Grade = 0,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now

                }
            );
        }
    }
}
