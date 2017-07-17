using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Repositories.DomainEntityRepository;

namespace Service
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register<IDomainEntityRepository, DomainEntityRepository>();
            container.Register<IDomainEntityReadOnlyRepository, DomainEntityRepository>();
        }
    }
}