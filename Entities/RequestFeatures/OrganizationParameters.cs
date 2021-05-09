namespace Entities.RequestFeatures
{
    public class OrganizationParameters : RequestParameters
    {
        public OrganizationParameters()
        {
            OrderBy = "Name";
        }
        public string SearchTerm { get; set; }
        public string CityFilter { get; set; }
    }
}
