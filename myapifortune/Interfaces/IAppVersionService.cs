using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MyAPIFortune.Interfaces
{
    public interface IAppVersionService
    {
        public string Version { get; }
    }

}


