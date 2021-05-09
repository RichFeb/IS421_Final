using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IOrganizationRepository Organization { get; }

        IUserRepository User { get; }

        ICourseRepository Course { get; }

        ISectionRepository Section { get; }

        IAssignmentRepository Assignment { get; }

        ISubmissionRepository Submission { get; }

        ISchoolRepository School { get; }

        void Save();
    }
}
