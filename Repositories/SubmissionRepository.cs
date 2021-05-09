using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Repository.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class SubmissionRepository : RepositoryBase<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Submission> GetAllSubmissions(SubmissionParameters submissionParameters, bool trackChanges)
        {
            var submission = FindAll(trackChanges)
                .Search(submissionParameters.SearchTerm)
                .Sort(submissionParameters.OrderBy)
                .ToList();

            return PagedList<Submission>
            .ToPagedList(submission, submissionParameters.PageNumber, submissionParameters.PageSize);

        }

        public Submission GetSubmission(int Id, bool trackChanges) => FindByCondition(c => c.SubmissionId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Submission> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
          FindByCondition(x => ids.Contains(x.SubmissionId), trackChanges)
          .ToList();

        public void CreateSubmission(Submission submission) => Create(submission);


        public void DeleteSubmission(Submission submission)
        {
            Delete(submission);
        }

    }
}