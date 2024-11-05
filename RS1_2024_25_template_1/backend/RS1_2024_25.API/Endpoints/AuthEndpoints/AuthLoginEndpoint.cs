using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;
using static RS1_2024_25.API.Endpoints.Auth.AuthLoginEndpoint;

namespace RS1_2024_25.API.Endpoints.Auth
{

    public class AuthLoginEndpoint(ApplicationDbContext db, MyAuthService authService) : MyEndpointBaseAsync
        .WithRequest<LoginRequest>
        .WithActionResult<LoginResponse>
    {
        [HttpPost]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            // Step 1: Check login credentials
            var loggedInUser = await db.MyAppUsers
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password, cancellationToken);

            if (loggedInUser == null)
            {
                // Incorrect username or password
                return Unauthorized(new { Message = "Incorrect username or password" });
            }

            // Step 2: Generate random string as token
            string randomToken = MyTokenGenerator.Generate(10);

            // Step 3: Create a new authentication token record
            var newAuthToken = new MyAuthenticationToken
            {
                IpAddress = Request.HttpContext.Connection?.RemoteIpAddress?.ToString() ?? string.Empty,
                Value = randomToken,
                MyAppUser = loggedInUser,
                RecordedAt = DateTime.Now,
            };

            db.Add(newAuthToken);
            await db.SaveChangesAsync(cancellationToken);

            var authInfo = authService.GetAuthInfo(newAuthToken);

            // Step 4: Return token string in response
            // Return user information if the token is valid
            return new LoginResponse
            {
                Token = randomToken,
                MyAuthInfo = authInfo
            };
        }

        public class LoginRequest
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }

        public class LoginResponse
        {
            public required MyAuthInfo? MyAuthInfo { get; set; }
            public string Token { get; internal set; }
        }
    }
}
