using AdventureWorks.Dal;
using AdventureWorks.Service.Interfaces;
using System;
using System.Linq;

namespace AdventureWorks.Service.Services
{
    public class CultureService : ICultureService
    {
        private IDbRepository<Culture> cultureRepo;

        public CultureService(IDbRepository<Culture> iCultureRepo)
        {
            cultureRepo = iCultureRepo;
        }

        public void CreateCulture(Dtos.Culture culture)
        {
            try
            {
                var c = new Culture
                {
                    CultureID = culture.ID,
                    Name = culture.Name,
                    ModifiedDate = DateTime.Now
                };
                cultureRepo.Create(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string[] GetCultureIDs()
        {
            try
            {
                var cultureIDs = cultureRepo.Get(c => !string.IsNullOrEmpty(c.CultureID))
                    .Select(c => c.CultureID.Trim())
                    .ToArray();
                return cultureIDs;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Dtos.Culture[] GetCultures()
        {
            try
            {
                var cultures = cultureRepo.Get(c => !string.IsNullOrEmpty(c.CultureID))
                    .Select(c => new Dtos.Culture
                    {
                        ID = c.CultureID.Trim(),
                        Name = c.Name
                    }).ToArray();
                return cultures;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateCulture(Dtos.Culture culture)
        {
            try
            {
                var c = new Culture
                {
                    CultureID = culture.ID,
                    Name = culture.Name,
                    ModifiedDate = DateTime.Now
                };
                cultureRepo.Update(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteCulture(string cultureID)
        {
            try
            {
                cultureRepo.Delete(cultureRepo.Get(cr => cr.CultureID == cultureID));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
