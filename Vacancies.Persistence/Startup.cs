using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Vacancies.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Vacancies.Persistence.Repositories;

namespace Vacancies.Persistence
{
    public static class Startup
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<VacanciesDbContext>(n => n.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICurriculumVitaeRepository, CurriculumVitaeRepository>();
			services.AddScoped<ISkillRepository, SkillRepository>();
			services.AddScoped<IVacancyRepository, VacancyRepository>();
		}
    }
}