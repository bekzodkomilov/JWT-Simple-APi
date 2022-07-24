namespace StudentLibrary.Service;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetMyName()
    {
        var result = "";
        if(_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.Identity.Name;
        }
        return result;
    }
}