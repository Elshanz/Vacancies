using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vacancies.Application.Services;

namespace Vacancies.Application
{
	public static class Startup
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
            Persistence.Startup.ConfigureServices(services, configuration);

			services.AddScoped<ICurriculumVitaeService, CurriculumVitaeService>();
		}
	}
}