using RS1_2024_25.API.Endpoints.AuthEndpoints;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Services;
using Xunit;
using Microsoft.AspNetCore.Mvc;

public class AuthLoginEndpointTests
{
    private readonly ApplicationDbContext _dbContext;
    private readonly MyAuthService _authService;
    private readonly AuthLoginEndpoint _authLoginEndpoint;

    public AuthLoginEndpointTests()
    {
        _dbContext = TestApplicationDbContext.CreateAsync().GetAwaiter().GetResult();
        _authService = new MyAuthService(_dbContext, TestHttpContextAccessorHelper.CreateWithAuthToken());
        _authLoginEndpoint = new AuthLoginEndpoint(_dbContext, _authService);
    }

    [Fact]
    public async Task Should_Return_Token_When_Valid_Credentials()
    {
        var request = new AuthLoginEndpoint.LoginRequest
        {
            Email = "admin",
            Password = "test"
        };

        ActionResult<AuthLoginEndpoint.LoginResponse> result = await _authLoginEndpoint.HandleAsync(request);

        Assert.NotNull(result.Value);
    }

    [Fact]
    public async Task Should_Return_Unauthorized_When_Invalid_Credentials()
    {
        var request = new AuthLoginEndpoint.LoginRequest
        {
            Email = "admin",
            Password = "wrongpassword"
        };

        var result = await _authLoginEndpoint.HandleAsync(request);

        Assert.IsType<UnauthorizedObjectResult>(result.Result);
    }
}
