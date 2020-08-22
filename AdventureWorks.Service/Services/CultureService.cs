using AdventureWorks.Dal;
using AdventureWorks.Service.Interfaces;
using System;
using System.Linq;

namespace AdventureWorks.Service.Services
{
    public class CultureService : ICultureService
    {
        private IDbRepository<Culture> cultureRepo;

        public CultureService()
        {
            cultureRepo = new DbRepository<Culture>();
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
    }
}
