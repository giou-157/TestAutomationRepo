using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ABUHB.AuthorizationServer.Models.MembershipDatabase
{
    /// <summary>
    /// AspNetPersonaRole table class.
    /// </summary>
    public class AspNetPersonaRole
    {
        /// <summary>
        /// Gets or sets persona id.
        /// </summary>
        [ForeignKey("FK_AspNetPersonaRole_AspNetPersonas_Id")]
        public Guid PersonaId { get; set; }

        /// <summary>
        /// Gets or sets role id.
        /// </summary>
        [ForeignKey("FK_AspNetPersonaRole_AspNetRoles_Id")]
        public string RoleId { get; set; } = null!;
    }
}
