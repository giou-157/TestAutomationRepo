using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ABUHB.AuthorizationServer.Models.MembershipDatabase;
using Microsoft.AspNetCore.Identity;

namespace ABUHB.AuthorizationServer
{
    /// <summary>
    /// Represents the application's database context that manages identity and additional entity configurations.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        /// <summary>
        /// Initializes the database context with specified options.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// Configures the entity framework model by defining table structures and key relationships.
        /// </summary>
        /// <param name="builder">The <see cref="ModelBuilder"/> used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configures the AspNetUserRoles entity with composite primary key.
            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("AspNetUserRoles");
                b.HasKey(r => new { r.UserId, r.RoleId });
            });

            // Configures the AspNetUserPersona entity with composite primary key and required fields.
            builder.Entity<AspNetUserPersona>(up =>
            {
                up.HasKey(new string[] { "UserId", "PersonaId" }).HasName("PK_AspNetUserPersona");
                up.Property(up => up.UserId).IsRequired();
                up.Property(up => up.PersonaId).IsRequired();
            });

            // Configures the AspNetPersonaRole entity with composite primary key and required fields.
            builder.Entity<AspNetPersonaRole>(up =>
            {
                up.HasKey(new string[] { "PersonaId", "RoleId" }).HasName("PK_AspNetPersonaRole");
                up.Property(up => up.PersonaId).IsRequired();
                up.Property(up => up.RoleId).IsRequired();
            });
        }

        // Database sets for the additional tables in the application.
        /// <summary>Represents the AspNetPersona table in the database.</summary>
        public virtual DbSet<AspNetPersona>? AspNetPersonas { get; set; } = null!;
        /// <summary>Represents the AspNetUserProperty table in the database.</summary>
        public virtual DbSet<AspNetUserProperty>? AspNetUserProperties { get; set; } = null!;
        /// <summary>Represents the AspNetUserPreference table in the database.</summary>
        public virtual DbSet<AspNetUserPreference>? AspNetUserPreferences { get; set; } = null!;
        /// <summary>Represents the AspNetUserPersona mapping table in the database.</summary>
        public virtual DbSet<AspNetUserPersona>? AspNetUserPersonaMapping { get; set; } = null!;
        /// <summary>Represents the AspNetPersonaRole mapping table in the database.</summary>
        public virtual DbSet<AspNetPersonaRole>? AspNetPersonaRoleMapping { get; set; } = null!;
    }
}
