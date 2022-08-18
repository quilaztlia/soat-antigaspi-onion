using LoggerService;
using LoggerService.Abstractions;
using Microsoft.Extensions.Configuration;

namespace PresentationRest.Test.Mocks
{
    internal class MockTools
    {
        public static ICustomLoggerManager GetLogger()
        {
            //CHECK: IConfiguration real file to testConf
            return new CustomLoggerManager(new ConfigurationManager());
        }
    }
}
