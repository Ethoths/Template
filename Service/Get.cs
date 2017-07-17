using System;
using System.Threading.Tasks;
using Models.Exceptions;
using Nancy;
using Service.Dtos;

namespace Service
{
    public sealed partial class Service
    {

        private async Task<Response> Get(dynamic parameters)
        {
            Guid gid;

            if (!TryGetGid(parameters, out gid))
            {
                return HttpStatusCode.BadRequest;
            }

            var domainEntity = _domainEntityReadOnlyRepository.GetIt(gid);

            if (domainEntity == null)
            {
                return HttpStatusCode.NotFound;
            }

            try
            {
                return await Response.AsJson(_domainEntityProcess.GetIt(domainEntity).ToDto());
            }
            catch (BusinessRuleException e)
            {
                var response = (Response)e.Message;
                response.StatusCode = HttpStatusCode.Forbidden;

                return response;
            }
            catch (ArgumentNullException)
            {
                return HttpStatusCode.BadRequest;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
