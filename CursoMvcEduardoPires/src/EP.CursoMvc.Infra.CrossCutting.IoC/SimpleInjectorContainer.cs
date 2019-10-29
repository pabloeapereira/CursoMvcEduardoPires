using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.Services;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Interfaces.Services;
using EP.CursoMvc.Domain.Services;
using EP.CursoMvc.Infra.Data.Context;
using EP.CursoMvc.Infra.Data.Repository;
using EP.CursoMvc.Infra.Data.UoW;
using SimpleInjector;

namespace EP.CursoMvc.Infra.CrossCutting.IoC
{
    public class SimpleInjectorContainer
    {
        // IoC => Inversion of Control
        public static void Register(Container container)
        {
            //Lifestyle.Transient => Uma instância para cada solicitação
            //Lifestyle.Singleton => Uma instância única para a classe
            //Lifestyle.Scoped => Uma instância única para o request
            #region  Application
            container.Register<IClienteAppService,ClienteAppService>(Lifestyle.Scoped);
            #endregion

            #region Domain
            container.Register<IClienteService,ClienteService>(Lifestyle.Scoped);
            #endregion

            #region  Infra.Data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork,UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcContext>(Lifestyle.Scoped);
            #endregion

        }
    }
}