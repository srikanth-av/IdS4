using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Threading.Tasks;

namespace AuthServer.Service
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        IAuthRepository _authRepository;
        public ResourceOwnerPasswordValidator(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_authRepository.ValidatePassword(context.UserName, context.Password))

                context.Result = new GrantValidationResult(_authRepository.GetUserByName(context.UserName).Id.ToString(), "password", null, "local", null);
            else
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, "The username and password do not match", null);

            return Task.FromResult(context.Result);
        }
    }
}
