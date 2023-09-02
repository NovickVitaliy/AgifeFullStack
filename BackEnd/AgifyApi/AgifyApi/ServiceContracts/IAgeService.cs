namespace AgifyApi.ServiceContracts;

public interface IAgeService
{
    Task<Dictionary<string, object>?> GetAge(string name);
}