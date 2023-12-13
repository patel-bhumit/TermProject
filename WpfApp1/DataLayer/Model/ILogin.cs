namespace DataLayer.Model;
public interface ILogin
{
    string GetRole(string username, string password);
}
