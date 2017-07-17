using Models;
using Models.Exceptions;
using Repositories.Domain;
using Repositories.DomainEntityRepository;

namespace Processes
{
    public class GetDomainEntityProcess
    {
        private readonly IDomainEntityRepository _domainEntityRepository;
        private readonly DataContext _dataContext;

        public GetDomainEntityProcess(IDomainEntityRepository domainEntityRepository, DataContext dataContext)
        {
            _domainEntityRepository = domainEntityRepository;
            _dataContext = dataContext;
        }

        public DomainEntity GetIt(DomainEntity domainEntity)
        {
            Utilities.Utilities.Guard(domainEntity, "domainEntity");

            EnsureBusinessRule(domainEntity);

            return domainEntity;
        }

        public DomainEntity CreateIt(DomainEntity domainEntity)
        {
            Utilities.Utilities.Guard(domainEntity, "domainEntity");

            _dataContext.DomainEntitys.Add(domainEntity);
            _dataContext.SaveChanges();

            return domainEntity;
        }

        public DomainEntity UpdateIt(DomainEntity domainEntity)
        {
            Utilities.Utilities.Guard(domainEntity, "domainEntity");

            _dataContext.SaveChanges();

            return domainEntity;
        }

        public void DeleteIt(DomainEntity domainEntity)
        {
            Utilities.Utilities.Guard(domainEntity, "domainEntity");

            _dataContext.SaveChanges();
        }

        private static void EnsureBusinessRule(DomainEntity domainEntity)
        {
            if (domainEntity.Id > 10)
            {
                throw new BusinessRuleException("DomainEntity Id excceded.");
            }
        }
    }
}