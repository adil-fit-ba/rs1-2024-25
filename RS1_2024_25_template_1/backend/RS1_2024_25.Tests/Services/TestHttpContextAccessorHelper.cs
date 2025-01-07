using Microsoft.AspNetCore.Http;
using Moq;

public static class TestHttpContextAccessorHelper
{
    public static string tokenValue = "moj-token-123";

    public static IHttpContextAccessor CreateWithAuthToken()
    {
        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

        var context = new DefaultHttpContext();
        context.Request.Headers["my-auth-token"] = tokenValue;

        mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);

        return mockHttpContextAccessor.Object;
    }
}
