using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    public class ProfileService : IProfileService
    {
        IAuthRepository _repo;
        public ProfileService(IAuthRepository repo)
        {
            _repo = repo;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.Identity;
                var user = _repo.GetUserById(Convert.ToInt64(context.Subject.Claims.First().Value));
                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, user.Id.ToString())
                    //add as meny claims as want
                };
                context.IssuedClaims = claims;
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _repo.GetUserById(Convert.ToInt64((context.Subject.Claims).First().Value));
            context.IsActive = user != null && user.IsActive;
            return Task.FromResult(0);
        }
    }
}
