namespace Entities.RequestFeatures
{

    public class UserParameters : RequestParameters
    {
        public UserParameters()
        {
            OrderBy = "Name";
        }

        public string SearchTerm { get; set; }

    }
}
