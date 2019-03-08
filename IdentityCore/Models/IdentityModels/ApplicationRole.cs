using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityCore.Models.IdentityModels
{
    public class ApplicationRole : IdentityRole
    {
        [Required, StringLength(128)]
        public string Description { get; set; }
    }
}
