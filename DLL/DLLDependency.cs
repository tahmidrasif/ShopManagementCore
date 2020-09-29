using DLL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DLL.UnitOfWork;

namespace DLL
{
    public static class DLLDependency
    {
        public static void GetDLLDependency(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
