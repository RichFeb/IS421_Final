namespace Entities.RequestFeatures
{

    public class CourseParameters : RequestParameters
    {
        public CourseParameters()
        {
            OrderBy = "Name";
        }

        public string SearchTerm { get; set; }

    }
}
