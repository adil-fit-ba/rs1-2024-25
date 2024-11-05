using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using System.Threading;
using System.Threading.Tasks;
using static RS1_2024_25.API.Endpoints.AuthEndpoints.AuthLogoutEndpoint;

namespace RS1_2024_25.API.Endpoints.AuthEndpoints;


public class AuthLogoutEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<LogoutRequest>
    .WithResult<LogoutResponse>
{
    [HttpPost]
    public override async Task<LogoutResponse> HandleAsync([FromBody] LogoutRequest request, CancellationToken cancellationToken = default)
    {
        // Step 1: Find the token in the database
        var authToken = await db.MyAuthenticationTokens
            .FirstOrDefaultAsync(t => t.Value == request.Token, cancellationToken);

        if (authToken == null)
        {
            // Token not found, possibly already invalidated
            return new LogoutResponse { IsSuccess = false, Message = "Invalid token or already logged out." };
        }

        // Step 2: Remove or invalidate the token
        db.MyAuthenticationTokens.Remove(authToken);
        await db.SaveChangesAsync(cancellationToken);

        // Step 3: Return success response
        return new LogoutResponse { IsSuccess = true, Message = "Logout successful." };
    }

    public class LogoutRequest
    {
        public string Token { get; set; }
    }

    public class LogoutResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
