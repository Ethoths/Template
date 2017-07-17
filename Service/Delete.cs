using Models;
using Nancy;

namespace Service
{
    public sealed partial class Service
    {
        private Response Delete(dynamic parameters)
        {
            _domainEntityProcess.DeleteIt(new DomainEntity());

            return new Response();
        }
    }
}
