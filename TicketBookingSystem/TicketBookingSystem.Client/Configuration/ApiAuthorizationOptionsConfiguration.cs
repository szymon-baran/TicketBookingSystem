using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Options;

namespace App.Client.Services
{
    public class ApiAuthorizationOptionsConfiguration
        : IPostConfigureOptions<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>>
    {
        public void Configure(RemoteAuthenticationOptions<ApiAuthorizationProviderOptions> options)
        {
            options.UserOptions.RoleClaim ??= "role";
        }

        public void PostConfigure(string name, RemoteAuthenticationOptions<ApiAuthorizationProviderOptions> options)
        {
            if (string.Equals(name, Options.DefaultName))
            {
                Configure(options);
            }
        }
    }
}