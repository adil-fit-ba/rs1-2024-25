namespace RS1_2024_25.API.Endpoints.StudentEndpoints;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;

[MyAuthorization(isAdmin: true, isManager: false)]
[Route("students")]
public class StudentDeleteEndpoint : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{
    private readonly ApplicationDbContext _db;
    private readonly IMyAuthService _authService;

    public StudentDeleteEndpoint(ApplicationDbContext db, IMyAuthService authService)
    {
        _db = db;
        _authService = authService; //added to get info of the current user
    }

    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var student = await _db.Students.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (student == null)
            throw new KeyNotFoundException("Student not found");

        if (student.IsDeleted)
            throw new Exception("Student is already deleted");

        // Get current user info
        var currentUser = _authService.GetAuthInfoFromRequest();

        // Soft-delete
        student.IsDeleted = true;
        student.DeletedAt = DateTime.UtcNow; //added
        student.DeletedBy = currentUser.IsLoggedIn ? $"{currentUser.FirstName} {currentUser.LastName}" : null; //added to get the current user

        await _db.SaveChangesAsync(cancellationToken);
    }
}
