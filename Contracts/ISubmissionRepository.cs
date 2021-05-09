using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ISubmissionRepository
    {
        IEnumerable<Submission> GetAllSubmissions(bool trackChanges);
        Submission GetSubmission(int Id, bool trackChanges);
        IEnumerable<Submission> GetByIds(IEnumerable<int> ids, bool trackChanges);
        void CreateSubmission(Submission submission);

        void DeleteSubmission(Submission submission);
    }
}
