using System;
using Nancy;
using Newtonsoft.Json;
using Processes;
using Repositories.DomainEntityRepository;

namespace Service
{
    public sealed partial class Service : NancyModule
    {
        private readonly GetDomainEntityProcess _domainEntityProcess;
        private readonly IDomainEntityReadOnlyRepository _domainEntityReadOnlyRepository;

        public Service(GetDomainEntityProcess domainEntityProcess, IDomainEntityReadOnlyRepository domainEntityReadOnlyRepository)
        {
            Utilities.Utilities.Guard(domainEntityProcess, "domainEntityProcess");
            Utilities.Utilities.Guard(domainEntityReadOnlyRepository, "domainEntityReadOnlyRepository");

            _domainEntityProcess = domainEntityProcess;
            _domainEntityReadOnlyRepository = domainEntityReadOnlyRepository;

            Post("/", parameters => Post());

            Get("/{gid}", parameters => Get(parameters));

            Put("/", parameters => Put(parameters));

            Delete("/", parameters => Delete(parameters));
        }

        private static bool TryGetGid(dynamic parameters, out Guid gid)
        {
            if (parameters != null)
            {
                if (parameters.gid.HasValue)
                {
                    Guid.TryParse(parameters.Gid.ToString().ToLower(), out gid);

                    return gid != Guid.Empty;
                }
            }

            return false;
        }

        private static T GetFromRequest<T>(Request request)
        {
            var id = request.Body;
            var length = request.Body.Length;
            var data = new byte[length];
            id.Read(data, 0, (int)length);
            var body = System.Text.Encoding.UTF8.GetString(data);

            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}
