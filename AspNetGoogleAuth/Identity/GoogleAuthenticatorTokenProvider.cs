using System.Linq;
using System.Threading.Tasks;
using AspNetGoogleAuth.Extensions;
using Base32;
using Microsoft.AspNet.Identity;
using OtpSharp;

namespace AspNetGoogleAuth.Identity
{
    public class GoogleAuthenticatorTokenProvider : IUserTokenProvider<ApplicationUser, string>
    {
        public Task<string> GenerateAsync(string purpose, UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            // Our provider does not actually generate a code => return a null value
            return Task.FromResult((string)null);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            long timeStepMatched;

            var claim = user.Claims.FirstOrDefault(x => x.ClaimType == Claims.GoogleAuthSecret);
            if (claim == null || claim.ClaimValue.IsEmpty())
                return Task.FromResult(false);

            var otp = new Totp(Base32Encoder.Decode(claim.ClaimValue));
            // TODO: move window parameters to config
            bool valid = otp.VerifyTotp(token, out timeStepMatched, new VerificationWindow(2, 2));

            return Task.FromResult(valid);
        }

        public Task NotifyAsync(string token, UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            // Not implemented (no need so far):
            return Task.FromResult(true);
        }

        public Task<bool> IsValidProviderForUserAsync(UserManager<ApplicationUser, string> manager, ApplicationUser user)
        {
            var claim = user.Claims.FirstOrDefault(x => x.ClaimType == Claims.GoogleAuthSecret);
            return Task.FromResult(claim != null && !claim.ClaimValue.IsEmpty());
        }
    }
}