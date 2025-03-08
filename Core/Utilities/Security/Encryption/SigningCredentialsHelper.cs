using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption;

public class SigningCredentialsHelper
{
    //SigningCredentials : bir sisteme girebilmek için elimizde olanlardır
    // kullanıcı adı ve şifre gibi 
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}