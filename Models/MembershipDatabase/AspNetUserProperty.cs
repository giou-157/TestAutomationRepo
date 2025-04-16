#nullable enable
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ABUHB.AuthorizationServer.Models.MembershipDatabase
{
    /// <summary>
    /// AspNetUserProperty table class.
    /// </summary>
    public class AspNetUserProperty
    {
        /// <summary>
        /// Gets or sets user property id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        public string UserId { get; set; } = null!;

        /// <summary>
        /// Gets or sets Date created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets data of last modification.
        /// </summary>
        public DateTime? DateLastModified { get; set; }

        /// <summary>
        /// Gets or sets the user that modified last.
        /// </summary>
        public string? LastModifiedByUser { get; set; }

        /// <summary>
        /// Gets or sets nadex id.
        /// </summary>
        public string? NadexId { get; set; }

        /// <summary>
        /// Gets or sets clinician title.
        /// </summary>
        public string? ClinicianTitle { get; set; }

        /// <summary>
        /// Get or sets staff pay number.
        /// </summary>
        public string? StaffPayNumber { get; set; }

        /// <summary>
        /// Gets or sets registration number.
        /// </summary>
        public string? RegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets registration type.
        /// </summary>
        public string? RegistrationType { get; set; }

        /// <summary>
        /// Gets or sets job title.
        /// </summary>
        public string? JobTitle { get; set; }

        /// <summary>
        /// Gets or sets grade.
        /// </summary>
        public string? Grade { get; set; }

        /// <summary>
        /// Gets or sets comment.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Gets or sets Active field.
        /// </summary>
        public bool Active { get; set; }

    }
}
