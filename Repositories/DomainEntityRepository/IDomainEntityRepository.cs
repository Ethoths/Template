using Models;

namespace Repositories.DomainEntityRepository
{
    public interface IDomainEntityRepository : IDomainEntityReadOnlyRepository
    {
        DomainEntity CreateIt(DomainEntity domainEntity);

        DomainEntity UpdateIt(DomainEntity domainEntity);

        DomainEntity DeleteIt(DomainEntity domainEntity);
    }
}