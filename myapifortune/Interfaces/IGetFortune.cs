using Microsoft.Extensions.Diagnostics.HealthChecks;
using MyAPIFortune.Models;

namespace MyAPIFortune.Interfaces
{
    public interface IGetFortune
    {
        public Fortune ReturnRandomFortune();

        public Fortune ReturnTimeBasedFortune();

        public Fortune ReturnFortuneById(int id);
    }
}