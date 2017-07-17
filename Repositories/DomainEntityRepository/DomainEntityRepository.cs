using System;
using System.Globalization;
using System.Linq;
using Models;
using Repositories.Domain;

namespace Repositories.DomainEntityRepository
{
    public class DomainEntityRepository : IDomainEntityRepository
    {
        private readonly DataContext _dataContext;

        public DomainEntityRepository(DataContext dataContext)
        {
            Utilities.Utilities.Guard(dataContext, "dataContext");

            _dataContext = dataContext;
        }

        public DomainEntity GetIt(Guid gid)
        {
            return _dataContext.DomainEntitys.FirstOrDefault(e => e.Gid == gid);
        }

        public DomainEntity CreateIt(DomainEntity domainEntity)
        {
            _dataContext.DomainEntitys.Add(domainEntity);

            return domainEntity;
        }

        public DomainEntity UpdateIt(DomainEntity domainEntity)
        {
            return new DomainEntity
            {
                Name = string.Format("Updated: {0}", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
            };
        }

        public DomainEntity DeleteIt(DomainEntity domainEntity)
        {
            return new DomainEntity
            {
                Name = string.Format("Deleted: {0}", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
            };
        }
    }
}
