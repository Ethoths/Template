using Nancy;

namespace Service
{
    public sealed partial class Service
    {
        private Response Put(dynamic parameters)
        {
            var domainEntity = Get(parameters);

            domainEntity.Name = parameters.Name;
            domainEntity.Description = parameters.Description;

            return _domainEntityProcess.UpdateIt(domainEntity).ToDto();
        }
    }
}
