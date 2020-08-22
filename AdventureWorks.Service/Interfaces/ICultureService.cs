using AdventureWorks.Service.Dtos;

namespace AdventureWorks.Service.Interfaces
{
    public interface ICultureService
    {
        string[] GetCultureIDs();
        Culture[] GetCultures();
    }
}
