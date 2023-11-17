using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Entities.DinamicQuestionEntities;
using VET_ANIMAL_API.Entities;

namespace ProyectoBaseNetCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FormSectionQuestion> FormSectionQuestions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        //CAT
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<CodigosSecuencia> CodigosSecuencia { get; set; }
        public DbSet<MotivoConsulta> MotivoConsulta { get; set; }

        public DbSet<FichaSintoma> FichaSintomas { get; set; }
        public DbSet<HistoriaClinica> HistoriaClinica { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<TipoEnfermedad> TipoEnfermedad { get; set; }
        public DbSet<Enfermedad> Enfermedad { get; set; }
        public DbSet<FichaDetalle> Detalles { get; set; }
        public DbSet<FichaControl> FichaControl { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //SEG
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "SEG");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsersToken", "SEG");
            modelBuilder.Entity<IdentityRole>().ToTable("Role", "SEG");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "SEG");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "SEG");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "SEG");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "SEG");
            //CAT
            modelBuilder.Entity<Form>().ToTable("Forms", "CAT");
            modelBuilder.Entity<Section>().ToTable("Sections", "CAT");
            modelBuilder.Entity<Question>().ToTable("Questions", "CAT");
            modelBuilder.Entity<FormSectionQuestion>().ToTable("FormSectionQuestions", "CAT");
            modelBuilder.Entity<QuestionType>().ToTable("QuestionTypes", "CAT");
            modelBuilder.Entity<Item>().ToTable("Items", "CAT");
            modelBuilder.Entity<Catalog>().ToTable("Catalogs", "CAT");
            modelBuilder.Entity<CatalogItem>().ToTable("CatalogItems", "CAT");
            
        }
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder

    //     .UseSqlServer("Data Source=localhost;Initial Catalog=AnimalVet;Integrated Security=True;TrustServerCertificate=True");
    }    
}