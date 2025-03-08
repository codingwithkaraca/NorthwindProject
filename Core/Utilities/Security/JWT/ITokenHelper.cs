using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT;

// ilerde başka bir araç ile token üretilmek istenirse diye interface e çektim
public interface ITokenHelper
{
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}