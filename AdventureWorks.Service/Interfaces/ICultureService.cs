using AdventureWorks.Service.Dtos;

namespace AdventureWorks.Service.Interfaces
{
    public interface ICultureService
    {
        void CreateCulture(Culture culture);
        string[] GetCultureIDs();
        Culture[] GetCultures();
        void UpdateCulture(Culture culture);
        void DeleteCulture(string cultureID);
    }
}
