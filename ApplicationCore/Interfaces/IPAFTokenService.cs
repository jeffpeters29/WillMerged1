using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IPafTokenService
    {
        Task<string> GetAddressApiToken(string referer);
    }
}
