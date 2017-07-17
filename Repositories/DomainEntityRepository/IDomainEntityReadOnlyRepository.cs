using System;
using Models;

namespace Repositories.DomainEntityRepository
{
    public interface IDomainEntityReadOnlyRepository
    {
        DomainEntity GetIt(Guid gid);
    }
}