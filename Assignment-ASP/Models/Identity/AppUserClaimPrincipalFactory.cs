using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Assignment_ASP.Models.Identity
{
    public class AppUserClaimPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
    {
        private readonly UserManager<AppUser> userManager;

        public AppUserClaimPrincipalFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            this.userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var _customClaims = await base.GenerateClaimsAsync(user);

            _customClaims.AddClaim(new Claim("FullName", $"{user.FirstName} {user.LastName}"));

            
            _customClaims.AddClaim(new Claim("Image", user.ImageUrl));

            var roles = await userManager.GetRolesAsync(user);
            _customClaims.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            return _customClaims;
        }
    }
}
