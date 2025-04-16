using ABUHB.AuthorizationServer.Models.MembershipDatabase;
using Microsoft.EntityFrameworkCore;

namespace ABUHB.AuthorizationServer
{
    /// <summary>
    /// Represents the contract for the application's database context, providing access to various database entities and operations.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>Represents the AspNetPersona table in the database.</summary>
        public DbSet<AspNetPersona>? AspNetPersonas { get; set; }

        /// <summary>Represents the AspNetUserProperty table in the database.</summary>
        public DbSet<AspNetUserProperty>? AspNetUserProperties { get; set; }

        /// <summary>Represents the AspNetUserPreference table in the database.</summary>
        public DbSet<AspNetUserPreference>? AspNetUserPreferences { get; set; }

        /// <summary>Represents the AspNetUserPersona mapping table in the database.</summary>
        public DbSet<AspNetUserPersona>? AspNetUserPersonaMapping { get; set; }

        /// <summary>Represents the AspNetPersonaRole mapping table in the database.</summary>
        public DbSet<AspNetPersonaRole>? AspNetPersonaRoleMapping { get; set; }

        /// <summary>
        /// Saves changes made to the database context.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        int SaveChanges();
    }

}
