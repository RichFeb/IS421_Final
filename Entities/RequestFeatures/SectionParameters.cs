namespace Entities.RequestFeatures
{

    public class SectionParameters : RequestParameters
    {
        public SectionParameters()
        {
            OrderBy = "Name";
        }

        public string SearchTerm { get; set; }

    }
}
