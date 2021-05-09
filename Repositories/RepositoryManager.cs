using Contracts;
using Entities;
using Repository;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IOrganizationRepository _organizationRepository;
        private IUserRepository _userRepository;
        private ISchoolRepository _schoolRepository;
        private ISectionRepository _sectionRepository;
        private ISubmissionRepository _submissionRepository;
        private ICourseRepository _courseRepository;
        private IAssignmentRepository _assignmentRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IOrganizationRepository Organization
        {
            get
            {
                if (_organizationRepository == null)
                    _organizationRepository = new OrganizationRepository(_repositoryContext);

                return _organizationRepository;
            }
        }

        public IUserRepository User 
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);

                return _userRepository;
            }
        }

        public ICourseRepository Course 
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository(_repositoryContext);

                return _courseRepository;
            }
        }

        public ISectionRepository Section 
        {
            get
            {
                if (_sectionRepository == null)
                    _sectionRepository = new SectionRepository(_repositoryContext);

                return _sectionRepository;
            }
        }

        public IAssignmentRepository Assignment
        {
            get
            {
                if (_assignmentRepository == null)
                    _assignmentRepository = new AssignmentRepository(_repositoryContext);

                return _assignmentRepository;
            }
        }

    public ISubmissionRepository Submission 
        {
            get
            {
                if (_submissionRepository == null)
                    _submissionRepository = new SubmissionRepository(_repositoryContext);

                return _submissionRepository;
            }
        }

        public ISchoolRepository School
        {
            get
            {
                if (_schoolRepository == null)
                    _schoolRepository = new SchoolRepository(_repositoryContext);

                return _schoolRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}