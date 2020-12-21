using DLL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using DLL.Repository;

namespace DLL
{
    public static class DLLDependency
    {
        public static void GetDLLDependency(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<IQueryRepository, QueryRepository>();
        }
    }
}
