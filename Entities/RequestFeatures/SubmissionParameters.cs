namespace Entities.RequestFeatures
{

    public class SubmissionParameters : RequestParameters
    {
        public SubmissionParameters()
        {
            OrderBy = "Name";
        }

        public string SearchTerm { get; set; }

    }
}
