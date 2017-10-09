using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NDAgenda.Models;
using NDAgenda.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NDAgenda.Infra.Installers
{
    public class RepositoryInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ContatoContext>()
                .LifestylePerWebRequest());

            container.Register(
                Component.For<IDependencia>()
                .ImplementedBy<Dependencia>()
                .LifestyleTransient(),
                Component.For<IContatoRepository>()
                .ImplementedBy<ContatoEntityFrameworkRepository>()
                .LifestyleTransient());
        }

    }
}