using System.Reflection;
using MyAPIFortune.Interfaces;

namespace MyAPIFortune.Services
{

    public class AppVersionService : IAppVersionService
    {
        string IAppVersionService.Version => Assembly.GetExecutingAssembly().GetName().Version.ToString() ?? string.Empty;

    }
}
