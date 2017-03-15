using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DbLocalizationProvider
{
    public class LanguageEntities : DbContext
    {
        private readonly string _connectionString;
        public LanguageEntities() : this(ConfigurationContext.Current.ConnectionName) { }

        public LanguageEntities(string connectionString) // : base(new DbContextOptions<>())
        {
            _connectionString = connectionString;

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LanguageEntities, Configuration>());
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;

            //Database.Initialize(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["_connectionString"].ConnectionString);
        }

        public virtual DbSet<LocalizationResource> LocalizationResources { get; set; }

        public virtual DbSet<LocalizationResourceTranslation> LocalizationResourceTranslations { get; set; }
    }
}
