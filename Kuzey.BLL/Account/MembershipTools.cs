using System;
using System.Collections.Generic;
using System.Text;
using Kuzey.DAL;
using Kuzey.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace Kuzey.BLL.Account
{
    public class MembershipTools
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MembershipTools(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserManager<ApplicationUser> UserManager
        {
            get { return _userManager; }
        }
        public SignInManager<ApplicationUser> SignInManager
        {
            get { return _signInManager; }
        }
    }
}
