namespace Entities.RequestFeatures
{

    public class SchoolParameters : RequestParameters
    {
        public SchoolParameters()
        {
            OrderBy = "Name";
        }

        public string SearchTerm { get; set; }

    }
}
