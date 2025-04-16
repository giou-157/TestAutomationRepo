using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABUHB.AuthorizationServer.Models.MembershipDatabase
{
    /// <summary>
    /// AspNetUserPersona table class.
    /// </summary>
    public class AspNetUserPersona
    {
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [ForeignKey("FK_AspNetUserPersona_AspNetUsers_Id")]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// Gets or sets persona id.
        /// </summary>
        [ForeignKey("FK_AspNetUserPersona_AspNetPersonas_Id")]
        public Guid PersonaId { get; set; }
    }
}
