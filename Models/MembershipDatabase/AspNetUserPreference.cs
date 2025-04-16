using System.ComponentModel.DataAnnotations;
using System;

namespace ABUHB.AuthorizationServer.Models.MembershipDatabase
{
    /// <summary>
    /// AspNetUserPreference table class.
    /// </summary>
    public class AspNetUserPreference
    {
        /// <summary>
        /// Gets or sets preference id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [Required]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// Gets or sets site.
        /// </summary>
        public string Site { get; set; } = null!;

        /// <summary>
        /// Gets or sets ward.
        /// </summary>
        public string Ward { get; set; } = null!;

        /// <summary>
        /// Gets or sets consultant 1.
        /// </summary>
        public string Consultant1 { get; set; } = null!;

        /// <summary>
        /// Gets or sets consultant 2.
        /// </summary>
        public string Consultant2 { get; set; } = null!;

        /// <summary>
        /// Gets or sets consultant 3.
        /// </summary>
        public string Consultant3 { get; set; } = null!;
    }
}
