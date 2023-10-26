using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Services;

public class TokenService
{
    public string Create()
    {
        //Instanciando o Token
        var handler = new JwtSecurityTokenHandler();

        //Assinando o Token a (key) é a chave gerada no arquivo configuration
        //A (KEY) esperada não é uma string, por isso o uso do SymmetricSecurityKey()... 
        //e converter a chave em um array de bytes

        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);

        //Criando o Token com as informações do KEY
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            algorithm: SecurityAlgorithms.HmacSha256
        );

        //Confiogurarndo o Token e o time expires
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2)
        };

        //(token) recebendo o conteduo correto pronto para uso (Decriptografado)
        var token = handler.CreateToken(tokenDescriptor);

        //Retornando uma string contendo o TOKEN
        return handler.WriteToken(token);
    }

}