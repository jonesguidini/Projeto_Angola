using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Clinica.Dominio.Contratos;
using Clinica.Infra.Data;
using Clinica.Infra.WebService.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Clinica.Apresentacao.WebApp
{
    public class Bootstrapper
    {
        /// <summary>
        /// Int
        /// </summary>
        /// <param name="builder"></param>
        internal static void Init(ContainerBuilder builder)
        {
            // TODO
        }

        // retorna container 
        public static IContainer Container
        {
            get
            {
                return _container;
            }
        }

        // define container privado (será definido valor apenas no proprio bootstrap
        private static IContainer _container = null;

        public void RegisterIOC()
        {
            var builder = new ContainerBuilder();

            // UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            // Db Context Factory
            builder.RegisterType<DbContextFactory<ContextoBD>>().As<IDbContextFactory>().InstancePerLifetimeScope();

            // Mvc application 
            builder.RegisterControllers(typeof(WebApiApplication).Assembly).OnActivated(e => {
            });

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            #region Repositorio

            // repository
            builder.RegisterAssemblyTypes(typeof(Clinica.Infra.Data.Repositorios.ClienteRepositorio).Assembly)
              .Where(t => t.Name.EndsWith("Repositorio"))
              .AsImplementedInterfaces().InstancePerLifetimeScope();

            #endregion Repositorio

            #region Serviços
            // Serviços
            builder.RegisterAssemblyTypes(typeof(Clinica.Dominio.Servicos.ClienteServico).Assembly)
               .Where(t => t.Name.EndsWith("Servico"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            #endregion AuthProvider

            Bootstrapper.Init(builder);
            var container = builder.Build();

            // Define bootstrap 
            Bootstrapper._container = container;

            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}