using AutoMapper;
using StructureMap;

namespace ContactsWebApi.App_Start
{
    public class AutomapperConfig
    {
        private static IContainer _iocContainer;

        public static void Initialize(IContainer iocContainer)
        {
            _iocContainer = iocContainer;
            Mapper.Initialize(Configure);
        }

        private static void Configure(IMapperConfigurationExpression config)
        {
            var profiles = _iocContainer.GetAllInstances<Profile>();
            foreach (var profile in profiles)
            {
                config.AddProfile(profile);
            }
        }
    }
}