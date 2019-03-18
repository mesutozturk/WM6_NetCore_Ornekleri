using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Kuzey.Models.IdentityEntities
{
    public class ApplicationRole : IdentityRole
    {
        [StringLength(128)]
        public string Description { get; set; }
    }
}
