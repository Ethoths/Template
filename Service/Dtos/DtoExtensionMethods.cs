using Models;

namespace Service.Dtos
{
    public static class DtoExtensionMethods
    {
        public static DomainEntityDto ToDto(this DomainEntity domainEntity)
        {
            if (domainEntity == null)
            {
                return new DomainEntityDto();
            }

            return new DomainEntityDto
            {
                Gid = domainEntity.Gid,
                Name = domainEntity.Name,
                Description = domainEntity.Description
            };
        }
    }
}
