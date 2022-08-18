namespace RealEstates.Services
{
    public interface ITagService
    {
        void Add(string name, int? importance = null);

        void BulkTagToPropertiesRelation();
    }
}
