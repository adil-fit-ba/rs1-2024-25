using Azure;
using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;
using static RS1_2024_25.API.Endpoints.AuthEndpoints.AuthGetEndpoint;

namespace RS1_2024_25.API.Endpoints.AuthEndpoints
{

    public class AuthGetEndpoint : MyEndpointBaseAsync
        .WithoutRequest
        .WithActionResult<AuthGetResponse>
    {
        private readonly MyAuthService AuthService;

        public AuthGetEndpoint(MyAuthService authService){
            this.AuthService = authService;
        }


        [HttpGet]
        public override async Task<ActionResult<AuthGetResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            // Retrieve user info based on the token
            var authInfo = AuthService.GetAuthInfo();

            if (authInfo == null)
            {
                // Incorrect username or password
                return Unauthorized(new { Message = "Invalid token value or expired", });
            }

            // Return user information if the token is valid
            return new AuthGetResponse
            {
                MyAuthInfo = authInfo
            };
        }

        public class AuthGetResponse
        {
            public required MyAuthInfo? MyAuthInfo { get; set; }
        }
    }
}
