using Entities.Models;
using Entities.RequestFeatures;

namespace Contracts
{
    public interface ISubmissionRepository
    {
        PagedList<Submission> GetAllSubmissions(SubmissionParameters submissionParameters, bool trackChanges);
        Submission GetSubmission(int Id, bool trackChanges);
       
        void CreateSubmission(Submission submission);

        void DeleteSubmission(Submission submission);
    }
}
