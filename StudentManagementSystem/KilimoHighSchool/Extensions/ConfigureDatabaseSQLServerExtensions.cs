using KilimoHighSchool.Database;
using KilimoHighSchool.Settings;
using Microsoft.EntityFrameworkCore;


namespace KilimoHighSchool.Extensions
{
    public static class ConfigureDatabaseSQLServerExtensions
    {
        public static void ConfigureDatabaseSQLServer(this WebApplicationBuilder builder, ConfigurationManager config)
        {
            builder.Services.AddOptions<SQLServerSettings>()
                 .Bind(config.GetRequiredSection(nameof(SQLServerSettings)))
                 .ValidateDataAnnotations()
                 .ValidateOnStart();

            var sqlServerSettings = new SQLServerSettings();
            config.GetSection(nameof(SQLServerSettings)).Bind(sqlServerSettings);

       
                builder.Services.AddDbContext<KilimoSchoolDbContext>(options =>
                {                   
                    options.UseSqlServer(sqlServerSettings.ConnectionString);
                });
            
        }
    }
}
