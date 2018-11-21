using System;
using System.Security.Claims;

namespace Araye.Code.Core.Security.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string GetNameFamily(this ClaimsPrincipal identity, string firstNameType="FirstName" , string lastNameType="LastName")
        {
            var nameClaim = identity.FindFirst(firstNameType);
            var familyClaim = identity.FindFirst(lastNameType);
            return (!string.IsNullOrEmpty(nameClaim.Value) && !string.IsNullOrEmpty(nameClaim.Value)) ? $"{nameClaim.Value} {familyClaim.Value}" : identity.Identity.Name;
        }
    }
}