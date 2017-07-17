using System;
using Models;
using Models.Exceptions;
using Nancy;
using Service.Dtos;

namespace Service
{
    public sealed partial class Service
    {
        private Response Post()
        {
            var newDomainEntity = GetFromRequest<DomainEntity>(Request);

            if (_domainEntityReadOnlyRepository.GetIt(newDomainEntity.Gid) != null)
            {
                return Response.AsJson(newDomainEntity.ToDto(), HttpStatusCode.Created);
            }

            try
            {
                _domainEntityProcess.CreateIt(newDomainEntity);

                return Response.AsJson(newDomainEntity.ToDto(), HttpStatusCode.Created);
            }
            catch (BusinessRuleException e)
            {
                var response = (Response)e.Message;
                response.StatusCode = HttpStatusCode.Forbidden;

                return response;

            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}