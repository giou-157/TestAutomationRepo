using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ABUHB.AuthorizationServer.Models.MembershipDatabase
{
    /// <summary>
    /// AspNetPersona table class.
    /// </summary>
    public class AspNetPersona
    {
        /// <summary>
        /// Gets or sets persona Id.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets persona name.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets persona description.
        /// </summary>
        public string Description { get; set; } = null!;
    }
}
