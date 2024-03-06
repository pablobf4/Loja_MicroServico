using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace E_Commerce.PB.IdentityServerAPI.Configuration
{
    public class IdentityConfiguration 
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        // Identity Resource nome de grupo de claims que podem ser requisitadas passando um parametro de scope 
        // basecamente são recursos que devem ser protegido pelo indenty Server, dados do usuario ou até API como todo , email do usuario,perfil
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
              
                    new IdentityResources.OpenId(),  
                    new IdentityResources.Email(),
                    new IdentityResources.Profile()

            };
        //  Os escopos são um conceito abstrato que você pode usar como achar melhor para subdividir (ou não) seus recursos de API
        //SCOPE - são identificadores ou recursos que um cliente pode acessar, meu caso geekshopping.web, e ele vai acessar identyServer para pegar o token 
        // SCOPE - é usado pelo um CLIENT.
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("e-commerce","E-Commerce.PB Server"),
                new ApiScope(name: "read","Read data"),
                new ApiScope(name: "write","Write data"),
                new ApiScope(name: "delete","Delete data"),
                new ApiScope(name: "perfil","Perfil data"),


            };


        // CLIENT - é  componente de software que faz requisição  solicitando um token ao identyServer.
        //  assim ele pode identificar o usuario e dar acesso ou negar ao recurso exemplo :  geekshopping.web ´.
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId ="client",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write","profile" }
                },
                new Client
                {
                    ClientId ="e-commerce",
                    ClientSecrets = { new Secret("my_super_secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:4430/signin-oidc"},
                    PostLogoutRedirectUris={"https://localhost:4430/signout-callback--oidc"},
                    AllowedScopes =  new List<string>
                    {
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Email,
                         IdentityServerConstants.StandardScopes.Profile,
                         "e-commerce"
                    }
                }

            };
    }
}
