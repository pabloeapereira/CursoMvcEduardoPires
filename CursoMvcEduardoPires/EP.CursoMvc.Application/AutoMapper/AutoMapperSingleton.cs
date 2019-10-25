using System;
using AutoMapper;

namespace EP.CursoMvc.Application.AutoMapper
{
    public class AutoMapperSingleton :Mapper
    {
        private static AutoMapperSingleton _autoMapper;

        public static AutoMapperSingleton GetInstance()
        {
            if (_autoMapper == null)
            {
                
                _autoMapper = new AutoMapperSingleton(
                    new MapperConfiguration(cfg =>
                    {
                        
                        cfg.AddProfile<DomainToViewModelMappingProfile>();
                    })
                    );
            }

            return _autoMapper;
        }


        private AutoMapperSingleton(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }

        private AutoMapperSingleton(IConfigurationProvider configurationProvider, Func<Type, object> serviceCtor) : base(configurationProvider, serviceCtor)
        {
        }
    }
}
